package com.iha.wcc.job.car;

import android.content.SharedPreferences;

/**
 * Linino is the embedded Linux OS on the Arduino YUN embedded on the car.
 */
public class Linino {

    /**
     * Linino default IP address for its hotspot.
     */
    public final static String DEFAULT_NETWORK_IP = "134.100.100.103";

    /**
     * Linino default port number for its hotspot.
     */
    public final static int DEFAULT_NETWORK_PORT = 2001;
    public final static int DEFAULT_VIDEO_PORT = 8083;
    /**
     * Linino default user for SSH.
     */

    /**
     * Linino default user password for SSH.
     */


    public static String getNetworkIp(SharedPreferences prefs){
        return prefs.getString("ipNetwork", DEFAULT_NETWORK_IP);
    }

    public static int getNetworkPort(SharedPreferences prefs){
        return Integer.parseInt(prefs.getString("portNetwork", String.valueOf(DEFAULT_NETWORK_PORT)));
    }
    public static int getVideoPort(SharedPreferences prefs){
        return Integer.parseInt(prefs.getString("portCamera", String.valueOf(DEFAULT_VIDEO_PORT)));
    }
}
