using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Car_PC.Properties;
using Car_PC.UI;

namespace Car_PC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //启动屏幕
            //设置背景透明颜色
            TransparentSplash.Instance.TransparencyColor = Color.Black;

            TransparentSplash.Instance.Width = 322;
            TransparentSplash.Instance.Height = 379;
            //文本框坐标
            TransparentSplash.Instance.TextAreaX =65;
            TransparentSplash.Instance.TextAreaY = 240;
            //文本框宽度
            TransparentSplash.Instance.TextAreaWidth = 192;
            TransparentSplash.Instance.TextAreaHeight = 64;

            //设置文本颜色
            TransparentSplash.Instance.ForeColor = Color.Black;
            
            TransparentSplash.SetBackgroundImage(Resources.SplashImage);
            TransparentSplash.SetTitleString("智能小车");
            TransparentSplash.Instance.CommentaryString = "正在启动......";
          
            TransparentSplash.BeginDisplay();
            
            
            Application.Run(new Form1());
        }
    }
}
