using System;
using System.Collections.Generic;
using System.Text;

namespace vectorLib
{
    public abstract class PointVectorBase
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public static double Tolerance = 1E-06;


        protected PointVectorBase() { }

        protected PointVectorBase(double X, double Y, double Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        protected PointVectorBase(PointVectorBase source)
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Z = source.Z;
        }

        protected double CalculateDistanceTo(PointVectorBase pvb)
        {
            double distance = Math.Sqrt(Math.Pow(this.X - pvb.X, 2) + Math.Pow(this.Y - pvb.Y, 2) + Math.Pow(this.Z - pvb.Z, 2));
            return distance;
        }

        protected void CalculateSum(params PointVectorBase[] pbvs)
        {
            foreach (PointVectorBase v in pbvs)
            {
                this.X += v.X;
                this.Y += v.Y;
                this.Z += v.Z;
            }
        }

        protected void CalculateProduct(double factor)
        {
            this.X *= factor;
            this.Y *= factor;
            this.Z *= factor;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            return true;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
        public override string ToString()
        {
            return $"X={Math.Round(X, 2)} Y={Math.Round(Y, 2)} Z={Math.Round(Z, 2)}";
        }

        public static bool operator == (PointVectorBase pvb1, PointVectorBase pvb2) 
        {
            return pvb1.Equals(pvb2);
        }
        public static bool operator != (PointVectorBase pvb1, PointVectorBase pvb2) 
        {
            return !pvb1.Equals(pvb2);
        }
    }


}
