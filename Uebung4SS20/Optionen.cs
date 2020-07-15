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
    public partial class Optionen : Form
    {
        public Optionen()
        {
            InitializeComponent();
            comboBox3.Text = geometryLib.Properties.Settings1.Default.Strichstaerke.ToString();
            colorStandard.BackColor = geometryLib.Properties.Settings1.Default.FarbeStandard;
            colorRubberb.BackColor = geometryLib.Properties.Settings1.Default.GummibandFarbe;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            geometryLib.Properties.Settings1.Default.Strichstaerke =
                float.Parse(comboBox3.Text);
            DialogResult = DialogResult.OK;
            // Speichern der Properties in AppData-Verzeichnis
            geometryLib.Properties.Settings1.Default.Save();
        }

        private void Abbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void standardColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                geometryLib.Properties.Settings1.Default.FarbeStandard = colorDialog.Color;
                colorStandard.BackColor = colorDialog.Color;
            }
        }

        private void RubberbandColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                geometryLib.Properties.Settings1.Default.GummibandFarbe = colorDialog.Color;
                colorRubberb.BackColor = colorDialog.Color;
            }
        }
    }
}
