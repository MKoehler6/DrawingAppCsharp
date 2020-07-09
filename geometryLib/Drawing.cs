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
using System.IO;
using System.Xml.Serialization; 

namespace geometryLib
{
    public class Drawing
    {
        //https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
        //EventHandler ist ein Delegat vom System: public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Redraw;
        public Curve m_currentCurve;
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

        public void CircleButtonClickHandler()
        {
            m_clickHandler = Circle.ClickHandler;
            m_tmpPointHandler = Circle.TmpPointHandler;
            m_currentCurve = null;
            StatusManager.Instance.SetStatus("Kreis: Linksklick erzeugt Mittelpunkt des neuen Kreises   ESC: Abbruch");
        }

        public void LineButtonClickHandler()
        {
            m_clickHandler = Line.ClickHandler;
            m_tmpPointHandler = Line.TmpPointHandler;
            m_currentCurve = null;
            StatusManager.Instance.SetStatus("Linie: Linksklick erzeugt ersten Punkt der neuen Linie   ESC: Abbruch");
        }

        public void PolylineButtonClickHandler ()
        {
            m_clickHandler = Polyline.ClickHandler;
            m_tmpPointHandler = Polyline.TmpPointHandler;
            m_currentCurve = null;
            StatusManager.Instance.SetStatus("Polylinie: Linksklick erzeugt ersten Punkt der neuen Polylinie   ESC: Abbruch");
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
            if (m_currentCurve != null)
            {
                m_currentCurve.Draw(g);
            }
        }

        public void MouseDownHandler(Point point, MouseEventArgs e)
        {
            if (m_clickHandler != null)
            {
                result = m_clickHandler(point, e.Button, ref m_currentCurve);
                if (result == ClickResult.canceled)
                {
                    Cancel();
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
                m_tmpPointHandler(point, ref m_currentCurve);
                if (Redraw != null) Redraw(this, new EventArgs());
            }
        }

        public void Cancel()
        {
            m_currentCurve = null;
            m_clickHandler = null;
            result = ClickResult.canceled;
            if (Redraw != null) Redraw(this, new EventArgs());
        }

        public void Save (string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                // Die Typen DrawPen, m_clickHandler und m_tmpPointHandler lassen sich nicht serialisieren,
                // da sie keinen parameterlosen Konstruktor haben und müssen mit XmlIgnore gekennzeichnet werden
                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
                XmlAttributes attribs = new XmlAttributes();
                attribs.XmlIgnore = true;
                overrides.Add(typeof(Curve), "DrawPen", attribs);
                overrides.Add(typeof(Drawing), "m_clickHandler", attribs);
                overrides.Add(typeof(Drawing), "m_tmpPointHandler", attribs);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Drawing), overrides);
                xmlSerializer.Serialize(streamWriter, this);
            }
        }
    }
}
