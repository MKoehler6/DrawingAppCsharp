using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Uebung4SS20
{
    class Line : Curve
    {
        public Point StartPoint;
        public Point EndPoint;
        public Vector Direction 
        { 
            get
            {
                Vector result = new Vector(StartPoint, EndPoint);
                return result.Normalize();
            }
        }
        public override double Length 
        { 
            get 
            {
                return StartPoint.DistanceTo(EndPoint);
            }
        }

        public Line (Point StartPoint, Point EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(DrawPen, (float) StartPoint.X, (float)StartPoint.Y, 
                (float)EndPoint.X, (float)EndPoint.Y);
        }
        public static ClickResult ClickHandler(Point pt, MouseButtons but, ref Curve curElement)
        {
            MessageBox.Show("Line");
            return ClickResult.canceled;
        }
    }
}