using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointsGenerate
{
    public partial class Form1 : Form
    {

        public const int PictureBoxEdgePixels = 100;
        public const int WaferCircleEdgeToPictureBoxEdgePixels = 100;
        public const double WaferRadiusMM = 150;
        public Color WaferEdgeColor = Color.Black;
        public Color WaferCenterColor = Color.Black;
        public Color PointColor = Color.Red;
        public Color CircleColor = Color.White;
        public int PointCircleRadiusPixel = 2;
        public const int slices = 8;

        private Point WaferCenterPixels = new Point(0, 0);
        private int WaferRadiusPixels = 0;
        private double PixelsPerMM = 0;
        private int TotalPoints = 1;
        public List<CircleInfo> CircleGraphList = new List<CircleInfo>();


        public Form1()
        {
            InitializeComponent();
            CalculatePictureBoxSizeAndPixelSize();
        }




        public void Drawing(Graphics graphics)
        {
            try
            {
                foreach (CircleInfo info in CircleGraphList)
                {
                    info.Draw(graphics);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not an acceptable integer");
                throw ex;
            }
        }


        public void Paint(object sender, PaintEventArgs e)
        {
            Drawing(e.Graphics);
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            GeneratePoints();
            pictureBox.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CalculatePictureBoxSizeAndPixelSize();
        }

        private void CalculatePictureBoxSizeAndPixelSize()
        {
            pictureBox.Location = new Point(PictureBoxEdgePixels, PictureBoxEdgePixels);
            pictureBox.Size = new Size(this.Width - PictureBoxEdgePixels * 2, this.Height - PictureBoxEdgePixels * 2);
            WaferRadiusPixels = Math.Min(pictureBox.Size.Width, pictureBox.Size.Height) / 2 - WaferCircleEdgeToPictureBoxEdgePixels;
            WaferCenterPixels = new Point(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2);
            PixelsPerMM = WaferRadiusPixels / WaferRadiusMM;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            GeneratePoints();
            pictureBox.Refresh();
        }
        private void GeneratePoints()
        {
            try
            {
                TotalPoints = System.Convert.ToInt32(textBox_TotalExpectedPoints.Text)-1;

            }
            catch
            {
                
            }

            if (TotalPoints % 2 != 0) 
            {

            }
            else 
            {
                GeneratePointsWithAnyInputNumber(TotalPoints);
            }


        }


        private void GeneratePointsWithAnyInputNumber(int totalPoints)
        {
            CircleGraphList.Clear();
            CircleInfo waferCircleInfo = new CircleInfo(WaferCenterPixels.X, WaferCenterPixels.Y, WaferRadiusPixels, WaferCenterColor);
            CircleGraphList.Add(waferCircleInfo);
            CircleInfo centerInfo = new CircleInfo(WaferCenterPixels.X, WaferCenterPixels.Y, PointCircleRadiusPixel, WaferCenterColor);
            CircleGraphList.Add(centerInfo);

            int fullCircles = totalPoints/ slices;
            int remaining = totalPoints % slices;

            double distanceBetweenNeighborCircle = WaferRadiusMM / (fullCircles + 2);

            for (int i = 0; i < fullCircles; i++)
            {

                double angleStep = (Math.PI * 2) / slices;
                double r = (i + 1) * distanceBetweenNeighborCircle;
                CircleInfo circleInfo = new CircleInfo(WaferCenterPixels.X, WaferCenterPixels.Y, (int)Math.Round(r * PixelsPerMM), CircleColor);
                CircleGraphList.Add(circleInfo);
                for (int j = 0; j < 8; j++)
                {
                    double x = r * Math.Cos(angleStep * j);
                    double y = r * Math.Sin(angleStep * j);
                    Point point = ConvertCoordinateFromRealUnitToImagePixel(x, y);
                    CircleInfo pointInfo = new CircleInfo(point.X, point.Y, PointCircleRadiusPixel, PointColor);
                    CircleGraphList.Add(pointInfo);
                }
            }
            for (int i = 0; i < remaining; i++) 
            {
                double r = (fullCircles + 1) * distanceBetweenNeighborCircle;
                double angleStep = (Math.PI * 2) / remaining;
                double x = r * Math.Cos(angleStep * i);
                double y = r * Math.Sin(angleStep * i);
                Point point = ConvertCoordinateFromRealUnitToImagePixel(x, y);
                CircleInfo pointInfo = new CircleInfo(point.X, point.Y, PointCircleRadiusPixel, PointColor);
                CircleGraphList.Add(pointInfo);
            }
        }

        private Point ConvertCoordinateFromRealUnitToImagePixel(double x, double y)
        {
            int nX = (int)Math.Round(WaferCenterPixels.X + x * PixelsPerMM);
            int nY = (int)Math.Round(WaferCenterPixels.Y + y * PixelsPerMM);
            return new Point(nX, nY);
        }
    }
}
