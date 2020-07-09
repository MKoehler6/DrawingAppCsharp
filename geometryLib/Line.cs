using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Point = vectorLib.Point;
using vectorLib;

namespace geometryLib
{
    public class Line : Curve
    {
        public Point StartPoint;
        public Point EndPoint;
        public const string STARTMESSAGE = "Linie: Linksklick erzeugt ersten Punkt der neuen Linie   ESC: Abbruch";
        public const string ENDMESSAGE = "Linie: Linkssklick erzeugt Endpunkt der Linie   ESC: Abbruch";
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
            if (but == MouseButtons.Right)
                return ClickResult.canceled; // Abbruch
            else if (curElement == null || !(curElement is Line)) // es ist der 1. Klick
            {
                StatusManager.Instance.SetStatus(ENDMESSAGE);
                Line line = new Line(pt, pt);
                curElement = line;
                return ClickResult.created;
            }
            else // es ist der 2. Klick
            {
                StatusManager.Instance.SetStatus(STARTMESSAGE);
                Line line = (Line)curElement;
                line.EndPoint = pt;
                return ClickResult.finished;
            }
        }
        public static void TmpPointHandler(Point point, ref Curve curElement)
        {
            Line line = (Line)curElement;
            line.EndPoint = point;
            curElement = line;
        }
    }
}