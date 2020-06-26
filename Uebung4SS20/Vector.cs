using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung4SS20
{
    class Vector : PointVectorBase
    {
        public Vector(double X, double Y, double Z=0):base(X,Y,Z) { }

        public Vector() : base(0,0) { }

        public Vector(Vector v) : base(v) { }

        public Vector(Point StartPoint, Point EndPoint) : 
            base(EndPoint.X - StartPoint.X,
                EndPoint.Y - StartPoint.Y,
                EndPoint.Z - StartPoint.Z) { }

        public Vector Add(params Vector[] vectors)
        {
            Vector v = new Vector(0, 0);
            v.CalculateSum(vectors);
            return v;
        }

        public Vector MultiplyBy(double fac)
        {
            Vector v = new Vector(this);
            v.CalculateProduct(fac);
            return v;
        }

        public double DotProduct(Vector vector) // Skalarprodukt
        {
            double result = this.X * vector.X + this.Y * vector.Y + this.Z * vector.Z;
            return result;
        }

        public Vector CrossProduct(Vector v) // gibt Vektor, der senkrecht zu beiden Vektoren steht
        {
            Vector Result = new Vector();
            Result.X = this.Y * v.Z - this.Z * v.Y;
            Result.Y = this.Z * v.X - this.X * v.Z;
            Result.Z = this.X * v.Y - this.Y * v.X;
            return Result;
        }

        public Vector Normalize()
        {
            Vector Result = new Vector(this);
            double length = Result.CalculateDistanceTo(new Vector());
            if (length != 0)
            {
                Result.CalculateProduct(1 / length);
            }
            return Result;
        }

        public bool AreCollinear(params Vector[] pvbs)
        {
            double factor = 0;
            bool alleXnull = true;
            bool alleYnull = true;
            bool alleZnull = true;
            bool mindEinXistNull = false;
            bool mindEinYistNull = false;
            bool mindEinZistNull = false;
            // wenn irgendwo ein null ist, dann müssen alle anderen X / Y / Z auch null sein
            foreach (Vector v in pvbs)
            {
                if (v.X != 0) alleXnull = false;
                else mindEinXistNull = true;
                if (v.Y != 0) alleYnull = false;
                else mindEinYistNull = true;
                if (v.Z != 0) alleZnull = false;
                else mindEinZistNull = true;
            }
            if (mindEinXistNull & !alleXnull) return false;
            if (mindEinYistNull & !alleYnull) return false;
            if (mindEinZistNull & !alleZnull) return false;
            // alle Vektoren überprüfen, ob mit Faktor ineinander überführbar
            for (int i = 1; i < pvbs.Length; i++)
            {
                // Faktor in einer Reihe ohne null berechnen
                if (!mindEinXistNull) factor = pvbs[i].X / pvbs[0].X;
                if (!mindEinYistNull) factor = pvbs[i].Y / pvbs[0].Y;
                if (!mindEinZistNull) factor = pvbs[i].Z / pvbs[0].Z;
                if (pvbs[0].X * factor != pvbs[i].X) return false;
                if (pvbs[0].Y * factor != pvbs[i].Y) return false;
                if (pvbs[0].Z * factor != pvbs[i].Z) return false;
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (!base.Equals(obj)) return false;
            Vector v = (Vector)obj;
            if (v.X != this.X || v.Y != this.Y || v.Z != this.Z) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ 34577658;
        }
        public override string ToString()
        {
            return $"Vector: {base.ToString()}"; 
        }

        public static Vector operator + (Vector v1, Vector v2) // Ueberschreiben des Plus-Operators
        {
            return v1.Add(new Vector[] {v1,v2});
        }
        public static Vector operator - (Vector v1, Vector v2) // Ueberschreiben des Minus-Operators
        {
            return v1.Add(new Vector[] { v1, v2.MultiplyBy(-1) });
        }
        public static Vector operator *(Vector v1, double fac) // Ueberschreiben des Plus-Operators
        {
            return v1.MultiplyBy(fac);
        }
        public static Vector operator *(double fac, Vector v1) // Ueberschreiben des Plus-Operators
        {
            return v1.MultiplyBy(fac);
        }
    }
}
    