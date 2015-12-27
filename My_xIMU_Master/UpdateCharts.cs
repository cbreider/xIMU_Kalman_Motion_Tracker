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

                foreach (xIMU imu in xIMUs)
                {
                    List<PlotData> plotdata = imu.DataGatherer.GetPlotData();
                    Series seriesX = new Series();
                    Series seriesY = new Series();
                    Series seriesZ = new Series();
                    //Thread[] threads = new Thread[plotdata.Count];
                    int i = 0;
                    foreach (PlotData data in plotdata)
                    {

                        if (data.Type == DataTypes.Accelerometer)
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
                        }
                        else if (data.Type == DataTypes.LinearAcceleration)
                        {
                            seriesX = ChartLinAccX.Series[0];
                            seriesY = ChartLinAccY.Series[0];
                            seriesZ = ChartLinAccZ.Series[0];
                        }
                        else if (data.Type == DataTypes.LinearVelocity)
                        {
                            seriesX = ChartLinVelX.Series[0];
                            seriesY = ChartLinVelY.Series[0];
                            seriesZ = ChartLinVelZ.Series[0];
                        }
                        else if (data.Type == DataTypes.LinearPosition)
                        {
                            seriesX = ChartLinPosX.Series[0];
                            seriesY = ChartLinPosY.Series[0];
                            seriesZ = ChartLinPosZ.Series[0];
                        }
                        else if (data.Type == DataTypes.KalmanLinearAcceleration)
                        {
                            seriesX = ChartLinAccX.Series[1];
                            seriesY = ChartLinAccY.Series[1];
                            seriesZ = ChartLinAccZ.Series[1];
                        }
                        else if (data.Type == DataTypes.KalmanLinearVelocity)
                        {
                            seriesX = ChartLinVelX.Series[1];
                            seriesY = ChartLinVelY.Series[1];
                            seriesZ = ChartLinVelZ.Series[1];
                        }
                        else if (data.Type == DataTypes.KalmanLinearPosition)
                        {
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
