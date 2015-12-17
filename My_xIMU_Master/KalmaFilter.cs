using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;


namespace My_xIMU_Master
{
    public class KalmanFilter
    {
        private Kalman kal;
        public Matrix<float> state;
        public Matrix<float> myState;
        public Matrix<float> transitionMatrix;
        public Matrix<float> measurementMatrix;
        public Matrix<float> processNoise;
        public Matrix<float> measurementNoise;
        public Matrix<float> errorCovariancePost;

        public KalmanFilter()
        {
            myState = new Matrix<float>(9, 1);
            myState[0, 0] = 0f; // x-acc
            myState[1, 0] = 0f; // y-acc
            myState[2, 0] = 0f; // z-acc
                                 myState[3, 0] = 0f; // x-vel
                                 myState[4, 0] = 0f; // y-vel
                                 myState[5, 0] = 0f; // z-vel
                                 myState[6, 0] = 0f; // x-pos
                                 myState[7, 0] = 0f; // y-pos
                                 myState[8, 0] = 0f; // z-pos*/

             transitionMatrix = new Matrix<float>(new float[,]
                     {
                         {1, 0, 0, 0, 0, 0, 0, 0, 0},  // acc, velocity, position
                         {0, 1, 0, 0, 0, 0, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0, 0, 0, 0},
                         {1/256f, 0, 0, 1, 0, 0, 0, 0, 0},
                         {0, 1/256f, 0, 0, 1, 0, 0, 0, 0},  // x-pos, y-pos, x-velocity, y-velocity
                         {0, 0, 1/256f, 0, 0, 1, 0, 0, 0},
                         {1/131072f, 0, 0, 1/256f, 0, 0, 1f, 0, 0},
                         {0, 1/131072f, 0, 0, 1/256f, 0, 0, 1f, 0},
                         {0, 0, 1/131072f, 0, 0, 1/256f, 0, 0, 1f},
                        /* {0, 0, 0, 0, 0, 0, 0, 0, 0,1,0 , 0},  // acc, velocity, position
                         {0, 0, 0, 0, 0, 0, 0, 0, 0,0,1 , 0},
                         {0, 0, 0, 0, 0, 0, 0, 0, 0,0,0 , 1},*/
                     }); 
             measurementMatrix = new Matrix<float>(new float[,]
                     {
                         { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                         { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 1, 0, 0, 0, 0, 0, 0 }
                     });

         

            measurementMatrix.SetIdentity();
            processNoise = new Matrix<float>(9, 9); //Linked to the size of the transition matrix
            processNoise.SetIdentity(new MCvScalar(1.0e-4)); //The smaller the value the more resistance to noise 
           measurementNoise = new Matrix<float>(3, 3); //Fixed accordiong to input data 
            measurementNoise.SetIdentity(new MCvScalar(1.0e-3));
            errorCovariancePost = new Matrix<float>(9, 9); //Linked to the size of the transition matrix
            errorCovariancePost.SetIdentity();
            kal = new Kalman(9, 3, 0);
            
           
            kal.CorrectedState = myState;
            kal.TransitionMatrix = transitionMatrix;
            kal.MeasurementNoiseCovariance = measurementNoise;
            kal.ProcessNoiseCovariance = processNoise;
            kal.ErrorCovariancePost = errorCovariancePost;
            kal.MeasurementMatrix = measurementMatrix;
        }
        public Matrix<float> filterMyState(Matrix<float> acc)
        {
            /*myState[0, 0] = acc[0, 0];
            myState[1, 0] = acc[1, 0];
            myState[2, 0] = acc[2, 0];*/

            Matrix<float> prediction = kal.Predict();
                       
            Matrix<float> estimatedState = kal.Correct(acc);
            return estimatedState;

        }
     public void Reset()
        {
            kal.CorrectedState = myState = new Matrix<float>(9, 1);
        }

        public void ReturnToZero()
        {
            kal.CorrectedState[3, 0] = kal.CorrectedState[4, 0] = kal.CorrectedState[5, 0] = 0;
        }
    }
}
