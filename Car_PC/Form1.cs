using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using Car_PC.Core;
using Car_PC.UI;

namespace Car_PC
{
    public delegate void DataReceived(string data);
    public partial class Form1 : Form
    {
        bool dupflag = false;
        TcpClient tcpClient = new TcpClient();
        NetworkStream myNetworkStream;
        Thread myThread;

        public event DataReceived OnDataReceived;
        private MJPEGStream VideoStream;
        public Form1()
        {
            InitializeComponent();
            //视频流中间件初始化
            VideoStream = new MJPEGStream();
            VideoStream.NewFrame += VideoStream_NewFrame;
            VideoStream.VideoSourceError += VideoStream_VideoSourceError;
            SysConfig.ControlConfig.LoadConfig();
          
        }

        #region 窗体事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TransparentSplash.Instance.CommentaryString = "再见！";
            TransparentSplash.BeginDisplay();
            System.Threading.Thread.Sleep(1000);//暂停1秒装一下B
            VideoStream.Stop();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransparentSplash.EndDisplay();
            TransparentSplash.Instance.Dispose();
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            dupflag = false;
            //statucs_n = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);//暂停1秒装一下B
            TransparentSplash.Instance.CommentaryString = "正在初始化参数......";
            System.Threading.Thread.Sleep(1000);//暂停1秒装一下B

            buttonForward.BackColor = Color.LightBlue;
            buttonBackward.BackColor = Color.LightBlue;
            buttonLeft.BackColor = Color.LightBlue;
            buttonRight.BackColor = Color.LightBlue;
            btnEngineUp.BackColor = Color.LightBlue;
            btnEngineDown.BackColor = Color.LightBlue;
            btnEngineLeft.BackColor = Color.LightBlue;
            btnEngineRight.BackColor = Color.LightBlue;
            btnEngineStop.BackColor = Color.LightBlue;

            btnEngineStop.Select();

            OnDataReceived += OnMessageReceived;

            TransparentSplash.Instance.CommentaryString = "初始化完成......";
            
           
            System.Threading.Thread.Sleep(2000);//暂停1秒装一下B
            //启动屏关闭
            TransparentSplash.EndDisplay();
        }
        #endregion

    
        
        #region 方向控制部分
        private void buttonForward_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("MD_SD 255 255");
                SendData("MD_Qian");
            }
            dupflag = true;
        }
        private void buttonForward_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
            SendData("MD_Ting");
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("MD_SD 255 255");
                SendData("MD_Zuo");
            }
            dupflag = true;
        }
        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
           SendData("MD_Ting");
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("MD_SD 255 255");
                SendData("MD_You");
            }
            dupflag = true;
        }
        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
           SendData("MD_Ting");
        }

        private void buttonBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("MD_SD 255 255");
                SendData("MD_Hou");
            }
            dupflag = true;
        }
        private void buttonBackward_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
           SendData("MD_Ting");
        }
        #endregion

        #region 云台控制部分
        private void btnEngineUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("DJ_Shang");
            }
            dupflag = true;
        }
        private void btnEngineUp_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
        }

        private void btnEngineDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("DJ_Xia");
            }
            dupflag = true;
        }
        private void btnEngineDown_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
        }

        private void btnEngineLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("DJ_Zuo");
            }
            dupflag = true;
        }
        private void btnEngineLeft_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
        }

        private void btnEngineRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dupflag)
            {
                SendData("DJ_You");
            }
            dupflag = true;
        }
        private void btnEngineRight_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
        }


        private void btnEngineStop_MouseUp(object sender, MouseEventArgs e)
        {
            dupflag = false;
        }

        private void btnEngineStop_MouseDown(object sender, MouseEventArgs e)
        {
             if (!dupflag)
            {
                SendData("DJ_Zhong");
            }
            dupflag = true;
        }
        #endregion

        #region 喇叭部分
        private void buttonlaba_MouseDown(object sender, MouseEventArgs e)
        {
            SendData("LaBa_Start");
        }
        private void buttonlaba_MouseUp(object sender, MouseEventArgs e)
        {
            SendData("LaBa_Stop");
        }
        #endregion

        #region LED灯
        private void ledLight_Click(object sender, EventArgs e)
        {
            ((LedBulb)sender).On = !((LedBulb)sender).On;
            SendData(((LedBulb) sender).On ? "LED_Status 1" : "LED_Status 0");
        }

        #endregion

        #region 视频部分
        private void VideoStream_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap frameData = new Bitmap(eventArgs.Frame);
            pBShow.Image = frameData;
        }

        private void VideoStream_VideoSourceError(object sender, AForge.Video.VideoSourceErrorEventArgs eventArgs)
        {
           // ledVideoShow.On = false;
           // VideoStream.Stop();
           // MessageBox.Show(eventArgs.Description, @"视频错误");
           
        }
        /// <summary>
        /// 视频开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ledVideoShow_Click(object sender, EventArgs e)
        {
           
            ((LedBulb)sender).On = !((LedBulb)sender).On;
            if (((LedBulb)sender).On)
            {
                btnEngineStop.Select();
                roundButton_Set.Enabled = false;
                VideoStream.Source = SysConfig.ControlConfig.Config.VideoURL;
                VideoStream.Start();
            }
            else
            {
                VideoStream.Stop();
            }
            dupflag = false;
        }
        #endregion

        #region 其他按钮
        private void ledLeida_Click(object sender, EventArgs e)
        {
            ((LedBulb)sender).On = !((LedBulb)sender).On;
            SendData("Radar_Status " + Convert.ToInt32(((LedBulb)sender).On));
            dupflag = false;
        }
        private void roundButton_start_Click(object sender, EventArgs e)
        {
            IPAddress ipaddress;
            IPAddress[] ip = Dns.GetHostAddresses(SysConfig.ControlConfig.Config.ServerIP);
            if (ip.Length > 0)
            {
                ipaddress = ip[0];
            }
            else
            {
                MessageBox.Show("地址错误");
                return;
            }
            tcpClient.Connect(ipaddress, SysConfig.ControlConfig.Config.ServerPort);
            myThread = new Thread(new ThreadStart(ReceiveData));
            myThread.IsBackground = true;
            myThread.Start();
            roundButton_start.Enabled = false;
           
        }
        private void roundButton_Set_Click(object sender, EventArgs e)
        {
            Config cfg = new Config();
            cfg.ShowDialog();
            btnEngineStop.Select();
        }
        //自定义命令
        private void roundButton_CMD_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
             SendData(str);
        }
        #endregion

        #region 连接事件
        private void SendData(string cmd)
        {
            byte[] SendByte = System.Text.Encoding.ASCII.GetBytes(cmd + "\r");
            if (tcpClient.Connected)
            {
                myNetworkStream.Write(SendByte, 0, SendByte.Length);
                myNetworkStream.Flush();
            }
            else
            {
                roundButton_start.Enabled = true;
                MessageBox.Show("没有连接");

            }

        }
        public void ReceiveData()
        {
            try
            {
                while (tcpClient.Connected)
                {
                    myNetworkStream = tcpClient.GetStream();

                    Byte[] ReceiveData = new Byte[512];
                    myNetworkStream.Read(ReceiveData, 0, ReceiveData.Length);
                    string ReadMessage = System.Text.Encoding.ASCII.GetString(ReceiveData).Trim();
                    if (OnDataReceived != null) OnDataReceived.BeginInvoke(ReadMessage, null, null);
                    Thread.Sleep(100);
                }

            }
            catch { }
        }
        private void OnMessageReceived(string data)
        {
            Console.WriteLine("OnMessageReceived:" + data);
            string[] datas = data.Replace("\n", "").Split('\r');
            try
            {
                foreach (string val in datas)
                {
                    var reg = new Regex(@"\d+,\d+,\d+,\d+,\d+,\d+,\d+,\d+,\d+,\d+");
                    bool ism = reg.IsMatch(val);
                    var matchs = reg.Matches(val);
                    if (ism)
                    {
                        foreach (Match match in matchs)
                        {
                            CarInfo info = new CarInfo(match.Groups[0].Value);
                            BindCarinfo(info);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        private void BindCarinfo(CarInfo car)
        {
            this.Invoke(new Action(delegate()
            {
                aGauge_LeftEngine.Value = car.LeftSpeed;
                aGauge_RightEngine.Value = car.RightSpeed;
                aGauge1.Value = car.ServoY;
                aGauge11.Value = car.ServoX;
                ledLight.On = car.LightStatus;
                ledLeida.On = car.RadarStatus;
            }));

        }
        #endregion

        
    }
}
