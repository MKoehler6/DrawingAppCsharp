using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vectorLib;
using geometryLib;
using Point = vectorLib.Point;
using System.Windows.Forms;

namespace geometryLib
{
    public class Drawing
    {
        //https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
        //EventHandler ist ein Delegat vom System: public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Redraw;
        public Curve m_currentCurve;
        public Curve m_tmpCurveElement;
        public ClickHandler m_clickHandler = null;
        public TmpPointHandler m_tmpPointHandler = null;
        private ClickResult result;

        public List<Curve> Elements = new List<Curve>();

        public List<Line> Lines
        {
            get
            {
                IEnumerable<Line> result =
                    from e in Elements
                    where e is Line
                    select e as Line;
                return result.ToList();
            }
        }

        public List<Circle> Circles
        {
            get
            {
                IEnumerable<Circle> result =
                    from e in Elements
                    where e is Circle
                    select e as Circle;
                return result.ToList();
            }
        }

        public List<Polyline> Polylines
        {
            get
            {
                IEnumerable<Polyline> result =
                    from e in Elements
                    where e is Polyline
                    select e as Polyline;
                return result.ToList();
            }
        }

        public double LengthOfAllLines(List<Line> elements)
        {
            double result = 0;
            foreach (Line element in elements) result += element.Length;
            return result;
        }

        public double LengthOfAllCircles(List<Circle> elements)
        {
            double result = 0;
            foreach (Circle element in elements) result += element.Length;
            return result;
        }

        public double LengthOfAllPolylines(List<Polyline> elements)
        {
            double result = 0;
            foreach (Polyline element in elements) result += element.Length;
            return result;
        }


        // hinzufügen des Elements und aufrufen des Delegates Redraw, diesem wurde in MainFrame.cs die Methode M_CAD_Redraw 
        // hinzugefügt, dort wird Invalidate aufgerufen und damit die Methode pictureBox1_Paint, die dann in dieser Klasse
        // Draw aufruft
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

        // wird durch pictureBox1_Paint bei jedem Neuzeichnen aufgerufen
        public void Draw(Graphics g)
        {
            foreach (var element in Elements)
            {
                element.Draw(g);
            }
        }

        public void MouseDownHandler(Point point, MouseEventArgs e)
        {
            if (m_clickHandler != null)
            {
                result = m_clickHandler(point, e.Button, ref m_currentCurve);
                if (result == ClickResult.canceled)
                {
                    m_currentCurve = null;
                    m_clickHandler = null;
                }
                else if (result == ClickResult.finished)
                {
                    AddElement(m_currentCurve);
                    m_currentCurve = null;
                }
            }
        }

        public void MouseMoveHandler(Point point)
        {
            if (m_currentCurve != null)
            {
                //m_tmpPointHandler(point, ref m_tmpCurveElement);
            }
        }
    }
}
