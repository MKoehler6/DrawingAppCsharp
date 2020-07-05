using System;
using System.Collections.Generic;
using System.Text;

namespace vectorLib
{
    class TestPVB : PointVectorBase
    {

        public TestPVB(int v1, int v2, int v3 = 0) : base(v1, v2, v3){ }

        public TestPVB() : base() { }

        public TestPVB(TestPVB testpvb) : base(testpvb) { }
    }
}
