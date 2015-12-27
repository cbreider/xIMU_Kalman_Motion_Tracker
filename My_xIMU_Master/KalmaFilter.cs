/*
Implematntation of Kalmanfilter
Author:
 * Christian Breiderhoff
 * 
 * Cologne University of Applied Sciences 
 *
 * December 2015
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;


namespace My_xIMU_Master
{
    public class KalmanFilter
    {
        private Matrix<float> _state;
        private Matrix<float> _transitionMatrix;
        private Matrix<float> _measurementMatrix;
        private Matrix<float> _processNoiseCovarianceMatrix;
        private Matrix<float> _measurementNoiseCovarianceMatrix;
        private Matrix<float> _errorCovarianceMatrix;
        private Matrix<float> _identityMatrix;
        private float _dt;
        private float _sigma;

        public KalmanFilter(float dt, float sigma)
        {
            this._dt = dt;
            _sigma = sigma;
            Init();          
        }
        
        private void Init()
        {
            _state = DenseMatrix.OfArray(new float[9, 1]);
            _state[0, 0] = 0f; // x-acc
            _state[1, 0] = 0f; // y-acc
            _state[2, 0] = 0f; // z-acc
            _state[3, 0] = 0f; // x-vel
            _state[4, 0] = 0f; // y-vel
            _state[5, 0] = 0f; // z-vel
            _state[6, 0] = 0f; // x-pos
            _state[7, 0] = 0f; // y-pos
            _state[8, 0] = 0f; // z-pos*/


            _transitionMatrix = DenseMatrix.OfArray(new float[,]
                    {
                         {1, 0, 0, 0, 0, 0, 0, 0, 0},  // acc, velocity, position
                         {0, 1, 0, 0, 0, 0, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0, 0, 0, 0},
                         {_dt, 0, 0, 1, 0, 0, 0, 0, 0},
                         {0, _dt, 0, 0, 1, 0, 0, 0, 0},  // x-pos, y-pos, x-velocity, y-velocity
                         {0, 0, _dt, 0, 0, 1, 0, 0, 0},
                         {0.5f * _dt *_dt, 0, 0, _dt, 0, 0, 1f, 0, 0},
                         {0, 0.5f * _dt *_dt, 0, 0, _dt, 0, 0, 1f, 0},
                         {0, 0, 0.5f * _dt *_dt, 0, 0, _dt, 0, 0, 1f},
                        /* {0, 0, 0, 0, 0, 0, 0, 0, 0,1,0 , 0},  // acc, velocity, position
                         {0, 0, 0, 0, 0, 0, 0, 0, 0,0,1 , 0},
                         {0, 0, 0, 0, 0, 0, 0, 0, 0,0,0 , 1},*/
                    });
            _measurementMatrix = DenseMatrix.OfArray(new float[,]
                    {
                         { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                         { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 1, 0, 0, 0, 0, 0, 0 }
                    });

           Matrix<float> G = DenseMatrix.OfArray(new float[,] {
                                                    { 1,
                                                    1,
                                                    1,
                                                    0.5f * _dt * _dt * _dt,
                                                    0.5f * _dt * _dt * _dt,
                                                    0.5f * _dt * _dt * _dt,
                                                    0.25f * _dt * _dt * _dt * _dt,
                                                    0.25f * _dt * _dt * _dt * _dt,
                                                    0.25f * _dt * _dt * _dt * _dt }
                                                    });

            G = G.Transpose();
            _processNoiseCovarianceMatrix = G * G.Transpose() * _sigma;
            _errorCovarianceMatrix = DenseMatrix.CreateIdentity(9) * _sigma;
            _measurementNoiseCovarianceMatrix = DenseMatrix.CreateIdentity(3) * _sigma;
            _identityMatrix = DenseMatrix.CreateIdentity(9);
        }
        public Matrix<float> PredictAndCorrect(Matrix<float> acc)
        {
            //Predict
            _state = _transitionMatrix * _state;
            _errorCovarianceMatrix = _transitionMatrix * _errorCovarianceMatrix * _transitionMatrix.Transpose() + _processNoiseCovarianceMatrix;

            //Correct
            var x = acc - (_measurementMatrix * _state);
            Matrix<float> S = _measurementMatrix * _processNoiseCovarianceMatrix * _measurementMatrix.Transpose() + _measurementNoiseCovarianceMatrix;
            Matrix<float> K = _processNoiseCovarianceMatrix * _measurementMatrix.Transpose() * S.Inverse();

            _state = _state + (K * x);
            _processNoiseCovarianceMatrix = (_identityMatrix - (K * _measurementMatrix)) * _processNoiseCovarianceMatrix;

            return _state;

        }
        public void Reset()
        {
            _state = DenseMatrix.OfArray(new float[9, 1]);
        }

        public void ReturnToZero()
        {
           _state[3, 0] = _state[4, 0] =_state[5, 0] = 0;
        }
    }
}
