using Car_PC.UI;

namespace Car_PC
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnEngineRight = new System.Windows.Forms.Button();
            this.btnEngineLeft = new System.Windows.Forms.Button();
            this.btnEngineStop = new System.Windows.Forms.Button();
            this.btnEngineDown = new System.Windows.Forms.Button();
            this.btnEngineUp = new System.Windows.Forms.Button();
            this.label_fps = new System.Windows.Forms.Label();
            this.pBShow = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ledLeida = new Car_PC.UI.LedBulb();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonlaba = new Car_PC.UI.GlassButton();
            this.ledVideoShow = new Car_PC.UI.LedBulb();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonForward = new Car_PC.UI.GlassButton();
            this.ledLight = new Car_PC.UI.LedBulb();
            this.buttonBackward = new Car_PC.UI.GlassButton();
            this.buttonRight = new Car_PC.UI.GlassButton();
            this.buttonLeft = new Car_PC.UI.GlassButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.roundButton_start = new Car_PC.UI.RoundButton();
            this.roundButton_CMD = new Car_PC.UI.RoundButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.roundButton_Set = new Car_PC.UI.RoundButton();
            this.aGauge1 = new Car_PC.UI.AGauge();
            this.aGauge_RightEngine = new Car_PC.UI.AGauge();
            this.aGauge11 = new Car_PC.UI.AGauge();
            this.aGauge_LeftEngine = new Car_PC.UI.AGauge();
            ((System.ComponentModel.ISupportInitialize)(this.pBShow)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEngineRight
            // 
            this.btnEngineRight.Location = new System.Drawing.Point(149, 65);
            this.btnEngineRight.Name = "btnEngineRight";
            this.btnEngineRight.Size = new System.Drawing.Size(63, 42);
            this.btnEngineRight.TabIndex = 21;
            this.btnEngineRight.Text = "右";
            this.btnEngineRight.UseVisualStyleBackColor = true;
            this.btnEngineRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEngineRight_MouseDown);
            this.btnEngineRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEngineRight_MouseUp);
            // 
            // btnEngineLeft
            // 
            this.btnEngineLeft.Location = new System.Drawing.Point(11, 65);
            this.btnEngineLeft.Name = "btnEngineLeft";
            this.btnEngineLeft.Size = new System.Drawing.Size(63, 42);
            this.btnEngineLeft.TabIndex = 20;
            this.btnEngineLeft.Text = "左";
            this.btnEngineLeft.UseVisualStyleBackColor = true;
            this.btnEngineLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEngineLeft_MouseDown);
            this.btnEngineLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEngineLeft_MouseUp);
            // 
            // btnEngineStop
            // 
            this.btnEngineStop.Location = new System.Drawing.Point(80, 65);
            this.btnEngineStop.Name = "btnEngineStop";
            this.btnEngineStop.Size = new System.Drawing.Size(63, 42);
            this.btnEngineStop.TabIndex = 19;
            this.btnEngineStop.Text = "回位";
            this.btnEngineStop.UseVisualStyleBackColor = true;
            this.btnEngineStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEngineStop_MouseDown);
            this.btnEngineStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEngineStop_MouseUp);
            // 
            // btnEngineDown
            // 
            this.btnEngineDown.Location = new System.Drawing.Point(80, 117);
            this.btnEngineDown.Name = "btnEngineDown";
            this.btnEngineDown.Size = new System.Drawing.Size(63, 42);
            this.btnEngineDown.TabIndex = 18;
            this.btnEngineDown.Text = "俯";
            this.btnEngineDown.UseVisualStyleBackColor = true;
            this.btnEngineDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEngineDown_MouseDown);
            this.btnEngineDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEngineDown_MouseUp);
            // 
            // btnEngineUp
            // 
            this.btnEngineUp.Location = new System.Drawing.Point(80, 14);
            this.btnEngineUp.Name = "btnEngineUp";
            this.btnEngineUp.Size = new System.Drawing.Size(63, 42);
            this.btnEngineUp.TabIndex = 17;
            this.btnEngineUp.Text = "仰";
            this.btnEngineUp.UseVisualStyleBackColor = true;
            this.btnEngineUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEngineUp_MouseDown);
            this.btnEngineUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEngineUp_MouseUp);
            // 
            // label_fps
            // 
            this.label_fps.AutoSize = true;
            this.label_fps.Location = new System.Drawing.Point(590, 462);
            this.label_fps.Name = "label_fps";
            this.label_fps.Size = new System.Drawing.Size(35, 12);
            this.label_fps.TabIndex = 11;
            this.label_fps.Text = "0 fps";
            // 
            // pBShow
            // 
            this.pBShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBShow.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pBShow.ErrorImage")));
            this.pBShow.Image = ((System.Drawing.Image)(resources.GetObject("pBShow.Image")));
            this.pBShow.Location = new System.Drawing.Point(5, 4);
            this.pBShow.Name = "pBShow";
            this.pBShow.Size = new System.Drawing.Size(640, 480);
            this.pBShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBShow.TabIndex = 0;
            this.pBShow.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ledLeida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonlaba);
            this.groupBox1.Controls.Add(this.ledVideoShow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonForward);
            this.groupBox1.Controls.Add(this.ledLight);
            this.groupBox1.Controls.Add(this.buttonBackward);
            this.groupBox1.Controls.Add(this.buttonRight);
            this.groupBox1.Controls.Add(this.buttonLeft);
            this.groupBox1.Location = new System.Drawing.Point(12, 490);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 178);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "行驶控制";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(173, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "雷达";
            // 
            // ledLeida
            // 
            this.ledLeida.Location = new System.Drawing.Point(147, 122);
            this.ledLeida.Name = "ledLeida";
            this.ledLeida.On = false;
            this.ledLeida.Size = new System.Drawing.Size(20, 20);
            this.ledLeida.TabIndex = 32;
            this.ledLeida.Text = "ledBulb2";
            this.ledLeida.Click += new System.EventHandler(this.ledLeida_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(173, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "视频";
            // 
            // buttonlaba
            // 
            this.buttonlaba.CornerRadius = 50;
            this.buttonlaba.ForeColor = System.Drawing.Color.Black;
            this.buttonlaba.GlowColor = System.Drawing.Color.Red;
            this.buttonlaba.Location = new System.Drawing.Point(62, 66);
            this.buttonlaba.Name = "buttonlaba";
            this.buttonlaba.ShowSpecialSymbol = true;
            this.buttonlaba.Size = new System.Drawing.Size(50, 50);
            this.buttonlaba.SpecialSymbol = Car_PC.UI.GlassButton.SpecialSymbols.Speaker;
            this.buttonlaba.SpecialSymbolColor = System.Drawing.Color.Black;
            this.buttonlaba.TabIndex = 24;
            this.buttonlaba.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonlaba_MouseDown);
            this.buttonlaba.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonlaba_MouseUp);
            // 
            // ledVideoShow
            // 
            this.ledVideoShow.Color = System.Drawing.Color.Red;
            this.ledVideoShow.Location = new System.Drawing.Point(147, 20);
            this.ledVideoShow.Name = "ledVideoShow";
            this.ledVideoShow.On = false;
            this.ledVideoShow.Size = new System.Drawing.Size(20, 20);
            this.ledVideoShow.TabIndex = 28;
            this.ledVideoShow.Text = "ledBulb1";
            this.ledVideoShow.Click += new System.EventHandler(this.ledVideoShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(173, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "灯光";
            // 
            // buttonForward
            // 
            this.buttonForward.CornerRadius = 50;
            this.buttonForward.ForeColor = System.Drawing.Color.Black;
            this.buttonForward.GlowColor = System.Drawing.Color.Red;
            this.buttonForward.Location = new System.Drawing.Point(62, 10);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.ShowSpecialSymbol = true;
            this.buttonForward.Size = new System.Drawing.Size(50, 50);
            this.buttonForward.SpecialSymbol = Car_PC.UI.GlassButton.SpecialSymbols.ArrowUp;
            this.buttonForward.SpecialSymbolColor = System.Drawing.Color.Black;
            this.buttonForward.TabIndex = 11;
            this.buttonForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonForward_MouseDown);
            this.buttonForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonForward_MouseUp);
            // 
            // ledLight
            // 
            this.ledLight.Location = new System.Drawing.Point(147, 149);
            this.ledLight.Name = "ledLight";
            this.ledLight.On = false;
            this.ledLight.Size = new System.Drawing.Size(20, 20);
            this.ledLight.TabIndex = 29;
            this.ledLight.Text = "ledBulb2";
            this.ledLight.Click += new System.EventHandler(this.ledLight_Click);
            // 
            // buttonBackward
            // 
            this.buttonBackward.CornerRadius = 50;
            this.buttonBackward.ForeColor = System.Drawing.Color.Black;
            this.buttonBackward.GlowColor = System.Drawing.Color.Red;
            this.buttonBackward.Location = new System.Drawing.Point(62, 122);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.ShowSpecialSymbol = true;
            this.buttonBackward.Size = new System.Drawing.Size(50, 50);
            this.buttonBackward.SpecialSymbol = Car_PC.UI.GlassButton.SpecialSymbols.ArrowDown;
            this.buttonBackward.SpecialSymbolColor = System.Drawing.Color.Black;
            this.buttonBackward.TabIndex = 14;
            this.buttonBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBackward_MouseDown);
            this.buttonBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonBackward_MouseUp);
            // 
            // buttonRight
            // 
            this.buttonRight.CornerRadius = 50;
            this.buttonRight.ForeColor = System.Drawing.Color.Black;
            this.buttonRight.GlowColor = System.Drawing.Color.Red;
            this.buttonRight.Location = new System.Drawing.Point(117, 66);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.ShowSpecialSymbol = true;
            this.buttonRight.Size = new System.Drawing.Size(50, 50);
            this.buttonRight.SpecialSymbol = Car_PC.UI.GlassButton.SpecialSymbols.ArrowRight;
            this.buttonRight.SpecialSymbolColor = System.Drawing.Color.Black;
            this.buttonRight.TabIndex = 13;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseDown);
            this.buttonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseUp);
            // 
            // buttonLeft
            // 
            this.buttonLeft.CornerRadius = 50;
            this.buttonLeft.ForeColor = System.Drawing.Color.Black;
            this.buttonLeft.GlowColor = System.Drawing.Color.Red;
            this.buttonLeft.Location = new System.Drawing.Point(6, 66);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.ShowSpecialSymbol = true;
            this.buttonLeft.Size = new System.Drawing.Size(50, 50);
            this.buttonLeft.SpecialSymbol = Car_PC.UI.GlassButton.SpecialSymbols.ArrowLeft;
            this.buttonLeft.SpecialSymbolColor = System.Drawing.Color.Black;
            this.buttonLeft.TabIndex = 12;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseDown);
            this.buttonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEngineStop);
            this.groupBox2.Controls.Add(this.btnEngineUp);
            this.groupBox2.Controls.Add(this.btnEngineRight);
            this.groupBox2.Controls.Add(this.btnEngineDown);
            this.groupBox2.Controls.Add(this.btnEngineLeft);
            this.groupBox2.Location = new System.Drawing.Point(237, 490);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 178);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "云台控制";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.roundButton_start);
            this.groupBox3.Controls.Add(this.roundButton_CMD);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.roundButton_Set);
            this.groupBox3.Location = new System.Drawing.Point(462, 490);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 178);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "指令控制";
            // 
            // roundButton_start
            // 
            this.roundButton_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.roundButton_start.Dome = true;
            this.roundButton_start.Location = new System.Drawing.Point(8, 20);
            this.roundButton_start.Name = "roundButton_start";
            this.roundButton_start.RecessDepth = 3;
            this.roundButton_start.Size = new System.Drawing.Size(71, 43);
            this.roundButton_start.TabIndex = 9;
            this.roundButton_start.Text = "连 接";
            this.roundButton_start.UseVisualStyleBackColor = false;
            this.roundButton_start.Click += new System.EventHandler(this.roundButton_start_Click);
            // 
            // roundButton_CMD
            // 
            this.roundButton_CMD.BevelDepth = 2;
            this.roundButton_CMD.BevelHeight = 4;
            this.roundButton_CMD.Dome = true;
            this.roundButton_CMD.Location = new System.Drawing.Point(127, 113);
            this.roundButton_CMD.Name = "roundButton_CMD";
            this.roundButton_CMD.RecessDepth = 4;
            this.roundButton_CMD.Size = new System.Drawing.Size(50, 50);
            this.roundButton_CMD.TabIndex = 3;
            this.roundButton_CMD.Text = "Go";
            this.roundButton_CMD.UseVisualStyleBackColor = true;
            this.roundButton_CMD.Click += new System.EventHandler(this.roundButton_CMD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "指令：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 7;
            // 
            // roundButton_Set
            // 
            this.roundButton_Set.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.roundButton_Set.Dome = true;
            this.roundButton_Set.Location = new System.Drawing.Point(106, 20);
            this.roundButton_Set.Name = "roundButton_Set";
            this.roundButton_Set.RecessDepth = 3;
            this.roundButton_Set.Size = new System.Drawing.Size(71, 43);
            this.roundButton_Set.TabIndex = 6;
            this.roundButton_Set.Text = "设 置";
            this.roundButton_Set.UseVisualStyleBackColor = false;
            this.roundButton_Set.Click += new System.EventHandler(this.roundButton_Set_Click);
            // 
            // aGauge1
            // 
            this.aGauge1.BackColor = System.Drawing.Color.White;
            this.aGauge1.BaseArcColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.aGauge1.BaseArcRadius = 30;
            this.aGauge1.BaseArcStart = 270;
            this.aGauge1.BaseArcSweep = 180;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.Cap_Idx = ((byte)(1));
            this.aGauge1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge1.CapPosition = new System.Drawing.Point(3, 3);
            this.aGauge1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(3, 3),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge1.CapsText = new string[] {
        "",
        "云台仰角",
        "",
        "",
        ""};
            this.aGauge1.CapText = "云台仰角";
            this.aGauge1.Center = new System.Drawing.Point(30, 70);
            this.aGauge1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge1.Location = new System.Drawing.Point(663, 136);
            this.aGauge1.MaxValue = 180F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = Car_PC.UI.AGauge.NeedleColorEnum.Green;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.Red;
            this.aGauge1.NeedleRadius = 30;
            this.aGauge1.NeedleType = 0;
            this.aGauge1.NeedleWidth = 1;
            this.aGauge1.Range_Idx = ((byte)(0));
            this.aGauge1.RangeColor = System.Drawing.Color.LightGreen;
            this.aGauge1.RangeEnabled = false;
            this.aGauge1.RangeEndValue = 300F;
            this.aGauge1.RangeInnerRadius = 40;
            this.aGauge1.RangeOuterRadius = 40;
            this.aGauge1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge1.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge1.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge1.RangesInnerRadius = new int[] {
        40,
        10,
        70,
        70,
        70};
            this.aGauge1.RangesOuterRadius = new int[] {
        40,
        40,
        80,
        80,
        80};
            this.aGauge1.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge1.RangeStartValue = -100F;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aGauge1.ScaleLinesInterInnerRadius = 35;
            this.aGauge1.ScaleLinesInterOuterRadius = 30;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.aGauge1.ScaleLinesMajorInnerRadius = 40;
            this.aGauge1.ScaleLinesMajorOuterRadius = 30;
            this.aGauge1.ScaleLinesMajorStepValue = 30F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.aGauge1.ScaleLinesMinorInnerRadius = 35;
            this.aGauge1.ScaleLinesMinorNumOf = 3;
            this.aGauge1.ScaleLinesMinorOuterRadius = 30;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 55;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 2;
            this.aGauge1.ScaleNumbersStepScaleLines = 2;
            this.aGauge1.Size = new System.Drawing.Size(91, 137);
            this.aGauge1.TabIndex = 31;
            this.aGauge1.TabStop = false;
            this.aGauge1.Value = 90F;
            // 
            // aGauge_RightEngine
            // 
            this.aGauge_RightEngine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.aGauge_RightEngine.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge_RightEngine.BaseArcRadius = 40;
            this.aGauge_RightEngine.BaseArcStart = 180;
            this.aGauge_RightEngine.BaseArcSweep = 90;
            this.aGauge_RightEngine.BaseArcWidth = 2;
            this.aGauge_RightEngine.Cap_Idx = ((byte)(1));
            this.aGauge_RightEngine.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge_RightEngine.CapPosition = new System.Drawing.Point(10, 80);
            this.aGauge_RightEngine.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 80),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge_RightEngine.CapsText = new string[] {
        "",
        "右侧电机速度",
        "",
        "",
        ""};
            this.aGauge_RightEngine.CapText = "右侧电机速度";
            this.aGauge_RightEngine.Center = new System.Drawing.Point(70, 70);
            this.aGauge_RightEngine.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge_RightEngine.Location = new System.Drawing.Point(760, 12);
            this.aGauge_RightEngine.MaxValue = 280F;
            this.aGauge_RightEngine.MinValue = 0F;
            this.aGauge_RightEngine.Name = "aGauge_RightEngine";
            this.aGauge_RightEngine.NeedleColor1 = Car_PC.UI.AGauge.NeedleColorEnum.Gray;
            this.aGauge_RightEngine.NeedleColor2 = System.Drawing.Color.Black;
            this.aGauge_RightEngine.NeedleRadius = 40;
            this.aGauge_RightEngine.NeedleType = 0;
            this.aGauge_RightEngine.NeedleWidth = 2;
            this.aGauge_RightEngine.Range_Idx = ((byte)(0));
            this.aGauge_RightEngine.RangeColor = System.Drawing.Color.LightGreen;
            this.aGauge_RightEngine.RangeEnabled = false;
            this.aGauge_RightEngine.RangeEndValue = 300F;
            this.aGauge_RightEngine.RangeInnerRadius = 70;
            this.aGauge_RightEngine.RangeOuterRadius = 80;
            this.aGauge_RightEngine.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge_RightEngine.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge_RightEngine.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge_RightEngine.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.aGauge_RightEngine.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.aGauge_RightEngine.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge_RightEngine.RangeStartValue = -100F;
            this.aGauge_RightEngine.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge_RightEngine.ScaleLinesInterInnerRadius = 42;
            this.aGauge_RightEngine.ScaleLinesInterOuterRadius = 50;
            this.aGauge_RightEngine.ScaleLinesInterWidth = 2;
            this.aGauge_RightEngine.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge_RightEngine.ScaleLinesMajorInnerRadius = 40;
            this.aGauge_RightEngine.ScaleLinesMajorOuterRadius = 54;
            this.aGauge_RightEngine.ScaleLinesMajorStepValue = 70F;
            this.aGauge_RightEngine.ScaleLinesMajorWidth = 2;
            this.aGauge_RightEngine.ScaleLinesMinorColor = System.Drawing.Color.Black;
            this.aGauge_RightEngine.ScaleLinesMinorInnerRadius = 43;
            this.aGauge_RightEngine.ScaleLinesMinorNumOf = 3;
            this.aGauge_RightEngine.ScaleLinesMinorOuterRadius = 50;
            this.aGauge_RightEngine.ScaleLinesMinorWidth = 1;
            this.aGauge_RightEngine.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge_RightEngine.ScaleNumbersFormat = null;
            this.aGauge_RightEngine.ScaleNumbersRadius = 62;
            this.aGauge_RightEngine.ScaleNumbersRotation = 90;
            this.aGauge_RightEngine.ScaleNumbersStartScaleLine = 1;
            this.aGauge_RightEngine.ScaleNumbersStepScaleLines = 2;
            this.aGauge_RightEngine.Size = new System.Drawing.Size(91, 100);
            this.aGauge_RightEngine.TabIndex = 25;
            this.aGauge_RightEngine.Text = "aGauge1";
            this.aGauge_RightEngine.Value = 0F;
            // 
            // aGauge11
            // 
            this.aGauge11.BackColor = System.Drawing.Color.White;
            this.aGauge11.BaseArcColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.aGauge11.BaseArcRadius = 30;
            this.aGauge11.BaseArcStart = 0;
            this.aGauge11.BaseArcSweep = 180;
            this.aGauge11.BaseArcWidth = 2;
            this.aGauge11.Cap_Idx = ((byte)(1));
            this.aGauge11.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge11.CapPosition = new System.Drawing.Point(3, 3);
            this.aGauge11.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(3, 3),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge11.CapsText = new string[] {
        "",
        "云台角度",
        "",
        "",
        ""};
            this.aGauge11.CapText = "云台角度";
            this.aGauge11.Center = new System.Drawing.Point(65, 40);
            this.aGauge11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge11.Location = new System.Drawing.Point(760, 136);
            this.aGauge11.MaxValue = 180F;
            this.aGauge11.MinValue = 0F;
            this.aGauge11.Name = "aGauge11";
            this.aGauge11.NeedleColor1 = Car_PC.UI.AGauge.NeedleColorEnum.Green;
            this.aGauge11.NeedleColor2 = System.Drawing.Color.Red;
            this.aGauge11.NeedleRadius = 30;
            this.aGauge11.NeedleType = 0;
            this.aGauge11.NeedleWidth = 1;
            this.aGauge11.Range_Idx = ((byte)(0));
            this.aGauge11.RangeColor = System.Drawing.Color.LightGreen;
            this.aGauge11.RangeEnabled = false;
            this.aGauge11.RangeEndValue = 300F;
            this.aGauge11.RangeInnerRadius = 35;
            this.aGauge11.RangeOuterRadius = 40;
            this.aGauge11.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge11.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge11.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge11.RangesInnerRadius = new int[] {
        35,
        10,
        70,
        70,
        70};
            this.aGauge11.RangesOuterRadius = new int[] {
        40,
        40,
        80,
        80,
        80};
            this.aGauge11.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge11.RangeStartValue = -100F;
            this.aGauge11.ScaleLinesInterColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aGauge11.ScaleLinesInterInnerRadius = 35;
            this.aGauge11.ScaleLinesInterOuterRadius = 30;
            this.aGauge11.ScaleLinesInterWidth = 1;
            this.aGauge11.ScaleLinesMajorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.aGauge11.ScaleLinesMajorInnerRadius = 40;
            this.aGauge11.ScaleLinesMajorOuterRadius = 30;
            this.aGauge11.ScaleLinesMajorStepValue = 30F;
            this.aGauge11.ScaleLinesMajorWidth = 2;
            this.aGauge11.ScaleLinesMinorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.aGauge11.ScaleLinesMinorInnerRadius = 35;
            this.aGauge11.ScaleLinesMinorNumOf = 3;
            this.aGauge11.ScaleLinesMinorOuterRadius = 30;
            this.aGauge11.ScaleLinesMinorWidth = 1;
            this.aGauge11.ScaleNumbersColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aGauge11.ScaleNumbersFormat = null;
            this.aGauge11.ScaleNumbersRadius = 55;
            this.aGauge11.ScaleNumbersRotation = 0;
            this.aGauge11.ScaleNumbersStartScaleLine = 2;
            this.aGauge11.ScaleNumbersStepScaleLines = 2;
            this.aGauge11.Size = new System.Drawing.Size(129, 116);
            this.aGauge11.TabIndex = 15;
            this.aGauge11.TabStop = false;
            this.aGauge11.Value = 90F;
            // 
            // aGauge_LeftEngine
            // 
            this.aGauge_LeftEngine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.aGauge_LeftEngine.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge_LeftEngine.BaseArcRadius = 40;
            this.aGauge_LeftEngine.BaseArcStart = 180;
            this.aGauge_LeftEngine.BaseArcSweep = 90;
            this.aGauge_LeftEngine.BaseArcWidth = 2;
            this.aGauge_LeftEngine.Cap_Idx = ((byte)(1));
            this.aGauge_LeftEngine.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge_LeftEngine.CapPosition = new System.Drawing.Point(10, 80);
            this.aGauge_LeftEngine.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 80),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge_LeftEngine.CapsText = new string[] {
        "",
        "左侧电机速度",
        "",
        "",
        ""};
            this.aGauge_LeftEngine.CapText = "左侧电机速度";
            this.aGauge_LeftEngine.Center = new System.Drawing.Point(70, 70);
            this.aGauge_LeftEngine.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge_LeftEngine.Location = new System.Drawing.Point(663, 12);
            this.aGauge_LeftEngine.MaxValue = 280F;
            this.aGauge_LeftEngine.MinValue = 0F;
            this.aGauge_LeftEngine.Name = "aGauge_LeftEngine";
            this.aGauge_LeftEngine.NeedleColor1 = Car_PC.UI.AGauge.NeedleColorEnum.Gray;
            this.aGauge_LeftEngine.NeedleColor2 = System.Drawing.Color.Black;
            this.aGauge_LeftEngine.NeedleRadius = 40;
            this.aGauge_LeftEngine.NeedleType = 0;
            this.aGauge_LeftEngine.NeedleWidth = 2;
            this.aGauge_LeftEngine.Range_Idx = ((byte)(0));
            this.aGauge_LeftEngine.RangeColor = System.Drawing.Color.LightGreen;
            this.aGauge_LeftEngine.RangeEnabled = false;
            this.aGauge_LeftEngine.RangeEndValue = 300F;
            this.aGauge_LeftEngine.RangeInnerRadius = 70;
            this.aGauge_LeftEngine.RangeOuterRadius = 80;
            this.aGauge_LeftEngine.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge_LeftEngine.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge_LeftEngine.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge_LeftEngine.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.aGauge_LeftEngine.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.aGauge_LeftEngine.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge_LeftEngine.RangeStartValue = -100F;
            this.aGauge_LeftEngine.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge_LeftEngine.ScaleLinesInterInnerRadius = 42;
            this.aGauge_LeftEngine.ScaleLinesInterOuterRadius = 50;
            this.aGauge_LeftEngine.ScaleLinesInterWidth = 2;
            this.aGauge_LeftEngine.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge_LeftEngine.ScaleLinesMajorInnerRadius = 40;
            this.aGauge_LeftEngine.ScaleLinesMajorOuterRadius = 54;
            this.aGauge_LeftEngine.ScaleLinesMajorStepValue = 70F;
            this.aGauge_LeftEngine.ScaleLinesMajorWidth = 2;
            this.aGauge_LeftEngine.ScaleLinesMinorColor = System.Drawing.Color.Black;
            this.aGauge_LeftEngine.ScaleLinesMinorInnerRadius = 43;
            this.aGauge_LeftEngine.ScaleLinesMinorNumOf = 3;
            this.aGauge_LeftEngine.ScaleLinesMinorOuterRadius = 50;
            this.aGauge_LeftEngine.ScaleLinesMinorWidth = 1;
            this.aGauge_LeftEngine.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge_LeftEngine.ScaleNumbersFormat = null;
            this.aGauge_LeftEngine.ScaleNumbersRadius = 62;
            this.aGauge_LeftEngine.ScaleNumbersRotation = 90;
            this.aGauge_LeftEngine.ScaleNumbersStartScaleLine = 1;
            this.aGauge_LeftEngine.ScaleNumbersStepScaleLines = 2;
            this.aGauge_LeftEngine.Size = new System.Drawing.Size(91, 100);
            this.aGauge_LeftEngine.TabIndex = 13;
            this.aGauge_LeftEngine.Text = "aGauge9";
            this.aGauge_LeftEngine.Value = 0F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 680);
            this.Controls.Add(this.aGauge1);
            this.Controls.Add(this.aGauge_RightEngine);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.aGauge11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.aGauge_LeftEngine);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_fps);
            this.Controls.Add(this.pBShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wifi Car";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBShow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEngineDown;
        private System.Windows.Forms.Button btnEngineUp;
        private System.Windows.Forms.Button btnEngineRight;
        private System.Windows.Forms.Button btnEngineLeft;
        private System.Windows.Forms.Button btnEngineStop;
        private System.Windows.Forms.Label label_fps;
        private System.Windows.Forms.PictureBox pBShow;
        private GlassButton buttonBackward;
        private GlassButton buttonRight;
        private GlassButton buttonLeft;
        private GlassButton buttonForward;
        private GlassButton buttonlaba;
        private System.Windows.Forms.GroupBox groupBox1;
        private UI.AGauge aGauge_LeftEngine;
        private AGauge aGauge11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private LedBulb ledVideoShow;
        private LedBulb ledLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundButton roundButton_Set;
        private RoundButton roundButton_CMD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private AGauge aGauge_RightEngine;
        private AGauge aGauge1;
        private RoundButton roundButton_start;
        private System.Windows.Forms.Label label4;
        private LedBulb ledLeida;
    }
}

