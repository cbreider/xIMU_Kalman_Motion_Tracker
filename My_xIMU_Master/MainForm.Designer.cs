
namespace My_xIMU_Master

{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Start = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.B_Track = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button37 = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.SampleFreqLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ConStateLabel = new System.Windows.Forms.Label();
            this.AvailablePortsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.B_ScanForPorts = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.button148 = new System.Windows.Forms.Button();
            this.button149 = new System.Windows.Forms.Button();
            this.button150 = new System.Windows.Forms.Button();
            this.button151 = new System.Windows.Forms.Button();
            this.button152 = new System.Windows.Forms.Button();
            this.button153 = new System.Windows.Forms.Button();
            this.button154 = new System.Windows.Forms.Button();
            this.button155 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ConnectionConTab = new System.Windows.Forms.TabControl();
            this.TabConnectionCont = new System.Windows.Forms.TabPage();
            this.TabDataCont = new System.Windows.Forms.TabPage();
            this.labelFIlter = new System.Windows.Forms.Label();
            this.textBox_sampleFIlter = new System.Windows.Forms.TextBox();
            this.LowPassChecked = new System.Windows.Forms.CheckBox();
            this.TabTrackingCont = new System.Windows.Forms.TabPage();
            this.TabRecognitionCont = new System.Windows.Forms.TabPage();
            this.TabExportCont = new System.Windows.Forms.TabPage();
            this.TabAboutCont = new System.Windows.Forms.TabPage();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelAdress = new System.Windows.Forms.Label();
            this.labelInstitue = new System.Windows.Forms.Label();
            this.labelFH = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.AppName = new System.Windows.Forms.Label();
            this.ConStateLabel2 = new System.Windows.Forms.Label();
            this.AvailablePortsLabel2 = new System.Windows.Forms.Label();
            this.SamplefreqLabel2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ConnectionConTab.SuspendLayout();
            this.TabConnectionCont.SuspendLayout();
            this.TabDataCont.SuspendLayout();
            this.TabTrackingCont.SuspendLayout();
            this.TabAboutCont.SuspendLayout();
            this.SuspendLayout();
            this.ThreeDPoseChart = new _3D_Chart._3D_WPF_Chart();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 830);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage1.Size = new System.Drawing.Size(792, 804);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accerlerometer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 804);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gyroscope";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 804);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Magnetometer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 804);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Linear Acceleration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(792, 804);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Linear Velocity";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(792, 804);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Linear Position";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(127, 17);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(84, 59);
            this.Start.TabIndex = 13;
            this.Start.Text = "Stop DataStream";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Stop
            // 
            this.ButtonStart.Location = new System.Drawing.Point(16, 17);
            this.ButtonStart.Name = "Stop";
            this.ButtonStart.Size = new System.Drawing.Size(92, 59);
            this.ButtonStart.TabIndex = 12;
            this.ButtonStart.Text = "Start DataStream";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(91, 112);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(79, 36);
            this.button42.TabIndex = 11;
            this.button42.Text = "Correct SensorOffset";
            this.button42.UseVisualStyleBackColor = true;
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(167, 42);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(91, 65);
            this.button41.TabIndex = 10;
            this.button41.Text = "Reset";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // B_Track
            // 
            this.B_Track.Location = new System.Drawing.Point(33, 42);
            this.B_Track.Name = "B_Track";
            this.B_Track.Size = new System.Drawing.Size(92, 65);
            this.B_Track.TabIndex = 9;
            this.B_Track.Text = "Start PoseTracking";
            this.B_Track.UseVisualStyleBackColor = true;
            this.B_Track.Click += new System.EventHandler(this.B_Track_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(481, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(225, 93);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(88, 55);
            this.button37.TabIndex = 14;
            this.button37.Text = "Disconnect";
            this.button37.UseVisualStyleBackColor = true;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.Color.Salmon;
            this.ButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonClose.Location = new System.Drawing.Point(1514, 43);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(78, 113);
            this.ButtonClose.TabIndex = 8;
            this.ButtonClose.Text = "Close App";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(140, 93);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(79, 55);
            this.ButtonOpen.TabIndex = 7;
            this.ButtonOpen.Text = "Connect to xIMU";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // SampleFreqLabel
            // 
            this.SampleFreqLabel.AutoSize = true;
            this.SampleFreqLabel.Location = new System.Drawing.Point(119, 67);
            this.SampleFreqLabel.Name = "SampleFreqLabel";
            this.SampleFreqLabel.Size = new System.Drawing.Size(49, 13);
            this.SampleFreqLabel.TabIndex = 6;
            this.SampleFreqLabel.Text = "..............";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "SampleFrequency:";
            // 
            // ConStateLabel
            // 
            this.ConStateLabel.AutoSize = true;
            this.ConStateLabel.Location = new System.Drawing.Point(119, 39);
            this.ConStateLabel.Name = "ConStateLabel";
            this.ConStateLabel.Size = new System.Drawing.Size(70, 13);
            this.ConStateLabel.TabIndex = 4;
            this.ConStateLabel.Text = ".....................";
            // 
            // AviablePortsLable
            // 
            this.AvailablePortsLabel.AutoSize = true;
            this.AvailablePortsLabel.Location = new System.Drawing.Point(119, 7);
            this.AvailablePortsLabel.Name = "AviablePortsLable";
            this.AvailablePortsLabel.Size = new System.Drawing.Size(64, 13);
            this.AvailablePortsLabel.TabIndex = 3;
            this.AvailablePortsLabel.Text = "...................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connected to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available COM Ports:";
            // 
            // B_ScanForPorts
            // 
            this.B_ScanForPorts.Location = new System.Drawing.Point(10, 93);
            this.B_ScanForPorts.Name = "B_ScanForPorts";
            this.B_ScanForPorts.Size = new System.Drawing.Size(106, 55);
            this.B_ScanForPorts.TabIndex = 0;
            this.B_ScanForPorts.Text = "Scan for available Ports";
            this.B_ScanForPorts.UseVisualStyleBackColor = true;
            this.B_ScanForPorts.Click += new System.EventHandler(this.B_ScanForPorts_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.elementHost1.Location = new System.Drawing.Point(810, 200);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(775, 630);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = ThreeDPoseChart;
            // 
            // button148
            // 
            this.button148.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button148.BackgroundImage")));
            this.button148.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button148.Location = new System.Drawing.Point(1522, 274);
            this.button148.Name = "button148";
            this.button148.Size = new System.Drawing.Size(50, 25);
            this.button148.TabIndex = 18;
            this.button148.UseVisualStyleBackColor = true;
            // 
            // button149
            // 
            this.button149.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button149.BackgroundImage")));
            this.button149.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button149.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button149.Location = new System.Drawing.Point(1522, 212);
            this.button149.Name = "button149";
            this.button149.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button149.Size = new System.Drawing.Size(50, 25);
            this.button149.TabIndex = 17;
            this.button149.UseVisualStyleBackColor = true;
            // 
            // button150
            // 
            this.button150.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button150.BackgroundImage")));
            this.button150.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button150.Location = new System.Drawing.Point(1507, 242);
            this.button150.Name = "button150";
            this.button150.Size = new System.Drawing.Size(35, 25);
            this.button150.TabIndex = 16;
            this.button150.UseVisualStyleBackColor = true;
            // 
            // button151
            // 
            this.button151.BackColor = System.Drawing.Color.Transparent;
            this.button151.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button151.BackgroundImage")));
            this.button151.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button151.Location = new System.Drawing.Point(1548, 243);
            this.button151.Name = "button151";
            this.button151.Size = new System.Drawing.Size(35, 25);
            this.button151.TabIndex = 15;
            this.button151.UseVisualStyleBackColor = false;
            // 
            // button152
            // 
            this.button152.Location = new System.Drawing.Point(1479, 242);
            this.button152.Name = "button152";
            this.button152.Size = new System.Drawing.Size(22, 25);
            this.button152.TabIndex = 14;
            this.button152.Text = "+";
            this.button152.UseVisualStyleBackColor = true;
            // 
            // button153
            // 
            this.button153.Location = new System.Drawing.Point(1451, 243);
            this.button153.Name = "button153";
            this.button153.Size = new System.Drawing.Size(22, 25);
            this.button153.TabIndex = 13;
            this.button153.Text = "-";
            this.button153.UseVisualStyleBackColor = true;
            // 
            // button154
            // 
            this.button154.Location = new System.Drawing.Point(1451, 274);
            this.button154.Name = "button154";
            this.button154.Size = new System.Drawing.Size(50, 25);
            this.button154.TabIndex = 12;
            this.button154.Text = "-";
            this.button154.UseVisualStyleBackColor = true;
            // 
            // button155
            // 
            this.button155.Location = new System.Drawing.Point(1451, 214);
            this.button155.Name = "button155";
            this.button155.Size = new System.Drawing.Size(50, 25);
            this.button155.TabIndex = 11;
            this.button155.Text = "+";
            this.button155.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 98);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // ConnectionConTab
            // 
            this.ConnectionConTab.Controls.Add(this.TabConnectionCont);
            this.ConnectionConTab.Controls.Add(this.TabDataCont);
            this.ConnectionConTab.Controls.Add(this.TabTrackingCont);
            this.ConnectionConTab.Controls.Add(this.TabRecognitionCont);
            this.ConnectionConTab.Controls.Add(this.TabExportCont);
            this.ConnectionConTab.Controls.Add(this.TabAboutCont);
            this.ConnectionConTab.Location = new System.Drawing.Point(810, 0);
            this.ConnectionConTab.Name = "ConnectionConTab";
            this.ConnectionConTab.SelectedIndex = 0;
            this.ConnectionConTab.Size = new System.Drawing.Size(690, 190);
            this.ConnectionConTab.TabIndex = 20;
            // 
            // TabConnectionCont
            // 
            this.TabConnectionCont.Controls.Add(this.SamplefreqLabel2);
            this.TabConnectionCont.Controls.Add(this.AvailablePortsLabel2);
            this.TabConnectionCont.Controls.Add(this.ConStateLabel2);
            this.TabConnectionCont.Controls.Add(this.button37);
            this.TabConnectionCont.Controls.Add(this.label1);
            this.TabConnectionCont.Controls.Add(this.label2);
            this.TabConnectionCont.Controls.Add(this.AvailablePortsLabel);
            this.TabConnectionCont.Controls.Add(this.ConStateLabel);
            this.TabConnectionCont.Controls.Add(this.label5);
            this.TabConnectionCont.Controls.Add(this.SampleFreqLabel);
            this.TabConnectionCont.Controls.Add(this.ButtonOpen);
            this.TabConnectionCont.Controls.Add(this.B_ScanForPorts);
            this.TabConnectionCont.Location = new System.Drawing.Point(4, 22);
            this.TabConnectionCont.Name = "TabConnectionCont";
            this.TabConnectionCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabConnectionCont.Size = new System.Drawing.Size(682, 164);
            this.TabConnectionCont.TabIndex = 0;
            this.TabConnectionCont.Text = "Connections";
            this.TabConnectionCont.UseVisualStyleBackColor = true;
            // 
            // TabDataCont
            // 
            this.TabDataCont.Controls.Add(this.labelFIlter);
            this.TabDataCont.Controls.Add(this.textBox_sampleFIlter);
            this.TabDataCont.Controls.Add(this.LowPassChecked);
            this.TabDataCont.Controls.Add(this.button42);
            this.TabDataCont.Controls.Add(this.Start);
            this.TabDataCont.Controls.Add(this.ButtonStart);
            this.TabDataCont.Location = new System.Drawing.Point(4, 22);
            this.TabDataCont.Name = "TabDataCont";
            this.TabDataCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabDataCont.Size = new System.Drawing.Size(682, 164);
            this.TabDataCont.TabIndex = 1;
            this.TabDataCont.Text = "xIMU Data";
            this.TabDataCont.UseVisualStyleBackColor = true;
            // 
            // labelFIlter
            // 
            this.labelFIlter.AutoSize = true;
            this.labelFIlter.Location = new System.Drawing.Point(485, 22);
            this.labelFIlter.Name = "labelFIlter";
            this.labelFIlter.Size = new System.Drawing.Size(105, 13);
            this.labelFIlter.TabIndex = 16;
            this.labelFIlter.Text = "SampleRate for Filter";
            // 
            // textBox_sampleFIlter
            // 
            this.textBox_sampleFIlter.Location = new System.Drawing.Point(596, 19);
            this.textBox_sampleFIlter.Name = "textBox_sampleFIlter";
            this.textBox_sampleFIlter.Size = new System.Drawing.Size(47, 20);
            this.textBox_sampleFIlter.TabIndex = 15;
            // 
            // LowPassChecked
            // 
            this.LowPassChecked.AutoSize = true;
            this.LowPassChecked.ForeColor = System.Drawing.Color.Black;
            this.LowPassChecked.Location = new System.Drawing.Point(254, 21);
            this.LowPassChecked.Name = "LowPassChecked";
            this.LowPassChecked.Size = new System.Drawing.Size(180, 17);
            this.LowPassChecked.TabIndex = 14;
            this.LowPassChecked.Text = "LowPass Filter for Accelerometer";
            this.LowPassChecked.UseVisualStyleBackColor = true;
            this.LowPassChecked.CheckedChanged += new System.EventHandler(this.LowPassChecked_CheckedChanged);
            // 
            // TabTrackingCont
            // 
            this.TabTrackingCont.Controls.Add(this.button41);
            this.TabTrackingCont.Controls.Add(this.B_Track);
            this.TabTrackingCont.Location = new System.Drawing.Point(4, 22);
            this.TabTrackingCont.Name = "TabTrackingCont";
            this.TabTrackingCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabTrackingCont.Size = new System.Drawing.Size(682, 164);
            this.TabTrackingCont.TabIndex = 2;
            this.TabTrackingCont.Text = "GaitTracking";
            this.TabTrackingCont.UseVisualStyleBackColor = true;
            // 
            // TabRecognitionCont
            // 
            this.TabRecognitionCont.Location = new System.Drawing.Point(4, 22);
            this.TabRecognitionCont.Name = "TabRecognitionCont";
            this.TabRecognitionCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabRecognitionCont.Size = new System.Drawing.Size(682, 164);
            this.TabRecognitionCont.TabIndex = 3;
            this.TabRecognitionCont.Text = "GaitRecognition";
            this.TabRecognitionCont.UseVisualStyleBackColor = true;
            // 
            // TabExportCont
            // 
            this.TabExportCont.Location = new System.Drawing.Point(4, 22);
            this.TabExportCont.Name = "TabExportCont";
            this.TabExportCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabExportCont.Size = new System.Drawing.Size(682, 164);
            this.TabExportCont.TabIndex = 4;
            this.TabExportCont.Text = "Export";
            this.TabExportCont.UseVisualStyleBackColor = true;
            // 
            // TabAboutCont
            // 
            this.TabAboutCont.Controls.Add(this.labelAuthor);
            this.TabAboutCont.Controls.Add(this.labelAdress);
            this.TabAboutCont.Controls.Add(this.labelInstitue);
            this.TabAboutCont.Controls.Add(this.labelFH);
            this.TabAboutCont.Controls.Add(this.LabelVersion);
            this.TabAboutCont.Controls.Add(this.AppName);
            this.TabAboutCont.Controls.Add(this.pictureBox1);
            this.TabAboutCont.Controls.Add(this.pictureBox2);
            this.TabAboutCont.Location = new System.Drawing.Point(4, 22);
            this.TabAboutCont.Name = "TabAboutCont";
            this.TabAboutCont.Padding = new System.Windows.Forms.Padding(3);
            this.TabAboutCont.Size = new System.Drawing.Size(682, 164);
            this.TabAboutCont.TabIndex = 5;
            this.TabAboutCont.Text = "About";
            this.TabAboutCont.UseVisualStyleBackColor = true;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(168, 36);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(138, 13);
            this.labelAuthor.TabIndex = 25;
            this.labelAuthor.Text = "Author: Christian Breiderhoff";
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Location = new System.Drawing.Point(167, 129);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(196, 13);
            this.labelAdress.TabIndex = 24;
            this.labelAdress.Text = "Steinmüllerallee 1, 51643 Gummersbach";
            // 
            // labelInstitue
            // 
            this.labelInstitue.AutoSize = true;
            this.labelInstitue.Location = new System.Drawing.Point(168, 103);
            this.labelInstitue.Name = "labelInstitue";
            this.labelInstitue.Size = new System.Drawing.Size(207, 13);
            this.labelInstitue.TabIndex = 23;
            this.labelInstitue.Text = "Institu für Automatisierung und Industrial IT";
            // 
            // labelFH
            // 
            this.labelFH.AutoSize = true;
            this.labelFH.Location = new System.Drawing.Point(168, 77);
            this.labelFH.Name = "labelFH";
            this.labelFH.Size = new System.Drawing.Size(307, 13);
            this.labelFH.TabIndex = 22;
            this.labelFH.Text = "Cologne University of Applied Sciences, Campus Gummersbach";
            // 
            // LabelVersion
            // 
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.Location = new System.Drawing.Point(6, 36);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(81, 13);
            this.LabelVersion.TabIndex = 21;
            this.LabelVersion.Text = "Version: 0.1.0.0";
            // 
            // AppName
            // 
            this.AppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppName.Location = new System.Drawing.Point(3, 7);
            this.AppName.Name = "AppName";
            this.AppName.Size = new System.Drawing.Size(360, 23);
            this.AppName.TabIndex = 20;
            this.AppName.Text = "xIMU Gait-Tracking and Recognition Master";
            // 
            // ConStateLabel2
            // 
            this.ConStateLabel2.AutoSize = true;
            this.ConStateLabel2.Location = new System.Drawing.Point(266, 39);
            this.ConStateLabel2.Name = "ConStateLabel2";
            this.ConStateLabel2.Size = new System.Drawing.Size(35, 13);
            this.ConStateLabel2.TabIndex = 15;
            this.ConStateLabel2.Text = "label3";
            // 
            // AvailablePortsLabel2
            // 
            this.AvailablePortsLabel2.AutoSize = true;
            this.AvailablePortsLabel2.Location = new System.Drawing.Point(266, 7);
            this.AvailablePortsLabel2.Name = "AvailablePortsLabel2";
            this.AvailablePortsLabel2.Size = new System.Drawing.Size(35, 13);
            this.AvailablePortsLabel2.TabIndex = 16;
            this.AvailablePortsLabel2.Text = "label4";
            // 
            // SamplefreqLabel2
            // 
            this.SamplefreqLabel2.AutoSize = true;
            this.SamplefreqLabel2.Location = new System.Drawing.Point(266, 67);
            this.SamplefreqLabel2.Name = "SamplefreqLabel2";
            this.SamplefreqLabel2.Size = new System.Drawing.Size(35, 13);
            this.SamplefreqLabel2.TabIndex = 17;
            this.SamplefreqLabel2.Text = "label6";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 840);
            this.Controls.Add(this.ConnectionConTab);
            this.Controls.Add(this.button148);
            this.Controls.Add(this.button149);
            this.Controls.Add(this.button150);
            this.Controls.Add(this.button151);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.button152);
            this.Controls.Add(this.button153);
            this.Controls.Add(this.button154);
            this.Controls.Add(this.button155);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "My xIMU Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ConnectionConTab.ResumeLayout(false);
            this.TabConnectionCont.ResumeLayout(false);
            this.TabConnectionCont.PerformLayout();
            this.TabDataCont.ResumeLayout(false);
            this.TabDataCont.PerformLayout();
            this.TabTrackingCont.ResumeLayout(false);
            this.TabAboutCont.ResumeLayout(false);
            this.TabAboutCont.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private _3D_Chart._3D_WPF_Chart ThreeDPoseChart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_Track;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Label SampleFreqLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ConStateLabel;
        private System.Windows.Forms.Label AvailablePortsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_ScanForPorts;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button148;
        private System.Windows.Forms.Button button149;
        private System.Windows.Forms.Button button150;
        private System.Windows.Forms.Button button151;
        private System.Windows.Forms.Button button152;
        private System.Windows.Forms.Button button153;
        private System.Windows.Forms.Button button154;
        private System.Windows.Forms.Button button155;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl ConnectionConTab;
        private System.Windows.Forms.TabPage TabConnectionCont;
        private System.Windows.Forms.TabPage TabDataCont;
        private System.Windows.Forms.TabPage TabTrackingCont;
        private System.Windows.Forms.TabPage TabRecognitionCont;
        private System.Windows.Forms.TabPage TabExportCont;
        private System.Windows.Forms.TabPage TabAboutCont;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.Label labelInstitue;
        private System.Windows.Forms.Label labelFH;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Label AppName;
        private System.Windows.Forms.CheckBox LowPassChecked;
        private System.Windows.Forms.Label labelFIlter;
        private System.Windows.Forms.TextBox textBox_sampleFIlter;
        private System.Windows.Forms.Label AvailablePortsLabel2;
        private System.Windows.Forms.Label ConStateLabel2;
        private System.Windows.Forms.Label SamplefreqLabel2;
        //Charts

    }
}

