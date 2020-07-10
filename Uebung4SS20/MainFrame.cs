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

        public MainFrame()
        {
            InitializeComponent();
            // zum delegate Redraw wird die Methode M_CAD_Redraw hinzugefügt
            m_CAD.Redraw += M_CAD_Redraw;
            // zum delegate StatusMessageChange wird eine Implementierung einer Methode hinzugefügt
            StatusManager.Instance.StatusMessageChange += (sender, args) => toolStripStatusLabel1.Text = args.Message;

            StatusManager.Instance.SetStatus("kein Befehl aktiv");
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            m_CAD.CircleButtonClickHandler();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            m_CAD.LineButtonClickHandler();
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            m_CAD.PolylineButtonClickHandler();
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

        // wird durch das Delegat Redraw aufgerufen
        private void M_CAD_Redraw(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Punkt auf mathematisches Koordinatensystem umrechnen
            Point point = TransformScreen2World(e.Location);
            m_CAD.MouseDownHandler(point, e);  
        }

        // Punkt auf mathematisches Koordinatensystem umrechnen
        private Point TransformScreen2World(System.Drawing.Point screenPoint) { 
            return new Point(screenPoint.X, -(screenPoint.Y - pictureBox1.Height)); 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = TransformScreen2World(e.Location);
            m_CAD.MouseMoveHandler(point);
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            // beim Druecken von Esc wird der aktuelle Zeichenbefehl abgebrochen
            if (e.KeyCode == Keys.Escape)
            {
                StatusManager.Instance.SetStatus("Kein Befehl aktiv");
                m_CAD.Cancel();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anzahl Linien: " + m_CAD.Lines.Count() + " Gesamtlänge: " + m_CAD.LengthOfAllLines(m_CAD.Lines) + "\n"
                + "Anzahl Circles: " + m_CAD.Circles.Count() + " Gesamtlänge: " + m_CAD.LengthOfAllCircles(m_CAD.Circles) + "\n"
                + "Anzahl Polylines: " + m_CAD.Polylines.Count() + " Gesamtlänge: " + m_CAD.LengthOfAllPolylines(m_CAD.Polylines) + "\n");
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogXml = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".xml",
                CheckPathExists = true,
                Filter = "Zeichendatei (*.xml)|*.xml",
                InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "In welche Datei soll gespeichert werden."
            };

            if(saveFileDialogXml.ShowDialog(this) == DialogResult.OK)
                m_CAD.SaveXml(saveFileDialogXml.FileName);

            SaveFileDialog saveFileDialogJson = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".json",
                CheckPathExists = true,
                Filter = "Zeichendatei (*.json)|*.json",
                InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "In welche Datei soll gespeichert werden."
            };

            if (saveFileDialogJson.ShowDialog(this) == DialogResult.OK)
                m_CAD.SaveJson(saveFileDialogJson.FileName);
        }
    }
}
