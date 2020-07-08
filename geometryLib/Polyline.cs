using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using vectorLib;
using Point = vectorLib.Point;

namespace geometryLib
{
    public class Polyline : Curve
    {
        private List<Point> Points = new List<Point>();

        public override double Length
        {
            get
            {
                double result = 0;
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    Line line = new Line(Points[i], Points[i + 1]);
                    result += line.Length;
                }
                return result;
            }
        }

        public bool isClosed
        {
            get
            {
                return Points[0].Equals(Points[Points.Count - 1]);
            }
        }

        public bool isPlanar
        {
            get
            {
                if (Points.Count < 3) return false;
                else if (Points.Count == 3) return true;
                else
                {
                    List<Vector> VectorList = new List<Vector>();
                    for (int i = 0; i < Points.Count - 1; i++)
                    {
                        VectorList.Add(new Vector(Points[i], Points[i + 1]));
                    }
                    for (int i = 2; i < VectorList.Count; i++)
                    {
                        if (Determinante(VectorList[i-2], VectorList[i-1], VectorList[i]) != 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        public double Area
        {
            get
            {
                if (!isClosed | !isValid) return 0;
                else
                {
                    // Vektor aus Punkt 1 und 2
                    Vector v1 = new Vector(Points[0], Points[1]);
                    Vector v2 = new Vector(Points[1], Points[2]);
                    // neue X-Achse ist v1
                    Vector xAxis = v1;
                    // neue Y-Achse ist Kreuzprodukt aus v1 und (Kreuzprodukt v1 und v2)
                    Vector yAxis = v1.CrossProduct(v1.CrossProduct(v2));
                    // x und y-Achse normalisieren
                    xAxis = xAxis.Normalize();
                    yAxis = yAxis.Normalize();
                    double[] PointsXArray = new double[Points.Count]; 
                    double[] PointsYArray = new double[Points.Count];
                    for (int i = 0; i < Points.Count; i++)
                    {
                        PointsXArray[i] = Points[i].AsVector.DotProduct(xAxis);
                        PointsYArray[i] = Points[i].AsVector.DotProduct(yAxis);
                    }
                    double temp1 = 0;
                    double temp2 = 0;
                    for (int i = 0; i < PointsXArray.Length - 1; i++)
                    {
                        temp1 += PointsXArray[i] * PointsYArray[i + 1];
                        temp2 += PointsXArray[i + 1] * PointsYArray[i];
                    }
                    temp1 += PointsXArray[PointsXArray.Length-1] * PointsYArray[0];
                    temp2 += PointsXArray[0] * PointsYArray[PointsYArray.Length-1];

                    return Math.Abs(0.5 * (temp1 - temp2));
                }
            }
        }

        private double Determinante(Vector v1, Vector v2, Vector v3)
        {
            double result = v1.X * v2.Y * v3.Z + v1.Z * v2.X * v3.Y + v1.Y * v2.Z * v3.X 
                - v1.Z * v2.Y * v3.X - v1.X * v2.Z * v3.Y - v1.Y * v2.X * v3.Z;
            return result;
        }

        public bool isValid
        {
            get
            {
                return Points.Count > 1;
            }
        }

        public void AddPoint (Point newPoint)
        {
            Points.Add(newPoint);
        }
        public void InsertPoint (int position, Point newPoint)
        {

        }
        public void RemoveLastPoint ()
        {
            Points.RemoveAt(Points.Count - 1);
        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                g.DrawLine(DrawPen, (float)Points[i].X, (float)Points[i].Y,
                    (float)Points[i + 1].X, (float)Points[i+1].Y);
            }
        }
        public static ClickResult ClickHandler(Point pt, MouseButtons but, ref Curve curElement)
        {
            if (curElement == null || 
                (!(curElement is Polyline) && but == MouseButtons.Left)) // es ist der 1. Klick
            {
                Polyline polyline = new Polyline();
                polyline.AddPoint(pt);
                curElement = polyline;
                return ClickResult.created;
            }
            else
            {
                Polyline polyline = (Polyline)curElement;
                if (but == MouseButtons.Left)
                {
                    polyline.AddPoint(pt);
                    return ClickResult.pointHandled;
                }
                else
                {
                    if (polyline.Points.Count < 2)
                    {
                        return ClickResult.canceled;
                    }
                    else
                    {
                        return ClickResult.finished;
                    }
                }
            }
        }

        public static void TmpPointHandler(Point point, ref Curve curElement)
        {
            Polyline polyline = (Polyline)curElement;
            if (polyline.Points.Count > 1)
            {
                polyline.RemoveLastPoint();
            }
            polyline.AddPoint(point);
            curElement = polyline;
        }
    }
}
