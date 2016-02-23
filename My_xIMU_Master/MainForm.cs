﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using x_IMU_API;

using System.Windows.Forms.DataVisualization.Charting;

namespace My_xIMU_Master
{
    public partial class MainForm : Form
    {
        delegate void UpdateCallback();
        delegate void delUpdateGUI();
        UpdateCallback u;

        #region Private Fields  and Methods
        private x_IMU_API.PortAssignment[] portAssignment;
        private xIMU xIMU_1;
        private xIMU xIMU_2;
        private List<xIMU> xIMUs = new List<xIMU>();

        private System.Windows.Forms.Timer _guiUpdateTimer = new System.Windows.Forms.Timer();
        BackgroundWorker ChartWorker = new BackgroundWorker();
        private double _timerCounter;
        private bool _clearSeries;
        private float _timerSeries;
        private bool track;
        private bool _available;
        private bool calibrating;
        private MicroLibrary.MicroTimer microtimer;
 
       
        int zaehler = 0;
        #endregion

        #region Init
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConStateLabel.Text = "Not Connected";
            AvailablePortsLabel.Text = "No Ports aviable";
            SampleFreqLabel.Text = ConStateLabel2.Text = AvailablePortsLabel2.Text = SamplefreqLabel2.Text = "-------------------";
            _available = false;

            

            ButtonOpen.Enabled = false;
            Start.Enabled = false;
            ButtonStart.Enabled = false;

            _guiUpdateTimer.Interval = 100;
            _guiUpdateTimer.Tick += new EventHandler(UpdateGUI);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(ThreeDPoseChart.OnKeyDown);

            SizeChanged += new System.EventHandler(MainForm_SizeChanged);

            InitTabs();
            
        }
        #endregion

        #region Search for xIMUs on COM Ports

        //Werden aus einer BackgroundWorker instanz aufgerufen´, die beim Buttonereignis erstellt wird
        private void Search_for_xIMU(object sender, EventArgs e)
        {
            portAssignment = (new x_IMU_API.PortScanner(false, true)).Scan();
        }

        private void Search_finished(object sender, EventArgs e)
        { 
          
            if (portAssignment.Count()==1)
            {
                AvailablePortsLabel.Text = "Avialable Ports:   " + portAssignment[0].PortName;
                ButtonClose.Enabled = false;
                ButtonOpen.Enabled = false;
                AvailablePortsLabel2.Text = "xIMU not available!";
            }
            else if(portAssignment.Count()==2)
            {
                AvailablePortsLabel2.Text = "Avialable Ports:   " + portAssignment[1].PortName;
                AvailablePortsLabel.Text = "Avialable Ports:   " + portAssignment[0].PortName;
                ButtonOpen.Enabled = true;
            }
           else
            {
                ButtonClose.Enabled = false;
                ButtonOpen.Enabled = false;
                AvailablePortsLabel2.Text = "xIMU not available!";
                AvailablePortsLabel.Text = "xIMU not available!";
            }            
        }
        #endregion


        #region Connect
        private void Connect_to_xIMUs()
        {            
            xIMU_1 = new xIMU(portAssignment[0], 1, LowPassChecked.Checked);
            xIMU_2 = new xIMU(portAssignment[1], 2, LowPassChecked.Checked);
            xIMUs.Add(xIMU_1);
            xIMUs.Add(xIMU_2);

            Status ConnectionState1 = xIMU_1.Connect();            
            if(ConnectionState1 == Status.Good)               
            {                   
                ConStateLabel.Text = "Connected to x-IMU " + xIMU_1.ID + " on " + xIMU_1.PortAssignment.PortName + ".";               
            }
            else
            {
                ConStateLabel.Text = "Connection failed!";
            }

            Status ConnectionState2 = xIMU_2.Connect();
            if (ConnectionState2 == Status.Good)
            {
                ConStateLabel2.Text = "Connected to x-IMU " + xIMU_2.ID + " on " + xIMU_2.PortAssignment.PortName + ".";
            }
            else
            {
                ConStateLabel2.Text = "Connection failed!";
            }

            if(ConnectionState1==Status.Good && ConnectionState2== Status.Good)
            {
                ButtonStart.Enabled = true;
                ButtonClose.Enabled = true;
                InitTabControl();

            }
            else
            {
                ButtonOpen.Enabled = true;
                ButtonClose.Enabled = false;
            }
            
            

            _timerCounter = 0;
            _clearSeries = false;
        }
        #endregion

        #region Update GUI
        private void UpdateGUI(object sender, EventArgs e)
        {
            _timerCounter += 0.1;
            if (_timerCounter%10 == 0)
            {
                _clearSeries = true;
            }
            //ChartWorker.RunWorkerAsync();
            UpdateCharts();
            UpdateWPFChart();
        }
        
        private void ChartUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void UpdateWPFChart()
        {
            zaehler++;
            ThreeDPoseChart.plot_next(xIMU_1.DataGatherer.KalEstLinPos.CurrentMeasurement, xIMU_2.DataGatherer.KalEstLinPos.CurrentMeasurement,
                zaehler, xIMU_1.DataGatherer.RotMatrix(), xIMU_1.DataGatherer.RotMatrix());        
        }
        #endregion

        #region Buttons
        private void B_Track_Click(object sender, EventArgs e)
        {
        }

        private void B_ScanForPorts_Click(object sender, EventArgs e)
        {
            AvailablePortsLabel.Text = "Searching for aviable COM Ports";
            AvailablePortsLabel2.Text = "Searching for aviable COM Ports";
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(Search_for_xIMU);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Search_finished);
            bw.RunWorkerAsync();         
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            Connect_to_xIMUs();
            B_ScanForPorts.Enabled = false;
            //timer1.Interval = 100;
            //timer1.Enabled = true;
          //  microtimer.Interval = 10000;
            //microtimer.Enabled = true;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            _guiUpdateTimer.Tick -= new EventHandler(UpdateGUI);
            if (xIMU_1 != null) xIMU_1.Close();

            //microtimer.MicroTimerElapsed -= new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(microtimer_tick);
            //microtimer.Enabled = false;

            Close();
            Application.Exit();
        }
        
        private void Button_Start_Click(object sender, EventArgs e)
        {          
            foreach(xIMU imu in xIMUs)
            {
                imu.StartTracking();
            }
            //ChartWorker.DoWork += new DoWorkEventHandler(UpdateCharts);
            ChartWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ChartUpdateCompleted);
            ButtonStart.Enabled = true;
            _guiUpdateTimer.Enabled = true;
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            xIMU_1.StopTracking();
            Start.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {       
        }

        private void button41_Click(object sender, EventArgs e)
        {
            xIMU_1.Reset_Pos();
            ThreeDPoseChart.Clear();
        }
        #endregion
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            tabControl1.Size = new Size((int)Math.Round(Width * 0.5) - 10, Size.Height - 40);
            tabControl1.Location = new Point(0, 0);

            elementHost1.Location = new Point((int)Math.Round(Width * 0.5) + 10, 200);
            elementHost1.Size = new Size((int)Math.Round(Width * 0.5) - 40, Height - 250);

            ConnectionConTab.Location = new Point((int)Math.Round(Width * 0.5) + 10, 0);
            ButtonClose.Location = new Point(ConnectionConTab.Location.X + ConnectionConTab.Width + 20, ConnectionConTab.Location.Y);
            foreach (TabPage page in tabControl1.TabPages)
            {
                for (int i = 0; i < 3; i++)
                {
                    page.Controls[i].Size = new Size(tabControl1.Width, (int)Math.Round((double)tabControl1.Height / 3));
                }
                page.Controls[0].Location = new Point(0, 0);
                page.Controls[1].Location = new Point(0, (int)Math.Round((double)tabControl1.Height / 3));
                page.Controls[2].Location = new Point(0, 2 * (int)Math.Round((double)tabControl1.Height / 3));
            }
        }

        private void LowPassChecked_CheckedChanged(object sender, EventArgs e)
        {
            xIMU_1.FilterChanged(LowPassChecked.Checked);
        }
    }
}
