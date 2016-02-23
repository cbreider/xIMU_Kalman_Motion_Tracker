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
    public partial class MainForm: Form
    {
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
                Series seriesX = new Series();
                Series seriesY = new Series();
                Series seriesZ = new Series();
                int a = 0;
                int b = 0;
                foreach (xIMU imu in xIMUs)
                {
                    List<PlotData> plotdata = imu.DataGatherer.GetPlotData();
                    if (imu.xIMU_Nr == 0)
                    {
                        a = 0;
                        b = 1;
                    }
                    else if (imu.xIMU_Nr == 1)
                    {
                        a = 2;
                        b = 3;
                    }
                    //Thread[] threads = new Thread[plotdata.Count];
                    int i = 0;
                    foreach (PlotData data in plotdata)
                    {

                        /*if (data.Type == DataTypes.Accelerometer)
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
                        else if (data.Type == DataTypes.Magnetometer)
                        {
                            seriesX = ChartMagX.Series[0];
                            seriesY = ChartMagY.Series[0];
                            seriesZ = ChartMagZ.Series[0];
                        }*/
                        if (data.Type == DataTypes.LinearAcceleration)
                        {
                            seriesX = ChartLinAccX.Series[a];
                            seriesY = ChartLinAccY.Series[a];
                            seriesZ = ChartLinAccZ.Series[a];
                        }
                        else if (data.Type == DataTypes.LinearVelocity)
                        {
                            seriesX = ChartLinVelX.Series[a];
                            seriesY = ChartLinVelY.Series[a];
                            seriesZ = ChartLinVelZ.Series[a];
                        }
                        else if (data.Type == DataTypes.LinearPosition)
                        {
                            seriesX = ChartLinPosX.Series[a];
                            seriesY = ChartLinPosY.Series[a];
                            seriesZ = ChartLinPosZ.Series[a];
                        }
                        else if (data.Type == DataTypes.KalmanLinearAcceleration)
                        {
                            seriesX = ChartLinAccX.Series[b];
                            seriesY = ChartLinAccY.Series[b];
                            seriesZ = ChartLinAccZ.Series[b];
                        }
                        else if (data.Type == DataTypes.KalmanLinearVelocity)
                        {
                            seriesX = ChartLinVelX.Series[b];
                            seriesY = ChartLinVelY.Series[b];
                            seriesZ = ChartLinVelZ.Series[b];
                        }
                        else if (data.Type == DataTypes.KalmanLinearPosition)
                        {
                            seriesX = ChartLinPosX.Series[b];
                            seriesY = ChartLinPosY.Series[b];
                            seriesZ = ChartLinPosZ.Series[b];
                        }

                        /*else if (data.Type == DataTypes.LowPassFilteredAcc && LowPassChecked.Checked)
                        {
                            seriesX = ChartLinAccX.Series[2];
                            seriesY = ChartLinAccY.Series[2];
                            seriesZ = ChartLinAccZ.Series[2];
                        }*/

                        UpdateChart(seriesX, seriesY, seriesZ, data);
                    }
                }
                _clearSeries = false;

                foreach (Chart chart in Charts)
                {
                    chart.ChartAreas[0].AxisX.Maximum = _timerCounter;
                    chart.ChartAreas[0].AxisX.Minimum = _timerCounter - 2;
                }
            }
        }
        private void UpdateChart(Series chartX, Series chartY, Series chartZ, PlotData data)
        {
            float[] point = new float[3];
            float temTime = (float)_timerCounter;
            float interval = (float)_guiUpdateTimer.Interval / (1000 * data.DataToPlot.Count);

            while (data.DataToPlot.Count > 0)
            {
                temTime += interval;
                point = data.DataToPlot.Dequeue();
                if (point != null)
                {
                    if (_clearSeries)
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
    }
}
