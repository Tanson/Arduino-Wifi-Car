package com.iha.wcc.job.car;

/**
 * Created by Administrator on 2015/6/17.
 */
public  class CarInfo
{
    public CarInfo(String data)
    {
        String[] datas = data.split(",");

        this.Engine1 = Integer.parseInt(datas[0]);
        this.Engine2 = Integer.parseInt(datas[1]);
        this.Engine3 = Integer.parseInt(datas[2]);
        this.Engine4 = Integer.parseInt(datas[3]);

        this.LeftSpeed = Integer.parseInt(datas[4]);
        this.RightSpeed = Integer.parseInt(datas[5]);

        this.ServoX = Integer.parseInt(datas[6]);
        this.ServoY = Integer.parseInt(datas[7]);

        this.RadarStatus =Integer.parseInt(datas[8])>0?true:false;
        this.LightStatus = Integer.parseInt(datas[9]) > 0 ? true : false;
    }
    public  int Engine1 ;
    public  int Engine2 ;
    public  int Engine3;
    public  int Engine4 ;

    public int LeftSpeed ;
    public int RightSpeed;
    public int ServoX;
    public int ServoY;

    public boolean RadarStatus;
    public boolean LightStatus ;
}
