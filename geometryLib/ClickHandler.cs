using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = vectorLib.Point;

namespace geometryLib
{
    public enum ClickResult { created, pointHandled, finished, canceled }

    public delegate ClickResult ClickHandler(Point pt, MouseButtons but, ref Curve curElement);

}
