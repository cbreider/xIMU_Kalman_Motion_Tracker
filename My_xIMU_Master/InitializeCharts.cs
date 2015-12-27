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
    public partial class MainForm:Form
    {
        private Chart ChartAccX = new Chart() { Name = "Accelerometer X" };
        private Chart ChartAccY = new Chart() { Name = "accelerometer Y" };
        private Chart ChartAccZ = new Chart() { Name = "Accelerometer Z" };

        private Chart ChartGyrX = new Chart() { Name = "Gyroscope X" };
        private Chart ChartGyrY = new Chart() { Name = "Gyroscope Y" };
        private Chart ChartGyrZ = new Chart() { Name = "Gyroscope Z" };

        private Chart ChartMagX = new Chart() { Name = "Magnetomter X" };
        private Chart ChartMagY = new Chart() { Name = "Magnetomter Y" };
        private Chart ChartMagZ = new Chart() { Name = "Magnetometer Z" };

        private Chart ChartLinAccX = new Chart() { Name = "Linear Acceleration X" };
        private Chart ChartLinAccY = new Chart() { Name = "Linear Acceleration Y" };
        private Chart ChartLinAccZ = new Chart() { Name = "Linear Acceleration Z" };

        private Chart ChartLinVelX = new Chart() { Name = "Linear Velocity X" };
        private Chart ChartLinVelY = new Chart() { Name = "Linear Velocity Y" };
        private Chart ChartLinVelZ = new Chart() { Name = "Linear Velocity Z" };

        private Chart ChartLinPosX = new Chart() { Name = "Linear Position X" };
        private Chart ChartLinPosY = new Chart() { Name = "Linear Position Y" };
        private Chart ChartLinPosZ = new Chart() { Name = "Linear Position Z" };

        private List<Chart> Charts = new List<Chart>();

        private void InitTabControl()
        {
            Charts.Add(ChartAccX);
            Charts.Add(ChartAccY);
            Charts.Add(ChartAccZ);
            Charts.Add(ChartGyrX);
            Charts.Add(ChartGyrY);
            Charts.Add(ChartGyrZ);
            Charts.Add(ChartMagX);
            Charts.Add(ChartMagY);
            Charts.Add(ChartMagZ);
            Charts.Add(ChartLinAccX);
            Charts.Add(ChartLinAccY);
            Charts.Add(ChartLinAccZ);
            Charts.Add(ChartLinVelX);
            Charts.Add(ChartLinVelY);
            Charts.Add(ChartLinVelZ);
            Charts.Add(ChartLinPosX);
            Charts.Add(ChartLinPosY);
            Charts.Add(ChartLinPosZ);

            int i = 0;
            foreach (Chart chart in Charts)
            {
                string name;
                foreach (xIMU imu in xIMUs)
                {                  
                    chart.Series.Add(new Series(chart.Name + imu.ID));
                    chart.Series[0].Color = Color.Red;
                    chart.Series[0].ChartType = SeriesChartType.FastLine;
                    
                    if (i >= 9)
                    {
                        name = "Kal. Est. " + chart.Name;
                        chart.Series.Add(new Series(name));
                        chart.Series[1].Color = Color.Green;
                        chart.Series[1].ChartType = SeriesChartType.FastLine;
                        if (i <= 11)
                        {
                            name = "LowPass filtered" + chart.Name;
                            chart.Series.Add(new Series(name));
                            chart.Series[2].Color = Color.Blue;
                            chart.Series[2].ChartType = SeriesChartType.FastLine;
                        }
                    }
                }

                chart.ChartAreas.Add(new ChartArea());
                chart.ChartAreas[0].AxisX.Title = "Time in s";
                chart.ChartAreas[0].AxisX.Maximum = 6;
                chart.ChartAreas[0].AxisX.Minimum = 0;
                chart.ChartAreas[0].AxisX.Interval = 0.5;
                chart.Legends.Add(new Legend());
                chart.Size = new System.Drawing.Size(780, 270);
                double[] MinMax = new double[2];

                    if (i < 3)
                    {
                        name = "Acceleration in g";
                        MinMax[0] = -4;
                        MinMax[1] = 4;
                    }
                    else if (i < 6)
                    {
                        name = "AngularVelocity in deg/s";
                        MinMax[0] = -90;
                        MinMax[1] = 90;
                    }
                    else if (i < 9)
                    {
                        name = "Magnetix flux density in Gauss";
                        MinMax[0] = -50;
                        MinMax[1] = 50;
                    }
                    else if (i < 12)
                    {
                        name = "Acceleration in m/s^2";
                        MinMax[0] = -8;
                        MinMax[1] = 8;
                    }
                    else if (i < 15)
                    {
                        name = "Velocity in m/s";
                        MinMax[0] = -8;
                        MinMax[1] = 8;
                    }
                    else
                    {
                        name = "Position in m";
                        MinMax[0] = -8;
                        MinMax[1] = 8;
                    }

                    chart.ChartAreas[0].AxisY.Title = name;
                    chart.ChartAreas[0].AxisY.Minimum = MinMax[0];
                    chart.ChartAreas[0].AxisY.Maximum = MinMax[1];


                    chart.Series[0].Points.AddXY(0, 0);
                    i++;
                }
            
            i = 0;
            foreach (TabPage page in tabControl1.TabPages)
            {
                page.Controls.Add(Charts[i]);
                Charts[i].Parent = page;
                Charts[i].Location = new Point(0, 0);
                Charts[i].Enabled = true;
                Charts[i].Visible = true;
                i++;
                page.Controls.Add(Charts[i]);
                Charts[i].Parent = page;
                Charts[i].Location = new Point(0, 270);
                Charts[i].Enabled = true;
                i++;
                page.Controls.Add(Charts[i]);
                Charts[i].Parent = page;
                Charts[i].Location = new Point(0, 540);
                Charts[i].Enabled = true;
                i++;
            }
        }
    }
}
