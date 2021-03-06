﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Point = vectorLib.Point;
using vectorLib;

namespace geometryLib
{
    public class Circle : Curve
    {
        public Vector Normal;
        public Point Center;
        public double Radius;
        public const string STARTMESSAGE = "Kreis: Linksklick erzeugt Mittelpunkt des neuen Kreises   ESC: Abbruch";
        public const string ENDMESSAGE = "Kreis: Linkssklick beendet den Kreis   ESC: Abbruch";
        public override double Length {
            get 
            {
                return 2 * Math.PI * Radius;
            }
        }

        public Circle() { }

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

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, 
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
                StatusManager.Instance.SetStatus(ENDMESSAGE);
                Circle circle = new Circle(pt, 0);
                curElement = circle;
                return ClickResult.created;
            }
            else // es ist der 2. Klick
            {
                StatusManager.Instance.SetStatus(STARTMESSAGE);
                Circle circle = (Circle)curElement;
                double r = pt.DistanceTo(circle.Center);
                circle.Radius = r;
                return ClickResult.finished;
            }
        }

        public static void TmpPointHandler(Point point, ref Curve curElement)
        {
            Circle circle = (Circle)curElement;
            double r = point.DistanceTo(circle.Center);
            circle.Radius = r;
            curElement = circle;
        }
    }
}
