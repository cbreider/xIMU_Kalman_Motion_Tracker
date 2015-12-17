using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing.Drawing2D;

namespace My_xIMU_Master
    
{
    public enum DataTypes
    {
        Accelerometer,
        Gyroscope,
        Magnetometer,
        LinearAcceleration,
        LinearVelocity,
        LinearPosition,
        KalmanLinearAcceleration,
        KalmanLinearVelocity,
        KalmanLinearPosition,
        LowPassFilteredAcc
    }
    public class xIMUData
    {
        private float[] _currentMeasurement=new float[3];
        private Queue<float[]> _measurementOfLastMinute = new Queue<float[]>();
        private PlotData _plotData = new PlotData();
        
        public PlotData Plotdata
        {
            get { return _plotData; }
            set { _plotData = value; }
        }
        
        public float[] CurrentMeasurement
        {
            get { return _currentMeasurement; }
            set { _currentMeasurement = value; }
        }     
        public Matrix<float> CurrentMeasurementMatrix
        {
            get
            {
                return new Matrix<float>(new float[3, 1]{
                { _currentMeasurement[0] },
                {_currentMeasurement[1] },
                {_currentMeasurement[2] },});
            }
        }

        public Queue<float[]> MeasurementOfLastMinute
        {
            get { return _measurementOfLastMinute; }
            set { _measurementOfLastMinute = value; }
        }
        
    }
    public class PlotData: ICloneable
    {
        public DataTypes Type;
        private Queue<float[]> _dataToPlot = new Queue<float[]>();
        public Queue<float[]> DataToPlot
        {
            get { return _dataToPlot; }
            set { _dataToPlot = value; }

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class Accelerometer:xIMUData
    {
        
        public Accelerometer() { base.Plotdata.Type = DataTypes.Accelerometer; }
       
    }
    
    public class Gyroscope:xIMUData
    {
        public Gyroscope() { base.Plotdata.Type = DataTypes.Gyroscope; }

    }

    public class Magnetometer:xIMUData
    {
        public Magnetometer() { base.Plotdata.Type = DataTypes.Magnetometer; }

        
    }  
    public class LinearAcceleration:xIMUData
    {
        public LinearAcceleration() { base.Plotdata.Type = DataTypes.LinearAcceleration; }
    } 

    public class LinearVelocity:xIMUData
    {
        public LinearVelocity() { base.Plotdata.Type = DataTypes.LinearVelocity; }
    }

    public class LinearPosition:xIMUData
    {
        public LinearPosition() { base.Plotdata.Type = DataTypes.LinearPosition; }
    }

    public class KalmanEstLinearAcceleration:xIMUData
    {
        public KalmanEstLinearAcceleration() { base.Plotdata.Type = DataTypes.KalmanLinearAcceleration; }
    }

    public class KalmanEstLinearVelocity:xIMUData
    {
        public KalmanEstLinearVelocity() { base.Plotdata.Type = DataTypes.KalmanLinearVelocity; }
    }
    public class KalmanEstLinearPosition:xIMUData
    {
        public KalmanEstLinearPosition() { base.Plotdata.Type = DataTypes.KalmanLinearPosition; }
    }
    public class LowPassFilteredAcceleromter : xIMUData
    {
        public LowPassFilteredAcceleromter() { base.Plotdata.Type = DataTypes.LowPassFilteredAcc; }
    }
}
