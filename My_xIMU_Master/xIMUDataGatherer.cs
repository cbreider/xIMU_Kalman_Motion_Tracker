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
using System.Drawing.Drawing2D;

namespace My_xIMU_Master
{
    public class xIMUDataGatherer
    {
        #region private fields
        private Accelerometer _accelerometer = new Accelerometer();
        private Gyroscope _gyroscope = new Gyroscope();
        private Magnetometer _magnetomter = new Magnetometer();
        private LinearAcceleration _linAcc = new LinearAcceleration();
        private LinearVelocity _linVel = new LinearVelocity();
        private LinearPosition _linPos = new LinearPosition();
        private KalmanEstLinearAcceleration _kalEstLinAcc = new KalmanEstLinearAcceleration();
        private KalmanEstLinearVelocity _kalEstLinVel = new KalmanEstLinearVelocity();
        private KalmanEstLinearPosition _kalEstLinPos = new KalmanEstLinearPosition();
        private LowPassFilteredAcceleromter _lowPAssAcc = new LowPassFilteredAcceleromter();
        private List<xIMUData> myData = new List<xIMUData>();
        

        private Matrix<float> linState = new Matrix<float>(9, 1);
        private Matrix<float> kalmanEstState = new Matrix<float>(9, 1);

        private Matrix<float> transitionMatrix;
        private float[] quaternion = new float[4];
       // private Matrix<float> roationMatrix;

        private float sampleFrequency;
        #endregion


        #region Constructor
        public xIMUDataGatherer(float sampleFreq)
        {
            

            this.sampleFrequency = sampleFreq;
            transitionMatrix = new Matrix<float>(new float[,]
                     {
                         {1, 0, 0, 0, 0, 0, 0, 0, 0},  // acc, velocity, position
                         {0, 1, 0, 0, 0, 0, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0, 0, 0, 0},
                         {1/sampleFrequency, 0, 0, 1, 0, 0, 0, 0, 0},
                         {0, 1/sampleFrequency, 0, 0, 1, 0, 0, 0, 0},  // x-pos, y-pos, x-velocity, y-velocity
                         {0, 0, 1/sampleFrequency, 0, 0, 1, 0, 0, 0},
                         {1/(2*sampleFrequency*sampleFrequency), 0, 0, 1/sampleFrequency, 0, 0, 1f, 0, 0},
                         {0, 1/(2*sampleFrequency*sampleFrequency), 0, 0, 1/sampleFrequency, 0, 0, 1f, 0},
                         {0, 0, 1/(2*sampleFrequency*sampleFrequency), 0, 0, 1/sampleFrequency, 0, 0, 1f},
                     });
            myData.Add(_accelerometer);
            myData.Add(_gyroscope);
            myData.Add(_magnetomter);
            myData.Add(_linAcc);
            myData.Add(_linVel);
            myData.Add(_linPos);
            myData.Add(_kalEstLinAcc);
            myData.Add(_kalEstLinVel);
            myData.Add(_kalEstLinPos);
            myData.Add(_lowPAssAcc);
        }
        #endregion

        #region Properties

        public Accelerometer Accerlerometer
        {
            get { return _accelerometer; }
            set { _accelerometer = value; }
        }
        public Gyroscope Gyroscope
        {
            get { return _gyroscope; }
            set { _gyroscope = value; }
        }
        public Magnetometer Magnetometer
        {
            get { return _magnetomter; }
            set { _magnetomter = value; }
        }

        public LinearAcceleration LinAcc
        {
            get { return _linAcc; }
            set { _linAcc = value; }
        }
        public LinearVelocity LinVel
        {
            get { return _linVel; }
            set { _linVel = value; }
        }
        public LinearPosition LinPos
        {
            get { return _linPos; }
            set { _linPos = value; }
        }

        public KalmanEstLinearAcceleration KalEstLinAcc
        {
            get { return _kalEstLinAcc; }
            set { _kalEstLinAcc = value; }
        }

        public KalmanEstLinearVelocity KalEstLinVel
        {
            get { return _kalEstLinVel; }
            set { _kalEstLinVel = value; }
        }

        public KalmanEstLinearPosition KalEstLinPos
        {
            get { return _kalEstLinPos; }
            set { _kalEstLinPos = value; }
        }
        public LowPassFilteredAcceleromter LowPAssAcc
        {
            get { return _lowPAssAcc; }
            set { _lowPAssAcc = value; }
        }


        #region Matrix  Properties

        public Matrix<float> LinState {get { return linState; } set { linState = value; }}
        public Matrix<float> KalmanEstState {get { return kalmanEstState; } set { kalmanEstState = value; }}


        public Matrix<float> TransitionMatrix {get { return transitionMatrix; } }

        public Matrix<float> RotationMatrix { get { return getRotationmatrix(); }/*  set { roationMatrix = value; }*/ }

        #endregion


        #region Array Porperties
        

        public float[] Quaternion {get { return quaternion; } set { quaternion = value; }}
     


        #endregion
        public float SampleFrequency
        {
            get { return sampleFrequency; }
            set { sampleFrequency = value; }
        }

        #endregion
        public void Update()
        {
            //_linAcc.CurrentMeasurement[0] = linState[0, 0];
            //_linAcc.CurrentMeasurement[1] = linState[1, 0];
            //_linAcc.CurrentMeasurement[2] = linState[2, 0];

            _linPos.CurrentMeasurement[0] = linState[6, 0];
            _linPos.CurrentMeasurement[1] = linState[7, 0];
            _linPos.CurrentMeasurement[2] = linState[8, 0];

            _linVel.CurrentMeasurement[0] = linState[3, 0];
            _linVel.CurrentMeasurement[1] = linState[4, 0];
            _linVel.CurrentMeasurement[2] = linState[5, 0];



            _kalEstLinPos.CurrentMeasurement[0] = kalmanEstState[6, 0];
            _kalEstLinPos.CurrentMeasurement[1] = kalmanEstState[7, 0];
            _kalEstLinPos.CurrentMeasurement[2] = kalmanEstState[8, 0];

            _kalEstLinVel.CurrentMeasurement[0] = kalmanEstState[3, 0];
            _kalEstLinVel.CurrentMeasurement[1] = kalmanEstState[4, 0];
            _kalEstLinVel.CurrentMeasurement[2] = kalmanEstState[5, 0];

            _kalEstLinAcc.CurrentMeasurement[0] = kalmanEstState[0, 0];
            _kalEstLinAcc.CurrentMeasurement[1] = kalmanEstState[1, 0];
            _kalEstLinAcc.CurrentMeasurement[2] = kalmanEstState[2, 0];

            
            foreach(xIMUData data in myData)
            {
                lock(data.Plotdata)
                {
                    
                        data.Plotdata.DataToPlot.Enqueue(new float[3] { data.CurrentMeasurement[0], data.CurrentMeasurement[1], data.CurrentMeasurement[2] } );
                    
                 //   data.MeasurementOfLastMinute.Enqueue(data.CurrentMeasurement);
                    //data.MeasurementOfLastMinute.Dequeue();
                }
            }


        }
        public List<PlotData> GetPlotData()
        {
            List<PlotData> _plotdataList = new List<PlotData>();
            foreach(xIMUData data in myData)
            {
                PlotData _plotdata = new PlotData();

                lock (data.Plotdata)
                {
                    while (data.Plotdata.DataToPlot.Count > 0)
                    {
                        _plotdata.DataToPlot.Enqueue(data.Plotdata.DataToPlot.Dequeue());
                    }
                    _plotdata.Type = data.Plotdata.Type;
                    _plotdataList.Add(_plotdata);
                    //data.Plotdata.DataToPlot.Clear();
                }
                
            }
            return _plotdataList;
        }

        public double[] RotMatrix()
        {
            float[] matrix = (new x_IMU_API.QuaternionData(quaternion)).ConvertToConjugate().ConvertToRotationMatrix();
            return new double[] {(double)matrix[0], (double)matrix[1] , (double)matrix[2],
            (double)matrix[3],(double)matrix[4],(double)matrix[5],
            (double)matrix[6], (double)matrix[7], (double)matrix[8]};
        }
        private Matrix<float> getRotationmatrix()
        {


            float[] matrix = (new x_IMU_API.QuaternionData(quaternion)).ConvertToConjugate().ConvertToRotationMatrix();
            return new Matrix<float>(new float[,]
            {
                    { matrix[0], matrix[1], matrix[2] },
                    { matrix[3], matrix[4], matrix[5] },
                    { matrix[6], matrix[7], matrix[8] }
            });

            /* float R11 = 1-2 *( quaternion[0] * quaternion[0] +   quaternion[1] * quaternion[1]);
             float R12 = 2 * (quaternion[1] * quaternion[2] - quaternion[0] * quaternion[3]);
             float R13 = 2 * (quaternion[1] * quaternion[3] + quaternion[0] * quaternion[2]);
             float R21 = 2 * (quaternion[1] * quaternion[2] + quaternion[0] * quaternion[3]);
             float R22 = 1-2 *( quaternion[3] * quaternion[3]  +  quaternion[1] * quaternion[1]);
             float R23 = 2 * (quaternion[2] * quaternion[3] - quaternion[0] * quaternion[1]);
             float R31 = 2 * (quaternion[1] * quaternion[3] - quaternion[0] * quaternion[2]);
             float R32 = 2 * (quaternion[2] * quaternion[3] + quaternion[0] * quaternion[1]);
             float R33 = 1-2 * (quaternion[1] * quaternion[1] +  quaternion[2] * quaternion[2]);*/



            /*  return new Matrix<float>(new float[,]
                   {
                      { R11, R12, R13 },
                      { R21, R22, R23 },
                      { R31, R32, R33 }
                   });*/

        }
    }
}