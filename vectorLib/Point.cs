using System;
using System.Collections.Generic;
using System.Text;

namespace vectorLib
{
    public class Point : PointVectorBase
    {
        public Point(double X, double Y, double Z = 0) : base(X, Y, Z) { }

        public Point() : base(0, 0) { }

        public Point(Point p) : base(p) { }

        public Vector AsVector
        {
            get
            {
                return new Vector(X, Y, Z);
            }
        }

        public Point Add(params Point[] points)
        {
            Point p = new Point(0, 0);
            p.CalculateSum(points);
            return p;
        }

        public double DistanceTo(Point point)
        {
            return this.CalculateDistanceTo(point);
        }
        public override bool Equals(Object obj)
        {
            if (!base.Equals(obj)) return false;
            Point p = (Point)obj;
            if (p.X != this.X || p.Y != this.Y || p.Z != this.Z) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ 87628556;
        }
        public override string ToString()
        {
            return "Point: " + base.ToString();
        }
        public static Point operator +(Point p1, Vector v1)
        {
            PointVectorBase[] pvbs = new PointVectorBase[] { p1, v1 };
            Point Result = new Point();
            Result.CalculateSum(pvbs);
            return Result;
        }
    }
}
