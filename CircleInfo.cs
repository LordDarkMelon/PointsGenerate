using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsGenerate
{
    public class CircleInfo
    {
        public CircleInfo(int x, int y, int r, Color color, int circleLineWidth = 1)
        {
            pen = new Pen(color, circleLineWidth);
            X = x;
            Y = y;
            R = r;
        }

        /// <summary>
        /// 
        /// </summary>
        public Pen pen = new Pen(Color.Green, 1);
        /// <summary>
        /// 
        /// </summary>
        public int X;
        /// <summary>
        /// 
        /// </summary>
        public int Y;
        public int R;
        public void Draw(Graphics graphics)
        {
            Rectangle rect = Rectangle.FromLTRB(X - R, Y - R, X + R, Y + R);
            graphics.DrawEllipse(pen, rect);
        }





    }
}