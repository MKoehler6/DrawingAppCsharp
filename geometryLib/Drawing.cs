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
using Newtonsoft.Json;

namespace geometryLib
{
    /// <summary>
    /// In dieser Klasse werden in der List Elements die einzelnen Circle, Lines und Polylines gespeichert,
    /// durch die Clickhandler wird entsprechend der angeklickten Schaltfläche Line, Circle oder Polyline über das Delegate 
    /// ClickHandler die jeweilige ClickHandler-Methode in den Klassen Line, Circle, Polyline zugeordnet
    /// MouseDown und MouseMove Ereignisse werden weiterverarbeitet
    /// Open und Save in einer Json (oder Xml)-Datei werden durchgeführt
    /// </summary>
    public class Drawing
    {
        //https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
        //EventHandler ist ein Delegat vom System: public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Redraw;
        [JsonIgnore]
        public Curve m_currentCurve;
        [JsonIgnore]
        public ClickHandler m_clickHandler = null;
        [JsonIgnore]
        public TmpPointHandler m_tmpPointHandler = null;
        [JsonIgnore]
        private ClickResult result;

        //[XmlArrayItem("Line", typeof(Line))]
        //[XmlArrayItem("Circle", typeof(Circle))]
        //[XmlArray("Polyline")]
        //[XmlArrayItem("pointsArray", typeof(Point[]))]
        public List<Curve> Elements = new List<Curve>();

        [JsonIgnore]
        public Line[] Lines
        {
            get
            {
                IEnumerable<Line> result =
                    from e in Elements
                    where e is Line
                    select e as Line;
                return result.ToArray();
            }
            set
            {
                foreach (Line line in value) AddElement(line);
            }
        }

        [JsonIgnore]
        public Circle[] Circles
        {
            get
            {
                IEnumerable<Circle> result =
                    from e in Elements
                    where e is Circle
                    select e as Circle;
                return result.ToArray();
            }
            set
            {
                foreach (Circle circle in value) AddElement(circle);
            }
        }

        [JsonIgnore]
        public Polyline[] Polylines
        {
            get
            {
                IEnumerable<Polyline> result =
                    from e in Elements
                    where e is Polyline
                    select e as Polyline;
                return result.ToArray();
            }
            set
            {
                foreach (Polyline polyline in value) AddElement(polyline);
            }
        }

        public double LengthOfAllLines(Line[] elements)
        {
            double result = 0;
            foreach (Line element in elements) result += element.Length;
            return result;
        }

        public double LengthOfAllCircles(Circle[] elements)
        {
            double result = 0;
            foreach (Circle element in elements) result += element.Length;
            return result;
        }

        public double LengthOfAllPolylines(Polyline[] elements)
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
                element.Draw(g, new Pen(Properties.Settings1.Default.FarbeStandard,
                    Properties.Settings1.Default.Strichstaerke));
            }
            if (m_currentCurve != null)
            {
                m_currentCurve.Draw(g, new Pen(Properties.Settings1.Default.GummibandFarbe,
                    Properties.Settings1.Default.Strichstaerke));
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

        // Escape-Taste wurde gedrückt oder bei Line und Circle die rechte Maustaste
        public void Cancel()
        {
            m_currentCurve = null;
            m_clickHandler = null;
            result = ClickResult.canceled;
            if (Redraw != null) Redraw(this, new EventArgs());
        }

        public void SaveXml (string fileName)
        {
            // Drawing als .xml speichern
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

        public void SaveJson(string fileName)
        {
            // Drawing als .json speichern
            using (StreamWriter streamWriter = File.CreateText(fileName))
            {
                JsonSerializer jsonSerializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto };
                jsonSerializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                jsonSerializer.Serialize(streamWriter, this);
            }
            
        }
        public void OpenJson(string fileName)
        {
            using (StreamReader streamReader = File.OpenText(fileName))
            {
                JsonSerializer jsonSerializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto };
                Drawing drawing = (Drawing)jsonSerializer.Deserialize(streamReader, typeof(Drawing));
                this.Elements = drawing.Elements;
                Redraw(this, new EventArgs());
            }
        }

        public void OpenXml (string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
                XmlAttributes attribs = new XmlAttributes();
                attribs.XmlIgnore = true;
                overrides.Add(typeof(Curve), "DrawPen", attribs);
                overrides.Add(typeof(Drawing), "m_clickHandler", attribs);
                overrides.Add(typeof(Drawing), "m_tmpPointHandler", attribs);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Drawing), overrides);
                Drawing drawing = (Drawing)xmlSerializer.Deserialize(streamReader);

                for (int i = 0; i < drawing.Lines.Length; i++) this.Elements.Add(drawing.Lines[i]);
                for (int i = 0; i < drawing.Circles.Length; i++) this.Elements.Add(drawing.Circles[i]);
                for (int i = 0; i < drawing.Polylines.Length; i++) this.Elements.Add(drawing.Polylines[i]);

                if (Redraw != null) Redraw(this, new EventArgs());
            }
        }
    }
    public class TestDrawing
    {
        [XmlArray("Lines")]
        [XmlArrayItem("Line", typeof(Line))]
        public Line[] lines;

        [XmlArray("Circles")]
        [XmlArrayItem("Circle", typeof(Circle))]
        public Circle[] circles;

        //[XmlArray("Polylines")]
        //[XmlArrayItem("pointsArray", typeof(Point[]))]
        //public Polyline[] polylines;
    }
}
