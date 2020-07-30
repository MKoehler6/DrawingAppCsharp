using System;
using System.Collections.Generic;
using System.Text;
using Point = vectorLib.Point;

namespace vectorLib
{
    /// <summary>
    /// Testklasse
    /// </summary>
    class TestPVB : PointVectorBase
    {

        public TestPVB(int v1, int v2, int v3 = 0) : base(v1, v2, v3){ }

        public TestPVB() : base() { }

        public TestPVB(TestPVB testpvb) : base(testpvb) { }

        //public static void Main(String[] Args)
        //{
        //    Point p = new Point(1, 2, 3);
        //    Console.WriteLine(p.GetHashCode());
        //}
    }
}
