using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vectorLib;
using geometryLib;
using Point = vectorLib.Point;

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
            // zum delegate Redraw wird die Methode M_CAD_Redraw hinzugefügt
            m_CAD.Redraw += M_CAD_Redraw;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            m_clickHandler = Circle.ClickHandler;
            m_currentCurve = null;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            m_clickHandler = Line.ClickHandler;
            m_currentCurve = null;
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            m_clickHandler = Polyline.ClickHandler;
            m_currentCurve = null;
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
            // Punkt auf mathematisches Koordinatensystem umrechnen
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

        private Point TransformScreen2World(System.Drawing.Point screenPoint) { 
            return new Point(screenPoint.X, -(screenPoint.Y - pictureBox1.Height)); 
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

        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            // beim Druecken von Esc wird der aktuelle Zeichenbefehl abgebrochen
            if (e.KeyCode == Keys.Escape)
            {
                m_clickHandler = null;
                result = ClickResult.canceled;
            }
        }
    }
}
