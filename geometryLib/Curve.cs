using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace geometryLib
{
    public abstract class Curve
    {
        public virtual double Length { get; }

        public abstract void Draw(Graphics g);

        public Pen DrawPen { get; set; } = new Pen(Color.Black);
    }
}
