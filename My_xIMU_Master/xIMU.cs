
/* xIMU Test Application
 * SensorData xIMU_APi,
 * MadgwickAHRS Algorithm,
 * Tracking
 * 
 * 
 * Author:
 * Christian Breiderhoff
 * 
 * Cologne University of Applied Sciences 
 *
 * September 2015
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using MathNet.Filtering;

namespace My_xIMU_Master
{
    public class xIMU
    {
        #region private fields
        private x_IMU_API.PortAssignment _portAssignment;
        private x_IMU_API.xIMUserial _xIMUSerial;
        private int _xIMU_Nr;
        private bool _filterState;
        private bool _available;
        private MotionCalculator _tracker;
        private MadgwickAHRS _ahrs;
        public xIMUDataGatherer DataGatherer;
      //  double[] coefficients = MathNet.Filtering.IIR.IirCoefficients.HighPass(256d, (2 * 0.1d) / (1 / 1 / 256d), 1 / 256d);
      ////  MathNet.Filtering.IIR.OnlineIirFilter myIIR_Filter;

        private System.Timers.Timer _sampleTimer = new System.Timers.Timer();
        private System.Timers.Timer _queueTimer = new System.Timers.Timer();
        // private MicroLibrary.MicroStopwatch stopwatch;
        //private MicroLibrary.MicroTimer periode_microtimer;

        private bool _isReady;
        private int _sampleCounter;
        #endregion

        public bool Available { get { return _available; } }
        public string ID { get { return _portAssignment.DeviceID ; } }
        public int xIMU_Nr { get { return _xIMU_Nr; } }
        public string Port { get { return _portAssignment.PortName; } }       
        public Status ConnectionState { get { if (_xIMUSerial.IsOpen) { return Status.Connected; } else { return Status.Disconnected; } } }
        public x_IMU_API.xIMUserial XIMUSerial { get { return _xIMUSerial; } }
        public bool Filterstate { get { return _filterState; } }

        //public float Interval { get { return interval; } }

        public xIMU(x_IMU_API.PortAssignment portAssignment, int xIMU_Nr, bool filter)           
        {            
            this._portAssignment = portAssignment;
            this._xIMU_Nr = xIMU_Nr;
            this._filterState = filter;       
        }

        private void Init()
        {
            _xIMUSerial = new x_IMU_API.xIMUserial(_portAssignment.PortName);
            DataGatherer = new xIMUDataGatherer(256f);

            _ahrs = new MadgwickAHRS(1f / 256f, 0.1f);
            _tracker = new MotionCalculator(this);
            _tracker.FilterStateChanged(_filterState);    
        }

        public Status Connect()
        {
            try
            {
                _xIMUSerial.Open();
                return Status.Good;
            }
            catch (Exception e)
            {
                return Status.Bad;
            }
        }
        public Status Disconnect()
        {
            try
            {
                _xIMUSerial.Close();
                return Status.Good;
            }
            catch
            {
                return Status.Bad;
            }
        }

        public void StartTracking()
        {
            _isReady = true;
            _sampleTimer.Interval = 1000;            
            _sampleCounter = 0;
            _sampleTimer.Elapsed += new System.Timers.ElapsedEventHandler(sample_frequency);
            _sampleTimer.Enabled = true;
            // myIIR_Filter = new MathNet.Filtering.IIR.OnlineIirFilter(coefficients);
            //periode_microtimer.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(periode_microtimer_tick);*/
            _xIMUSerial.CalInertialAndMagneticDataReceived += new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMU_Update);          
        }

        public void StopTracking()
        {
            _xIMUSerial.CalInertialAndMagneticDataReceived -= new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMU_Update);
            _sampleTimer.Enabled = false;
        }
        private void xIMU_Update(object sender1, x_IMU_API.CalInertialAndMagneticData e1)
        {
            if (_isReady)
            {
                _isReady = false;

                _ahrs.Update(deg2rad(e1.Gyroscope[0]), deg2rad(e1.Gyroscope[1]), deg2rad(e1.Gyroscope[2]),
                  e1.Accelerometer[0], e1.Accelerometer[1], e1.Accelerometer[2], e1.Magnetometer[0], e1.Magnetometer[1], e1.Magnetometer[2], 1 / 256f);
                //AHRS.Update(deg2rad(e1.Gyroscope[0]), deg2rad(e1.Gyroscope[1]), deg2rad(e1.Gyroscope[2]), e1.Accelerometer[0], e1.Accelerometer[1], e1.Accelerometer[2], time);
                
                //Update Current Measurmets
                DataGatherer.Accerlerometer.CurrentMeasurement = e1.Accelerometer;
                DataGatherer.Gyroscope.CurrentMeasurement = e1.Gyroscope;
                DataGatherer.Magnetometer.CurrentMeasurement = e1.Magnetometer;
                DataGatherer.Quaternion = _ahrs.Quaternion;
                              
                //base.FilteredAcc = myIIR_Filter.ProcessSamples(new double[3] { (double)e1.Accelerometer[0], (double)e1.Accelerometer[1], (double)e1.Accelerometer[0] });
                _tracker.Start_Calculation();                
                _sampleCounter++;
                _isReady = true;
            }
        }
        
        static float deg2rad(float degrees)
        {
            return (float)(Math.PI / 180) * degrees;
        }

      
        private void sample_frequency(object sender, System.Timers.ElapsedEventArgs timerEventArgs)
        {
            DataGatherer.SampleFrequency =  _sampleCounter;
            _sampleCounter = 0;
        }

        public void FilterChanged(bool filter)
        {
            _tracker.FilterStateChanged(filter);
        }
        public void Reset_Vel() { _tracker.Velocity_Reset(); }
        public void Reset_Pos() { _tracker.Position_Reset(); }
        public void Close() { _xIMUSerial.Close(); }
    }
}
