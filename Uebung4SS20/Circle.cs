using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Uebung4SS20
{
    class Circle : Curve
    {
        public Vector Normal;
        public Point Center;
        public double Radius;
        public override double Length {
            get 
            {
                return 2 * Math.PI * Radius;
            }
        }

        public Circle(Vector Normal, Point Center, double Radius)
        {
            this.Normal = Normal;
            this.Center = Center;
            this.Radius = Radius;
        }
        public Circle(Point Center, double Radius)
        {
            this.Center = Center;
            this.Radius = Radius;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(DrawPen, 
                (float)(Center.X - Radius), 
                (float)(Center.Y - Radius), 
                (float)Radius * 2,
                (float)Radius * 2);
        }

        public static ClickResult ClickHandler(Point pt, MouseButtons but, ref Curve curElement)
        {
            if(but == MouseButtons.Right) 
                return ClickResult.canceled; // Abbruch
            else if (curElement == null || !(curElement is Circle)) // es ist der 1. Klick
            {
                Circle circle = new Circle(pt, 0);
                curElement = circle;
                return ClickResult.created;
            }
            else // es ist der 2. Klick
            {
                Circle circle = (Circle)curElement;
                double r = pt.DistanceTo(circle.Center);
                circle.Radius = r;
                return ClickResult.finished;
            }
        }
    }
}
