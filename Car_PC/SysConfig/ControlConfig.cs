using System;
using System.IO;

namespace Car_PC.SysConfig
{
    public  class ControlConfig
    {
        public static string ConfigFile = AppDomain.CurrentDomain.BaseDirectory + "Car.xml";
        public static void LoadConfig()
        {
            if (File.Exists(SysConfig.ControlConfig.ConfigFile))
            {

                StreamReader reader = new StreamReader(SysConfig.ControlConfig.ConfigFile);
                string xml = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                Config = Core.SerializeXml.DeserializeGetObject<ControlConfig>(xml);
            }
            else
            {
                Config=new ControlConfig();
                string xml = Core.SerializeXml.SerializeObjectToXML(Config);
                StreamWriter write = new StreamWriter(ConfigFile, false);
                write.Write(xml);
                write.Close();
                write.Dispose();
            }
        }
        public static void SaveConfig(string ip,int port,string url)
        {
            Config.ServerIP = ip;
            Config.ServerPort = port;
            Config.VideoURL = url;

            string xml = Core.SerializeXml.SerializeObjectToXML(Config);
            StreamWriter write = new StreamWriter(ConfigFile,false);
            write.Write(xml);
            write.Close();
            write.Dispose();
        }
        public static ControlConfig Config;
       
        public  string ServerIP = "134.100.100.103";
        public  int ServerPort = 2001;
        public  string VideoURL = "http://134.100.100.103:8083/?action=stream";
        public int TurnSpeed = 200;
    }
}
