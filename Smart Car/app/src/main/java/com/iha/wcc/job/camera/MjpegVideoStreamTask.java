package com.iha.wcc.job.camera;

import java.io.IOException;
import java.net.URI;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.iha.wcc.job.car.Camera;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.conn.HttpHostConnectException;
import org.apache.http.impl.client.DefaultHttpClient;

/**
 * In charge of start the streaming from an URL.
 * Load the stream from an URL and set it to a MjpegView.
 */
public class MjpegVideoStreamTask extends AsyncTask<String, Void, MjpegInputStream> {
    public String TAG = "MjpegVideoStreamTask";

    /**
     * The view to update with the loaded stream.
     */
    private MjpegView camera;

    /**
     * Context useful for the Toasts.
     */
    private Context context;

    /**
     * Constructor to define a custom view.
     * @param camera View that will be updated once the HTTP request will be done.
     */
    public MjpegVideoStreamTask(Context context, MjpegView camera){
        this.context = context;
        this.camera = camera;
    }

    /**
     * Call the target using HTTP request and return the content to the onPostExecute method.
     * @param url Url to reach.
     * @return MjpegInputStream if success.
     */
    @Override
    protected MjpegInputStream doInBackground(String... url) {
        HttpResponse res;
        DefaultHttpClient httpclient = new DefaultHttpClient();
        Log.d(TAG, "1. Sending http request");
        try {
            res = httpclient.execute(new HttpGet(URI.create(url[0])));
            Log.d(TAG, "2. Request finished, status = " + res.getStatusLine().getStatusCode());
            if(res.getStatusLine().getStatusCode()==401){
                //You must turn off camera User Access Control before this will work
                return null;
            }
            return new MjpegInputStream(res.getEntity().getContent());
        } catch (ClientProtocolException e) {
            e.printStackTrace();
            Log.d(TAG, "Request failed-ClientProtocolException", e);
            //Error connecting to camera
        } catch (IOException e) {
            e.printStackTrace();
            Log.d(TAG, "Request failed-IOException", e);
            //Error connecting to camera
        }

        return null;
    }

    /**
     * Executed once the doInBackground method is done.
     * Update the camera with the new stream.
     * @param result Content of the webpage called.
     */
    @Override
    protected void onPostExecute(MjpegInputStream result) {
        if(result != null){
            camera.setSource(result);
            camera.setDisplayMode(MjpegView.SIZE_BEST_FIT);
            camera.showFps(true);
        }else{
            Log.d(TAG, "\u65e0\u6cd5\u83b7\u53d6\u89c6\u9891\u6d41\uff0c\u4f60\u7684Arduino\u673a\u5668\u4eba\u5df2\u7ecf\u8054\u7f51\u4e86\u5417\uff1f\u540c\u65f6\u786e\u4fdd\u76f8\u673a\u6b63\u5728\u8fd0\u884c\u3002");
            Toast.makeText(this.context, "\u65e0\u6cd5\u83b7\u53d6\u89c6\u9891\u6d41\uff0c\u4f60\u7684Arduino\u673a\u5668\u4eba\u5df2\u7ecf\u8054\u7f51\u4e86\u5417\uff1f\u540c\u65f6\u786e\u4fdd\u76f8\u673a\u6b63\u5728\u8fd0\u884c\u3002", Toast.LENGTH_LONG).show();
            Toast.makeText(this.context, "\u89c6\u9891\u5730\u5740\uff1a" + Camera.DEFAULT_CAMERA_STREAMING_URL, Toast.LENGTH_LONG).show();
        }
    }
}
