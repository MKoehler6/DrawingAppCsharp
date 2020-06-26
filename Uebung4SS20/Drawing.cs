using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung4SS20
{
    class Drawing
    {
        //https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
        //EventHandler ist ein Delegat vom System: public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Redraw;

        public List<Curve> Elements = new List<Curve>();
        public int ElementsDrawed = 0;
        public Type type;

        public void AddElement(Curve curve)
        {
            Elements.Add(curve);
            if (Redraw != null) Redraw(this, new EventArgs());
        }

        public void RemoveElementAt(int i)
        {
            Elements.RemoveAt(i);
            if (Redraw != null) Redraw(this, new EventArgs());
        }

        public void RemoveElement(Curve curve)
        {
            Elements.Remove(curve);
            if (Redraw != null) Redraw(this, new EventArgs());
        }

        public void Draw(Graphics g)
        {
            ElementsDrawed = 0;
            foreach (var element in Elements)
            {
                element.Draw(g);
                ElementsDrawed++;
                type = element.GetType();
            }
        }
    }
}
