using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uebung4SS20
{
    public partial class MainFrame : Form
    {
        Drawing m_CAD = new Drawing();
        private ClickHandler m_clickHandler = null;
        Curve m_currentCurve;
        ClickResult result;

        public MainFrame()
        {
            InitializeComponent();
            m_CAD.Redraw += M_CAD_Redraw;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            double Radius = 50;
            Curve circle = new Circle(new Point(200 - Radius, 200 + Radius), Radius);
            m_clickHandler = Circle.ClickHandler;
            m_currentCurve = null;
            m_CAD.AddElement(circle);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            Curve line = new Line(new Point(130, 130), new Point(200, 150));
            m_clickHandler = Line.ClickHandler;
            m_currentCurve = null;
            m_CAD.AddElement(line);
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            Point point1 = new Point(300, 150);
            Point point2 = new Point(310, 100);
            Point point3 = new Point(340, 160);
            Point point4 = new Point(380, 80);
            Polyline polyline = new Polyline();
            polyline.AddPoint(point1);
            polyline.AddPoint(point2);
            polyline.AddPoint(point3);
            polyline.AddPoint(point4);
            Curve c = (Curve)polyline; 

            m_clickHandler = Polyline.ClickHandler;
            m_currentCurve = null;
            m_CAD.AddElement(polyline);
        }
        
        // legt den Koordinatenursprung auf unten links fest
        private void SetGraphicsTransformToWorld(Graphics g)
        {
            g.ResetTransform();
            g.ScaleTransform(1f, -1f);
            g.TranslateTransform(0f, -pictureBox1.Height);
        }
        
        // wird beim Neuzeichnen aufgerufen und bei Invalidate()
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SetGraphicsTransformToWorld(graphics);
            m_CAD.Draw(graphics);
        }

        // bewirkt das Neumalen des Fensters beim Groß- und Kleinziehen
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void M_CAD_Redraw(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = TransformScreen2World(e.Location);
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
                    m_CAD.AddElement(m_currentCurve);
                    m_currentCurve = null;
                }

            }   
                


        }

        private Uebung4SS20.Point TransformScreen2World(System.Drawing.Point screenPoint) { 
            return new Uebung4SS20.Point(screenPoint.X, -(screenPoint.Y - pictureBox1.Height)); 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (result == ClickResult.created)
            {
                Point point = TransformScreen2World(e.Location);
                if (m_currentCurve is Circle)
                {
                    Circle circle = (Circle)m_currentCurve;
                    double r = point.DistanceTo(circle.Center);
                    circle.Radius = r;
                    m_CAD.AddElement(circle);
                    statusStrip1.Refresh();
                }
            }
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = "Anzahl Elemente: " + m_CAD.Elements.Count + "   Drawed: " +
                m_CAD.ElementsDrawed + "  Type: " + m_CAD.type;
        }
    }
}
