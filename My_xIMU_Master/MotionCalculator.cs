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
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace My_xIMU_Master
{
    public class MotionCalculator
    {
        private xIMU xIMU;
        private float gravity = (float)9.81;
        private int counter = 0;
        private static KalmanFilter myKalmanFilter;

        //private float time = new float();
        //private float periode= new float();

        private float magnituide;
        private float[] magnitudes;
        private float average_magnitude;
        private float varianz;

        private Queue<float[]> _lowpassFilterQueue = new Queue<float[]>();
        private bool _shouldIfilter;
     
        public MotionCalculator(xIMU xIMU)
        {
            this.xIMU = xIMU;
            magnituide = new float();
            magnitudes = new float[] { 0, 0, 0, 0, 0 };      
        }

        private void Init()
        {
            myKalmanFilter = new KalmanFilter(xIMU.SamplePeriode, 10f);
        }
        public void Start_Calculation()
        {            
            Calculate_LinPos();
        }

        
        private void Calculate_LinPos()
        {
            Matrix<float> temp;
            temp = xIMU.DataGatherer.RotationMatrix * xIMU.DataGatherer.Accerlerometer.CurrentMeasurementMatrix;
            // kalmanTcAcc = MultiplyMatrixVector(rotationMatrix, kalmanAccerleration);                 

            xIMU.DataGatherer.LinAcc.CurrentMeasurement[0] = temp[0, 0] * gravity;
            xIMU.DataGatherer.LinAcc.CurrentMeasurement[1] = temp[1, 0] * gravity;
            xIMU.DataGatherer.LinAcc.CurrentMeasurement[2] = (temp[2, 0] - 1) * gravity;
         /*   if (_shouldIfilter)
            {
                _lowpassFilterQueue.Enqueue(xIMU.DataGatherer.LinAcc.CurrentMeasurement);
                if (_lowpassFilterQueue.Count >= 60)
                {

                    float[] filteredSample = new float[3];
                    foreach (float[] sample in _lowpassFilterQueue)
                    {
                        filteredSample[0] += sample[0];
                        filteredSample[1] += sample[1];
                        filteredSample[2] += sample[2];

                    }
                    filteredSample[0] /= 60;
                    filteredSample[1] /= 60;
                    filteredSample[2] /= 60;

                    xIMU.DataGatherer.LowPAssAcc.CurrentMeasurement = filteredSample;

                    _lowpassFilterQueue.Dequeue();
                }
               
                xIMU.DataGatherer.KalmanEstState = myKalmanFilter.filterMyState(xIMU.DataGatherer.LowPAssAcc.CurrentMeasurementMatrix);
            }
            else
            {*/
                xIMU.DataGatherer.KalmanEstState = myKalmanFilter.PredictAndCorrect(xIMU.DataGatherer.LinAcc.CurrentMeasurementMatrix);
           // }

            magnituide = (xIMU.DataGatherer.LinAcc.CurrentMeasurement[0] * xIMU.DataGatherer.LinAcc.CurrentMeasurement[0]) 
                + (xIMU.DataGatherer.LinAcc.CurrentMeasurement[1] * xIMU.DataGatherer.LinAcc.CurrentMeasurement[1]) 
                + (xIMU.DataGatherer.LinAcc.CurrentMeasurement[2] * xIMU.DataGatherer.LinAcc.CurrentMeasurement[2]);
            if (counter < 5)
            {
                counter++;
                magnitudes[(int)counter - 1] = magnituide;
            }
            if (counter == 5)
            {
                average_magnitude = (magnitudes[0] + magnitudes[1] + magnitudes[2] + magnitudes[3] + magnitudes[4]) / 5;
                varianz = (magnituide - average_magnitude) * (magnituide - average_magnitude);
                for (int i = 0; i == 3; i++)
                {
                    varianz += (magnitudes[i] - average_magnitude) * (magnitudes[i] - average_magnitude);
                }
                varianz /= 6;
                if (varianz < 0.00007)
                {
                    xIMU.DataGatherer.LinState[3, 0] = 0;
                    xIMU.DataGatherer.LinState[4, 0] = 0;
                    xIMU.DataGatherer.LinState[5, 0] = 0;
                    myKalmanFilter.ReturnToZero();

                }
                counter = 0;
            }

            xIMU.DataGatherer.LinState[0, 0] = xIMU.DataGatherer.KalmanEstState[0, 0];
            xIMU.DataGatherer.LinState[1, 0] = xIMU.DataGatherer.KalmanEstState[1, 0];
            xIMU.DataGatherer.LinState[2, 0] = xIMU.DataGatherer.KalmanEstState[2, 0];
            xIMU.DataGatherer.LinState = xIMU.DataGatherer.TransitionMatrix * xIMU.DataGatherer.LinState;

            xIMU.DataGatherer.Update();
        }
       
        public float[] MultiplyMatrixVector(float[,] a, float[] b)
        {
            float[] c = new float[a.GetLength(0)];
            if (a.GetLength(1) == b.GetLength(0))
            {

                for (int i = 0; i < c.GetLength(0); i++)
                {
                    c[i] = 0;
                    for (int k = 0; k < a.GetLength(1); k++) // OR k<b.GetLength(0)
                        c[i] = c[i] + a[i, k] * b[k];
                }
            }
            return c;
        }

        public void Position_Reset()
        {
            xIMU.DataGatherer.LinState = DenseMatrix.OfArray(new float[,]{ { 0},{ 0},{ 0},{ 0},{ 0},{ 0},{ 0},{ 0},{ 0} }); 
            myKalmanFilter.Reset();           
        }
        public void Velocity_Reset()
        {
            xIMU.DataGatherer.LinState[3, 0] = 0; xIMU.DataGatherer.LinState[4, 0] = 0; xIMU.DataGatherer.LinState[5, 0] = 0;
            myKalmanFilter.ReturnToZero();
        }
        public void FilterStateChanged(bool filter)
        {
            _shouldIfilter = filter;
        }
    }
}
