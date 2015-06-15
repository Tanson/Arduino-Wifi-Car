package com.iha.wcc.job.car;

/**
 * Class that represents the current controlled car.
 * Contains all values about it, manage the direction and the speed of the car for each user request.
 */
public class Car {
    public static int speed = 255;
    /*
     ******************************************* CONSTANTS - Car device settings *****************************************
     */
    /**
     * Tone frequency used as default value on the Arduino program. May change via the settings.
     */
    public final static int DEFAULT_TONE_FREQUENCY = 440;


    private static int SpeedForward = 255;

    /**
     * Minimal speed available for backward direction.
     */
    private static int SpeedBackward = 255;


    private static int speedTurn = 255;

    /*
     ******************************************* VARIABLES *****************************************
     */


    /**
     * Last direction used by the car. Stopped by default.
     */
    public static Direction lastDirection = Direction.STOP;

    /**
     * Last sens where the car was going. Useful to avoid change of sens after a LEFT/RIGHT action.
     */
    public static Direction lastSens = Direction.STOP;

    /**
     * List of available directions.
     */
    public static enum Direction {
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT,
        STOP
    };

    /**
     * Will be used to update the direction automatically once the speed will be calculated.
     * DEFAULT VALUE MUST BE TRUE, for each call to calculateSpeed().
     */
    private static boolean autoUpdateDirection = true;

    /*
     ******************************************* METHODS *****************************************
     */

    public static void setSettings(
                                   int SpeedForward,

                                   int SpeedBackward,

                                   int speedTurn){


        Car.SpeedForward = SpeedForward ;
        Car.SpeedBackward = SpeedBackward;
        Car.speedTurn = speedTurn;
    }

    /**
     * Update the lastDirection for the next action.
     * @param direction The new direction of the car.
     */
    private static void _saveNewDirection(Direction direction){
        lastDirection = direction;
        _saveNewSens();
    }

    /**
     * Update the lastSens when the lastDirection is a sens. (Not a simple direction/action)
     */
    private static void _saveNewSens() {
        // If the last direction was a sens, refresh it.
        if(lastDirection == Direction.BACKWARD || lastDirection == Direction.FORWARD){
            lastSens = lastDirection;
        }
    }

    /**
     * Format the lastDirection calculated by the program.
     * @return The last direction converted in string and toLowerCase.
     */
    private static String _formatLastDirection(){
        return lastDirection.toString().toLowerCase();
    }


    /**
     * Maximal speed available for forward direction.
     */
    public static int getSpeedForward() {
        return SpeedForward;
    }

    /**
     * Minimal speed available for backward direction.
     */
    public static int getSpeedBackward() {
        return SpeedBackward;
    }

    /**
     * Speed to use when you turn, will change the degree of the forwards wheels.
     */
    public static int getSpeedTurn() {
        return speedTurn;
    }
}
