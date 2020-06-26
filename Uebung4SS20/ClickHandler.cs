using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uebung4SS20
{
    public enum ClickResult { created, pointHandled, finished, canceled }

    delegate ClickResult ClickHandler(Point pt, MouseButtons but, ref Curve curElement);

}
