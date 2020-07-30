using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;

namespace geometryLib
{
    public abstract class Curve
    {
        public virtual double Length { get; }

        public abstract void Draw(Graphics g, Pen pen);


    }
}
