using System;
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

        private System.Timers.Timer _guiUpdateTimer = new System.Timers.Timer();
        BackgroundWorker ChartWorker = new BackgroundWorker();
        private double _timerCounter;
        private bool _clearSeries;
        private float _timerSeries;
        private bool track;
        private bool _available;
        private bool calibrating;
        private MicroLibrary.MicroTimer microtimer;
 
        float X = 0;
        float Y = 0;
        float Z = 0;
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
            AviablePortsLable.Text = "No Ports aviable";
            SampleFreqLabel.Text = "----------";
            _available = false;
          
            ButtonOpen.Enabled = false;
            Start.Enabled = false;
            Stop.Enabled = false;

            _guiUpdateTimer.Interval = 100;
            _guiUpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateGUI);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(ThreeDPoseChart.OnKeyDown);

            SizeChanged += new System.EventHandler(MainForm_SizeChanged);
        
            InitTabControl();
        }
        #endregion

        #region Search for xIMUs on COM Ports

        //Werden aus einer BackgroundWorker instanz aufgerufen´, die beim Buttonereignis erstellt wird
        private void Search_for_xIMU(object sender, EventArgs e)
        {
            portAssignment = (new x_IMU_API.PortScanner(false, true)).Scan();
            if (portAssignment.Count() > 0)
            {
                _available = true;
            }
            else
            {
                _available = false;
            }
        }

        private void Search_finished(object sender, EventArgs e)
        {
            if (_available)
            {
                ButtonOpen.Enabled = true;
                AviablePortsLable.Text = "Aviable Ports:   " + portAssignment[0].PortName;
            }
            else
            {
                ButtonClose.Enabled = false;
                ButtonOpen.Enabled = false;
                AviablePortsLable.Text = "No xIMU aviable!";
            }
        }
        #endregion


        #region Connect
        private void Connect_to_xIMUs()
        {            
            xIMU_1 = new xIMU(portAssignment[0], 1, LowPassChecked.Checked);
            Status ConnectionState = xIMU_1.Connect();
            switch(ConnectionState)
            {
                case Status.Good:
                    ConStateLabel.Text = "Connected to x-IMU " + portAssignment[0].DeviceID + " on " + portAssignment[0].PortName + ".";
                    Stop.Enabled = true;
                    ButtonClose.Enabled = true;
                    break;
                case Status.Bad:
                    ConStateLabel.Text = "Connection failed!";
                    ButtonOpen.Enabled = true;
                    ButtonClose.Enabled = false;                   
                    break;
            }
            
            _timerCounter = 0;
            _clearSeries = false;
        }
        #endregion

        #region Update GUI
        private void UpdateGUI(object sender, System.Timers.ElapsedEventArgs e)
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

        private void UpdateCharts(/*object sender, DoWorkEventArgs e*/)
        {
            if (InvokeRequired)
            {
                u = new UpdateCallback(UpdateCharts);
                BeginInvoke(u);
            }
            else
            {
                SampleFreqLabel.Text = xIMU_1.DataGatherer.SampleFrequency.ToString();
               
                List<PlotData> plotdata= xIMU_1.DataGatherer.GetPlotData();
                Series seriesX = new Series();
                Series seriesY = new Series();
                Series seriesZ = new Series();
                //Thread[] threads = new Thread[plotdata.Count];
                int i = 0;
                foreach (PlotData data in plotdata)
                {
                   
                    if (data.Type==DataTypes.Accelerometer)
                    {
                        seriesX = ChartAccX.Series[0];
                        seriesY = ChartAccY.Series[0];
                        seriesZ = ChartAccZ.Series[0];
                    }
                    else if (data.Type == DataTypes.Gyroscope)
                    {
                        seriesX = ChartGyrX.Series[0];
                        seriesY = ChartGyrY.Series[0];
                        seriesZ = ChartGyrZ.Series[0];
                    }
                    else if (data.Type == DataTypes.Magnetometer) {
                        seriesX =  ChartMagX.Series[0];
                        seriesY = ChartMagY.Series[0];
                        seriesZ = ChartMagZ.Series[0];
                    }
                    else if (data.Type == DataTypes.LinearAcceleration) {
                        seriesX = ChartLinAccX.Series[0];
                        seriesY = ChartLinAccY.Series[0];
                        seriesZ = ChartLinAccZ.Series[0];
                    }
                    else if (data.Type == DataTypes.LinearVelocity) {
                        seriesX = ChartLinVelX.Series[0];
                        seriesY = ChartLinVelY.Series[0];
                        seriesZ = ChartLinVelZ.Series[0];
                            }
                    else if (data.Type == DataTypes.LinearPosition) {
                        seriesX = ChartLinPosX.Series[0];
                        seriesY = ChartLinPosY.Series[0];
                        seriesZ = ChartLinPosZ.Series[0];
                    }
                    else if (data.Type == DataTypes.KalmanLinearAcceleration) {
                        seriesX = ChartLinAccX.Series[1];
                        seriesY = ChartLinAccY.Series[1];
                        seriesZ = ChartLinAccZ.Series[1];
                    }
                    else if (data.Type == DataTypes.KalmanLinearVelocity) {
                        seriesX = ChartLinVelX.Series[1];
                        seriesY = ChartLinVelY.Series[1];
                        seriesZ = ChartLinVelZ.Series[1];
                    }
                    else if (data.Type == DataTypes.KalmanLinearPosition) {
                        seriesX = ChartLinPosX.Series[1];
                        seriesY = ChartLinPosY.Series[1];
                        seriesZ = ChartLinPosZ.Series[1];
                    }

                    else if (data.Type == DataTypes.LowPassFilteredAcc && LowPassChecked.Checked)
                    {
                        seriesX = ChartLinAccX.Series[2];
                        seriesY = ChartLinAccY.Series[2];
                        seriesZ = ChartLinAccZ.Series[2];
                    }
                   
                    UpdateChart(seriesX, seriesY, seriesZ, data);
                }
                _clearSeries = false;

                foreach (Chart chart in Charts)
                {
                    chart.ChartAreas[0].AxisX.Maximum = _timerCounter;
                    chart.ChartAreas[0].AxisX.Minimum = _timerCounter - 2;
                }
            }
        }
         private  void UpdateChart(Series chartX,Series chartY, Series chartZ, PlotData data)
        {
            float[] point = new float[3];
            float temTime = (float)_timerCounter;
            float interval = (float)_guiUpdateTimer.Interval / (1000 * data.DataToPlot.Count);

            while (data.DataToPlot.Count>0)
            {
                temTime += interval;
                point = data.DataToPlot.Dequeue();
                if (point != null)
                {
                    if(_clearSeries)
                    {
                        chartX.Points.Clear();
                        chartY.Points.Clear();
                        chartZ.Points.Clear();
                    }
                    chartX.Points.AddXY(temTime, point[0]);
                    chartY.Points.AddXY(temTime, point[1]);
                    chartZ.Points.AddXY(temTime, point[2]);
                }
            }
        }
        private void ChartUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void UpdateWPFChart()
        {
            X = xIMU_1.DataGatherer.KalEstLinPos.CurrentMeasurement[0] * 100;
            Y = xIMU_1.DataGatherer.KalEstLinPos.CurrentMeasurement[1]*100;
            Z = xIMU_1.DataGatherer.KalEstLinPos.CurrentMeasurement[2] * 100;
            zaehler++;
            ThreeDPoseChart.plot_next(X, Y, Z, zaehler, xIMU_1.DataGatherer.RotMatrix());        
        }
        #endregion

        #region Buttons
        private void B_Track_Click(object sender, EventArgs e)
        {
        }

        private void B_ScanForPorts_Click(object sender, EventArgs e)
        {
            AviablePortsLable.Text = "Searching for aviable COM Ports";
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
            _guiUpdateTimer.Elapsed -= new System.Timers.ElapsedEventHandler(UpdateGUI);
            if (xIMU_1 != null) xIMU_1.Close();

            //microtimer.MicroTimerElapsed -= new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(microtimer_tick);
            //microtimer.Enabled = false;

            Close();
            Application.Exit();
        }
        
        private void Button_Start_Click(object sender, EventArgs e)
        {          
            xIMU_1.StartTracking();
            //ChartWorker.DoWork += new DoWorkEventHandler(UpdateCharts);
            ChartWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ChartUpdateCompleted);
            Stop.Enabled = true;
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
