using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Car_PC.SysConfig;

namespace Car_PC
{
    public partial class Config : Form
    {
       
        public Config()
        {
            InitializeComponent();
        }
       
        private void Config_Load(object sender, EventArgs e)
        {
            textBoxControlPort.Text = SysConfig.ControlConfig.Config.ServerPort.ToString();
            textBoxVideo.Text = SysConfig.ControlConfig.Config.VideoURL;
            textControlURL.Text = SysConfig.ControlConfig.Config.ServerIP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SysConfig.ControlConfig.SaveConfig(textControlURL.Text, Convert.ToInt32(textBoxControlPort.Text),
                    textBoxVideo.Text);
                MessageBox.Show("配置成功！", "配置信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("配置失败！", "配置信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
