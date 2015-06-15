using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car_PC
{
    public  class CarInfo
    {
        public CarInfo(string data)
        {
            string[] datas = data.Split(',');
            this.Engine1 = int.Parse(datas[0]);
            this.Engine2 = int.Parse(datas[1]);
            this.Engine3 = int.Parse(datas[2]);
            this.Engine4 = int.Parse(datas[3]);

            this.LeftSpeed = int.Parse(datas[4]);
            this.RightSpeed = int.Parse(datas[5]);

            this.ServoX = int.Parse(datas[6]);
            this.ServoY = int.Parse(datas[7]);

            this.RadarStatus = int.Parse(datas[8])>0?true:false;
            this.LightStatus = int.Parse(datas[9]) > 0 ? true : false;
        }
        public  int Engine1 { get; set; }
        public  int Engine2 { get; set; }
        public  int Engine3 { get; set; }
        public  int Engine4 { get; set; }

        public int LeftSpeed { get; set; }
        public int RightSpeed { get; set; }
        public int ServoX { get; set; }
        public int ServoY { get; set; }

        public bool RadarStatus { get; set; }
        public bool LightStatus { get; set; }
    }
}
