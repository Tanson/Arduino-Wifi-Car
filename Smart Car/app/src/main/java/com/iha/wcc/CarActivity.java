package com.iha.wcc;

import java.io.IOException;
import java.io.OutputStream;
import java.net.ConnectException;
import java.net.Socket;

import java.net.UnknownHostException;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.atomic.AtomicBoolean;

import android.widget.ImageView;
import com.iha.wcc.job.camera.MjpegVideoStreamTask;
import com.iha.wcc.job.camera.MjpegView;
import com.iha.wcc.job.camera.TakePictureTask;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.FragmentActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.iha.wcc.job.car.Camera;
import com.iha.wcc.job.car.Car.Direction;
import com.iha.wcc.job.car.Linino;

import com.iha.wcc.job.car.Car;

public class CarActivity extends FragmentActivity {

    /**
     * Static instance of itself.
     */
    public static Context context;

    /**
     * Don't re-run start video stream when one is done, it's useless.
     */
    public static boolean videoStreamStarted;

    /**
     * Tag used to debug.
     */
    private final static String TAG_DEBUG = ">==< ArduinoYun >==<";

    /**
     * Information about the arduino to reach.
     * Use default values from the Car class if they are not provided.
     */
    private static String serverIpAddress;
    private static int serverPort;

    /**
     * Array of strings that contains all messages to send to the server using sockets.
     */
    private ArrayBlockingQueue<String> queriesQueueSocket = new ArrayBlockingQueue<String>(255);

    /**
     * Atomic boolean shared and accessible between different threads, used to be sure the connection is available.
     */
    private AtomicBoolean stopProcessingSocket = new AtomicBoolean(false);

    /**
     * Contains the values to write in the socket stream.
     */
    private OutputStream outputStreamSocket = null;

    /**
     * Socket connected to the Arduino.
     */
    private Socket socket = null;

    /**
     * Thread which manage socket streams.
     */
    private static Thread socketThread = null;

    /**
     * Runnable running in another thread, responsible to the communication with the car.
     */
    private final Runnable networkRunnable = new Runnable() {
        @Override
        public void run() {
            log("starting network thread");

            try {
                socket = new Socket(serverIpAddress, serverPort);
                outputStreamSocket = socket.getOutputStream();
            } catch (UnknownHostException e1) {
                e1.printStackTrace();
                stopProcessingSocket.set(true);
                log("UnknownHostException");
            } catch(final ConnectException e){// Final because we need it in the runnable.
                runOnUiThread(new Runnable(){
                    public void run(){
                        // Warn the user because the connection is wrong.
                        Toast.makeText(context, "\u65e0\u6cd5\u8fde\u63a5\u5230\u5c0f\u8f66\u7684\u7f51\u7edc\uff0c\u4f60\u786e\u5b9a\u8054\u7f51\u4e86\u5417\uff1f" + e.getMessage(), Toast.LENGTH_LONG).show();
                        Toast.makeText(context, "\u8bf7\u786e\u8ba4 , \u4f60\u80fd\u8fde\u63a5 " +serverIpAddress+":"+serverPort, Toast.LENGTH_LONG).show();
                    }
                });
                stopProcessingSocket.set(true);
            } catch (IOException e1) {
                e1.printStackTrace();
                stopProcessingSocket.set(true);
            }

            queriesQueueSocket.clear(); // we only want new values

            // Initialize once the thread is running.
            initializeCarSettings();

            try {
                while(!stopProcessingSocket.get()){
                    String val = queriesQueueSocket.take();
                    if(val != "-1"){
                        log("Sending value "+val);
                        outputStreamSocket.write((val + "\n").getBytes());
                    }
                }
            } catch (IOException e) {
                e.printStackTrace();
            } catch (InterruptedException e) {
                e.printStackTrace();
            } finally{
                try {
                    stopProcessingSocket.set(true);
                    if(outputStreamSocket != null) outputStreamSocket.close();
                    if(socket != null) socket.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }

            log("returning from network thread");
            socketThread = null;
        }
    };

    /**
     * Shared preferences.
     */
    private SharedPreferences prefs;

    // View components.
    private MjpegView cameraContent;// Contains the Mjpeg view which contains all other components and the video stream.
    private ImageButton pictureBtn;// Take a picture.
    private ImageButton honkBtn;// Play a sound.
    private ImageButton settingsBtn;// Go to settings.
    private ImageButton goForwardBtn;
    private ImageButton goBackwardBtn;
    private ImageButton goLeftBtn;
    private ImageButton goRightBtn;

    private ImageButton ytLeftBtn;
    private ImageButton ytRightBtn;
    private ImageButton ytUpBtn;
    private ImageButton ytDownBtn;
    private ImageButton ytCentBtn;
    private ImageButton radarBtn;
    private ImageButton lightBtn;


    private ImageView sensView;// Displays the current sens.

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        // Disable title, set full screen mode.
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        this.getWindow().setFlags(
                WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN
        );

        this.refreshStreamingView();

        // Define a static context. Useful for the anonymous events.
        context = getApplicationContext();

        // Get settings.
        prefs = PreferenceManager.getDefaultSharedPreferences(this);

        // Initialize view components.
        this.initializeComponents();

        // Bind listeners once all components are initialized.
        this.initializeListeners();

        // Initialize the car and the application.
        Bundle extras = getIntent().getExtras();

        // Initialize car network to reach. Settings will be updated when on the onStart() method.
        this.initializeCar(
                Linino.getNetworkIp(prefs),
                Linino.getNetworkPort(prefs)
        );
       this.initializeCamera(prefs);


    }

    @Override
    protected void onStart() {
        stopProcessingSocket.set(false);
        if(socketThread == null){
            socketThread = new Thread(networkRunnable);
            socketThread.start();
        }

        // Start to stream the video.
        this.startStreaming();

        super.onStart();
    }

    @Override
    public void onPause() {
        super.onPause();
        if(cameraContent != null){
            cameraContent.stopPlayback();//Necessary for the video
        }
    }

    @Override
    protected void onStop() {
        // Next time the view will be called it will automatically refresh all the components.
        cameraContent = null;

        // Stop sockets.
        stopProcessingSocket.set(true);
        queriesQueueSocket.clear();
        queriesQueueSocket.offer("-1");
        if(socketThread != null) socketThread.interrupt();
        super.onStop();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.car, menu);
        return true;
    }

    @Override
    public void onBackPressed() {
        // Start the video stream next time the application is ran.
        videoStreamStarted = false;
        this.finish();
    }

    /**
     * Initialize all view components.
     */
    private void initializeComponents() {
        this.pictureBtn = (ImageButton) findViewById(R.id.pictureBtn);
        pictureBtn.getBackground().setAlpha(100);
        this.honkBtn = (ImageButton) findViewById(R.id.honkBtn);
        honkBtn.getBackground().setAlpha(100);
        this.settingsBtn = (ImageButton) findViewById(R.id.settingsBtn);
        settingsBtn.getBackground().setAlpha(100);
        this.goForwardBtn = (ImageButton) findViewById(R.id.goForwardBtn);
        goForwardBtn.getBackground().setAlpha(100);
        this.goBackwardBtn = (ImageButton) findViewById(R.id.goBackwardBtn);
        goBackwardBtn.getBackground().setAlpha(100);
        this.goLeftBtn = (ImageButton) findViewById(R.id.goLeftBtn);
        goLeftBtn.getBackground().setAlpha(100);
        this.goRightBtn = (ImageButton) findViewById(R.id.goRightBtn);
        goRightBtn.getBackground().setAlpha(100);
        this.sensView = (ImageView) findViewById(R.id.sensView);

        this.ytLeftBtn = (ImageButton) findViewById(R.id.ytLeftBtn);
        ytLeftBtn.getBackground().setAlpha(100);
        this.ytRightBtn = (ImageButton) findViewById(R.id.ytRightBtn);
        ytRightBtn.getBackground().setAlpha(100);
        this.ytUpBtn = (ImageButton) findViewById(R.id.ytUpBtn);
        ytUpBtn.getBackground().setAlpha(100);
        this.ytDownBtn = (ImageButton) findViewById(R.id.ytDownBtn);
        ytDownBtn.getBackground().setAlpha(100);
        this.ytCentBtn = (ImageButton) findViewById(R.id.ytCentBtn);
        ytCentBtn.getBackground().setAlpha(100);
        this.radarBtn = (ImageButton) findViewById(R.id.radarBtn);
        radarBtn.getBackground().setAlpha(100);
        this.lightBtn = (ImageButton) findViewById(R.id.lightBtn);
        lightBtn.getBackground().setAlpha(100);
    }

    /**
     * Bind all button listeners. (called during the initialization)
     */
    private void initializeListeners(){
        /*
        ******** Forward **********
        */

        this.goForwardBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    goForwardBtn.getBackground().setAlpha(50);
                    goForward();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    doStop();
                    goForwardBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });

        /*
        ******** Backward **********
        */
        this.goBackwardBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if(event.getAction() == MotionEvent.ACTION_DOWN){
                    goBackwardBtn.getBackground().setAlpha(50);
                    goBackward();
                }else if(event.getAction() == MotionEvent.ACTION_UP){
                    doStop();
                    goBackwardBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });
        /*
        ******** Left **********
        */
        this.goLeftBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    goLeftBtn.getBackground().setAlpha(50);
                    goLeft();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    doStop();
                    goLeftBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });

        /*
        ******** Right **********
        */
        this.goRightBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
               // if(event.getAction() == MotionEvent.ACTION_DOWN || event.getAction() == MotionEvent.ACTION_MOVE){
                if(event.getAction() == MotionEvent.ACTION_DOWN){
                    goRightBtn.getBackground().setAlpha(50);
                    goRight();
                }else if(event.getAction() == MotionEvent.ACTION_UP){
                    doStop();
                    goRightBtn.getBackground().setAlpha(100);
                }
                return false;
            }
        });


         /*
        ******** yt up **********
        */

        this.ytUpBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    ytUpBtn.getBackground().setAlpha(50);
                    doytUp();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    ytUpBtn.getBackground().setAlpha(100);
                    //  doStop();
                }

                return false;
            }
        });

        /*
        ******** yt down **********
        */
        this.ytDownBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN ) {
                    ytDownBtn.getBackground().setAlpha(50);
                   doytDown();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    // doStop();
                    ytDownBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });
        /*
        ******** yt left **********
        */
        this.ytLeftBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    ytLeftBtn.getBackground().setAlpha(50);
                    doytLeft();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    //doStop();
                    ytLeftBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });

        /*
        ******** yt right **********
        */
        this.ytRightBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if(event.getAction() == MotionEvent.ACTION_DOWN){
                    ytRightBtn.getBackground().setAlpha(50);
                    doytRight();
                }else if(event.getAction() == MotionEvent.ACTION_UP){
                    //doStop();
                    ytRightBtn.getBackground().setAlpha(100);
                }
                return false;
            }
        });
 /*
        ******** yt center **********
        */
        this.ytCentBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    ytCentBtn.getBackground().setAlpha(50);
                    doytCenter();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    //doStop();
                    ytCentBtn.getBackground().setAlpha(100);
                }
                return false;
            }
        });



        /*
        ******** Radar **********
        */
        this.radarBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
               SwitchRadar();
            }
        });
        /*
        ******** Light **********
        */
        this.lightBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SwitchLight();
            }
        });

        /*
        ******** Picture **********
        */
        this.pictureBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                doPhoto();
            }
        });

        /*
        ******** Honk **********
        */
        this.honkBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
               // if (event.getAction() == MotionEvent.ACTION_DOWN || event.getAction() == MotionEvent.ACTION_MOVE) {
             if (event.getAction() == MotionEvent.ACTION_DOWN ) {
                    honkBtn.getBackground().setAlpha(50);
                    doHonk();
                } else if (event.getAction() == MotionEvent.ACTION_UP) {
                    doHonkClose();
                    honkBtn.getBackground().setAlpha(100);
                }

                return false;
            }
        });



        /*
        ******** Settings **********
        */
        this.settingsBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySettings();
            }
        });
    }

    // The next methods communicate with the car.

    /**
     * Initialize the car such as the arduino settings (ip/port) to reach.
     * @param ip IP address of the car.
     * @param port Port used to communicate with the Arduino.
     */
    private void initializeCar(String ip, int port){
        // Initialize the CarSocket and CarHttpRequest classes with available information about the host to connect.
        serverIpAddress = ip;
        serverPort = port;
    }
    private void initializeCamera(SharedPreferences prefs){
        Camera.DEFAULT_CAMERA_STREAMING_URL=Camera.getCameraStreamingUrl(prefs);
        Camera.DEFAULT_CAMERA_PICTURE_URL=Camera.getCameraPictureUrl(prefs);
        Camera. DEFAULT_CAMERA_WIDTH=Camera.getCameraWidth(prefs);
        Camera.DEFAULT_CAMERA_HEIGHT=Camera.getCameraHeight(prefs);
        Camera.DEFAULT_CAMERA_FPS=Camera.getCameraFps(prefs);
    }

    /**
     * Get the car settings from the local phone settings and send them to the car.
     */
    private void initializeCarSettings(){
        // Update android Car class settings.
        Car.setSettings(Integer.parseInt(prefs.getString("SpeedForward", String.valueOf(Car.getSpeedForward()))),
                Integer.parseInt(prefs.getString("SpeedBackward", String.valueOf(Car.getSpeedBackward()))),
                Integer.parseInt(prefs.getString("speedTurn", String.valueOf(Car.getSpeedTurn()))));
        // Update arduino Car device settings without updating the view.
        //this.send("settings", Car.speed + "/" + prefs.getString("soundPreferences", String.valueOf(Car.DEFAULT_TONE_FREQUENCY)), false);
        Log.d("ArduinoYun", prefs.getString("soundPreferences", String.valueOf(Car.DEFAULT_TONE_FREQUENCY)));
    }

    /**
     * Start the video streaming.
     */
    private void startStreaming() {
        if(this.cameraContent == null){
            refreshStreamingView();

            // Initialize view components.
            this.initializeComponents();

            // Bind listeners once all components are initialized.
            this.initializeListeners();
        }
        new MjpegVideoStreamTask(context, this.cameraContent).execute(Camera.DEFAULT_CAMERA_STREAMING_URL);
    }

    /**
     * Refresh the entire view with the special Mjpeg view to stream the video.
     */
    private void refreshStreamingView() {
        // Use a Mjpeg view instead of a "normal" view to stream the video.
        this.setContentView(cameraContent = new MjpegView(this));

        LayoutInflater inflater = this.getLayoutInflater();
        this.getWindow().addContentView(
                // Use the old layout to display the controls.
                inflater.inflate(R.layout.activity_car, null),
                new ViewGroup.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ViewGroup.LayoutParams.MATCH_PARENT
                )
        );
    }

    /**
     * Send a request to the car to go forward.
     */
    private void goForward(){
        Car.lastSens= Direction.FORWARD;
        send("MD_SD "+Car.getSpeedForward()+" "+Car.getSpeedForward());
        send("MD_Qian");

        //send(Car.calculateSpeed(Car.Direction.FORWARD));
    }

    /**
     * Send a request to the car to go backward.
     */
    private void goBackward(){
        Car.lastSens= Direction.BACKWARD;
        send("MD_SD "+Car.getSpeedBackward()+" "+Car.getSpeedBackward());
        send("MD_Hou");

        //send(Car.calculateSpeed(Car.Direction.BACKWARD));
    }

    /**
     * Send a request to the car to go to the left.
     */
    private void goLeft(){
        Car.lastSens= Direction.LEFT;
        send("MD_SD "+Car.getSpeedTurn()+" "+Car.getSpeedTurn());
        send("MD_Zuo");

      //  send(Car.calculateSpeed(Car.Direction.LEFT), Car.getSpeedTurnMotor()+"");

    }

    /**
     * Send a request to the car to go to the right.
     */
    private void goRight(){
        Car.lastSens= Direction.RIGHT;
        send("MD_SD "+Car.getSpeedTurn()+" "+Car.getSpeedTurn());
        send("MD_You");

      //  send(Car.calculateSpeed(Car.Direction.RIGHT), Car.getSpeedTurnMotor()+"");
    }
    private void doStop(){
        Car.lastSens= Direction.STOP;
        send("MD_Ting");

    }
    /**
     * Send a request to the car to stop turn.
     */
    private void SwitchRadar(){
        send("Radar_Status_Swich");
    }
    private void SwitchLight(){
        send("LED_Status_Swich");
    }

    /**
     * Send a request to the car to take a photo to store on the SD card.
     */
    private void doPhoto(){
        new TakePictureTask(context).execute(Camera.DEFAULT_CAMERA_PICTURE_URL);
    }

    /**
     * Send a request to the car to generate a a sound from the car (honk).
     */
    private void doHonk(){        send("LaBa_Start");    }
    private void doHonkClose(){        send("LaBa_Stop");    }
    private void doytLeft(){        send("DJ_Zuo");    }
    private void doytRight(){        send("DJ_You");    }
    private void doytUp(){        send("DJ_Shang");    }
    private void doytDown(){        send("DJ_Xia");    }
    private void doytCenter(){        send("DJ_Zhong");    }
    /**
     * Display settings activity.
     * Stop the car to avoid accident.
     */
    private void displaySettings(){
        // Stop the car before kill somebody.
        this.doStop();

        // Load the settings interface.
        Intent intentSettings = new Intent(this, SettingsActivity.class);
        startActivity(intentSettings);
        this.finish();
    }

    /**
     * Send a message using the socket connection to the Arduino.
     * @param action Action to execute.
     */
    private void send(String action){
        this.updateViewSens(Car.lastSens);
        queriesQueueSocket.offer(action + "\r\n");

    }

    /**
     * Send a message using the socket connection to the Arduino.
     * Send params instead of the speed.
     * @param action Action to execute.
     * @param params Params to the action.

    private void send(String action, String params){

        this.send(action, params, true);
    }
     */
    /**
     * Send a message using the socket connection to the Arduino.
     * Send params instead of the speed.
     * Don't update the view if asked. Useful for call to method who don't need to update the view.
     * @param action Action to execute.
     * @param params Params to the action.
     * @param updateView

    private void send(String action, String params, boolean updateView){
        // Send the message in the socket pool.
        queriesQueueSocket.offer(action + "/" + params);

        if(updateView){
            // Update the displayed speed in the view.
            this.updateViewSpeed(Car.speed);

            // Update the direction displayed on the view.
            this.updateViewSens(Car.lastSens);
        }
    }
     */
    /**
     * Update the sens displayed on the view.
     * @param sens The new sens of the car.
     */
    private void updateViewSens(Direction sens) {

        switch (sens){
            case FORWARD:
                this.sensView.setImageResource(R.drawable.arrow_up_32x32);
                break;
            case BACKWARD:
                this.sensView.setImageResource(R.drawable.arrow_down_32x32);
                break;
            case LEFT:
                this.sensView.setImageResource(R.drawable.arrow_left_32x32);
                break;
            case RIGHT:
                this.sensView.setImageResource(R.drawable.arrow_right_32x32);
                break;
            case STOP:
                this.sensView.setImageResource(R.drawable.denied_32x32);
                break;
            default:
                this.sensView.setImageResource(R.drawable.denied_32x32);
        }
    }


    /**
     * Debug log.
     * @param message Message to display.
     */
    private void log(String message){
        Log.d(TAG_DEBUG, message);
    }
}