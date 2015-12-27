using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFChart3D;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System;
using System.Collections;

namespace My_xIMU_Master._3D_Chart
{
    /// <summary>
    /// Interaktionslogik für _3D_WPF_Chart.xaml
    /// </summary>
    public partial class _3D_WPF_Chart : UserControl
    {
        // transform class object for rotate the 3d model
        public WPFChart3D.TransformMatrix m_transformMatrix = new WPFChart3D.TransformMatrix();

        // ***************************** 3d chart ***************************
        private WPFChart3D.Chart3D m_3dChart;       // data for 3d chart
        public int m_nChartModelIndex = -1;         // model index in the Viewport3d
        public int m_nSurfaceChartGridNo = 100;     // surface chart grid no. in each axis
        public int m_nScatterPlotDataNo = 5000;     // total data number of the scatter plot
        public int dataN = 0;
        public bool _lock = false;
        // ***************************** selection rect ***************************
        ViewportRect m_selectRect = new ViewportRect();
        public int m_nRectModelIndex = -1;
        public _3D_WPF_Chart()
        {
            InitializeComponent();
            // selection rect
            m_selectRect.SetRect(new Point(-0.5, -0.5), new Point(-0.5, -0.5));
            WPFChart3D.Model3D model3d = new WPFChart3D.Model3D();
            ArrayList meshs = m_selectRect.GetMeshes();
            m_nRectModelIndex = model3d.UpdateModel(meshs, null, m_nRectModelIndex, this.mainViewport);

            // display the 3d chart data no.
            //   Control.KeyDown += new System.Windows.Input.KeyEventHandler(OnKeyDown);
            // display surface chart
            InitChart();
            //TransformChart();
        }

        public void Clear()
        {
            ((ScatterChart3D)m_3dChart).Clear();

        }
        private void InitChart()
        {
            m_3dChart = new ScatterChart3D();
            m_3dChart.SetDataNo(dataN);

            // 2. set the properties of each dot
            Random randomObject = new Random();
            int nDataRange = 1;
            ((ScatterChart3D)m_3dChart).Clear();

            ScatterPlotItem plotItem = new ScatterPlotItem();
            ScatterPlotItem plotItem1 = new ScatterPlotItem();
            ScatterPlotItem plotItem2 = new ScatterPlotItem();

            plotItem.rotmatrix = plotItem1.rotmatrix = plotItem2.rotmatrix = new double[9] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };

            plotItem.w = plotItem1.w = plotItem2.w = 1;
            plotItem.h = plotItem1.h = plotItem2.h = 30;

            plotItem.x = plotItem1.x = plotItem2.x = 0;
            plotItem.y = plotItem1.y = plotItem2.y = 0;
            plotItem.z = plotItem1.z = plotItem2.z = 0;

            plotItem.shape = plotItem1.shape = plotItem2.shape = (int)Chart3D.SHAPE.CYLINDER;

            plotItem.type = 1;
            plotItem1.type = 2;
            plotItem2.type = 3;

            plotItem.color = Color.FromRgb((Byte)0, (Byte)0, (Byte)255);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, plotItem);
            plotItem1.color = Color.FromRgb((Byte)0, (Byte)255, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, plotItem1);
            plotItem2.color = Color.FromRgb((Byte)255, (Byte)0, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, plotItem2);

            // 3. set axes
            m_3dChart.GetDataRange();
            m_3dChart.SetAxes();

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = ((ScatterChart3D)m_3dChart).GetMeshes();

            // 5. display vertex no and triangle no.
            //UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            WPFChart3D.Model3D model3d = new WPFChart3D.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix
            if (!_lock)
            {
                float viewRange = (float)nDataRange;
                m_transformMatrix.CalculateProjectionMatrix(-200, 200, -200, 200,-100, 200, 2);
                TransformChart();
            }
        }
        // function for set a scatter plot, every dot is just a simple pyramid.
        

        public void plot_next(float[] xIMU1_Acc, float[] xIMU2_Acc, int i, double[] xIMU1_rotmatrix, double[] xIMU2_rotmatrix)
        {
            dataN++;
            m_3dChart.SetDataNo(dataN);

            // 2. set the properties of each dot
            Random randomObject = new Random();
            int nDataRange = dataN ;
            ((ScatterChart3D)m_3dChart).Clear();

            //xIMu1
            ScatterPlotItem xIMU1_plotItem1 = new ScatterPlotItem();
            ScatterPlotItem xIMU1_plotItem2 = new ScatterPlotItem();
            ScatterPlotItem xIMU1_plotItem3 = new ScatterPlotItem();

            xIMU1_plotItem1.rotmatrix =xIMU1_plotItem2.rotmatrix=xIMU1_plotItem3.rotmatrix= xIMU1_rotmatrix;
       
            xIMU1_plotItem1.w=xIMU1_plotItem2.w=xIMU1_plotItem3.w = 1;
            xIMU1_plotItem1.h=xIMU1_plotItem2.h=xIMU1_plotItem3.h = 30;

            xIMU1_plotItem1.x =xIMU1_plotItem2.x=xIMU1_plotItem3.x= xIMU1_Acc[0];
            xIMU1_plotItem1.y =xIMU1_plotItem2.y=xIMU1_plotItem3.y= xIMU1_Acc[1];
            xIMU1_plotItem1.z =xIMU1_plotItem2.z=xIMU1_plotItem3.z= xIMU1_Acc[2];
           
            xIMU1_plotItem1.shape = xIMU1_plotItem2.shape=xIMU1_plotItem3.shape=(int)Chart3D.SHAPE.CYLINDER;

            xIMU1_plotItem1.type = 1;
            xIMU1_plotItem2.type = 2;
            xIMU1_plotItem3.type = 3;
           
            xIMU1_plotItem1.color = Color.FromRgb((Byte)0, (Byte)0, (Byte)255);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem1);
            xIMU1_plotItem2.color = Color.FromRgb((Byte)0, (Byte)255, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem2);
            xIMU1_plotItem3.color = Color.FromRgb((Byte)255, (Byte)0, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem3);

            //xIMU2
            ScatterPlotItem xIMU2_plotItem1 = new ScatterPlotItem();
            ScatterPlotItem xIMU2_plotItem2 = new ScatterPlotItem();
            ScatterPlotItem xIMU2_plotItem3 = new ScatterPlotItem();

            xIMU2_plotItem1.rotmatrix = xIMU2_plotItem2.rotmatrix = xIMU2_plotItem3.rotmatrix = xIMU2_rotmatrix;

            xIMU2_plotItem1.w = xIMU2_plotItem2.w = xIMU2_plotItem3.w = 1;
            xIMU2_plotItem1.h = xIMU2_plotItem2.h = xIMU2_plotItem3.h = 30;

            xIMU2_plotItem1.x = xIMU2_plotItem2.x = xIMU2_plotItem3.x = xIMU2_Acc[0];
            xIMU2_plotItem1.y = xIMU2_plotItem2.y = xIMU2_plotItem3.y = xIMU2_Acc[1];
            xIMU2_plotItem1.z = xIMU2_plotItem2.z = xIMU2_plotItem3.z = xIMU2_Acc[2];

            xIMU2_plotItem1.shape = xIMU2_plotItem2.shape = xIMU2_plotItem3.shape = (int)Chart3D.SHAPE.CYLINDER;

            xIMU2_plotItem1.type = 1;
            xIMU2_plotItem2.type = 2;
            xIMU2_plotItem3.type = 3;

            xIMU2_plotItem1.color = Color.FromRgb((Byte)0, (Byte)0, (Byte)255);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem1);
            xIMU2_plotItem2.color = Color.FromRgb((Byte)0, (Byte)255, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem2);
            xIMU2_plotItem3.color = Color.FromRgb((Byte)255, (Byte)0, (Byte)0);
            ((ScatterChart3D)m_3dChart).SetVertex(dataN, xIMU1_plotItem3);
            // 3. set axes
            m_3dChart.GetDataRange();
            m_3dChart.SetAxes();

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = ((ScatterChart3D)m_3dChart).GetMeshes();

            // 5. display vertex no and triangle no.
            //UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            WPFChart3D.Model3D model3d = new WPFChart3D.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix
            if(!_lock)
            {
               float viewRange = (float)nDataRange;           
              m_transformMatrix.CalculateProjectionMatrix(0, 200, 0,200, 0, 200, 1);
                TransformChart();
            }
        }

        public void OnViewportMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)         // rotate or drag 3d model
            {
                m_transformMatrix.OnLBtnDown(pt);
            }
            else if (args.ChangedButton == MouseButton.Right)   // select rect
            {
                m_selectRect.OnMouseDown(pt, mainViewport, m_nRectModelIndex);
            }
        }

        public void OnViewportMouseMove(object sender, System.Windows.Input.MouseEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);

            if (args.LeftButton == MouseButtonState.Pressed)                // rotate or drag 3d model
            {
                m_transformMatrix.OnMouseMove(pt, mainViewport);

                TransformChart();
            }
            else if (args.RightButton == MouseButtonState.Pressed)          // select rect
            {
                m_selectRect.OnMouseMove(pt, mainViewport, m_nRectModelIndex);
            }
            else
            {
                /*
                String s1;
                Point pt2 = m_transformMatrix.VertexToScreenPt(new Point3D(0.5, 0.5, 0.3), mainViewport);
                s1 = string.Format("Screen:({0:d},{1:d}), Predicated: ({2:d}, H:{3:d})", 
                    (int)pt.X, (int)pt.Y, (int)pt2.X, (int)pt2.Y);
                this.statusPane.Text = s1;
                */
            }
        }

        public void OnViewportMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)
            {
                m_transformMatrix.OnLBtnUp();
            }
            else if (args.ChangedButton == MouseButton.Right)
            {
                if (m_nChartModelIndex == -1) return;
                // 1. get the mesh structure related to the selection rect
                MeshGeometry3D meshGeometry = WPFChart3D.Model3D.GetGeometry(mainViewport, m_nChartModelIndex);
                if (meshGeometry == null) return;

                // 2. set selection in 3d chart
                m_3dChart.Select(m_selectRect, m_transformMatrix, mainViewport);

                // 3. update selection display
                m_3dChart.HighlightSelection(meshGeometry, Color.FromRgb(200, 200, 200));
            }
        }

        // zoom in 3d display
        public void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs args)
        {
            if(args.KeyCode== System.Windows.Forms.Keys.Space)
            {
                _lock = !_lock;

            }
            m_transformMatrix.OnKeyDown(args);
            TransformChart();
        }

       

        

        private void UpdateModelSizeInfo(ArrayList meshs)
        {
            int nMeshNo = meshs.Count;
            int nChartVertNo = 0;
            int nChartTriangelNo = 0;
            for (int i = 0; i < nMeshNo; i++)
            {
                nChartVertNo += ((Mesh3D)meshs[i]).GetVertexNo();
                nChartTriangelNo += ((Mesh3D)meshs[i]).GetTriangleNo();
            }
         
        }

        // this function is used to rotate, drag and zoom the 3d chart
        private void TransformChart()
        {
            if (m_nChartModelIndex == -1) return;
            ModelVisual3D visual3d = (ModelVisual3D)(this.mainViewport.Children[m_nChartModelIndex]);
            if (visual3d.Content == null) return;
            Transform3DGroup group1 = visual3d.Content.Transform as Transform3DGroup;
            group1.Children.Clear();
            group1.Children.Add(new MatrixTransform3D(m_transformMatrix.m_totalMatrix));
        }
    }
}
