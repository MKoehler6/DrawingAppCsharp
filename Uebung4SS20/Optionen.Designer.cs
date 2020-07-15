namespace Uebung4SS20
{
    partial class Optionen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.StandardColor = new System.Windows.Forms.Button();
            this.RubberbandColor = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Abbrechen = new System.Windows.Forms.Button();
            this.colorStandard = new System.Windows.Forms.Label();
            this.colorRubberb = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.68071F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.31929F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.StandardColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RubberbandColor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorStandard, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorRubberb, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(199, 148);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1027, 334);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "Standard Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 83);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rubberband Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 83);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stroke";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(388, 85);
            this.label4.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "6",
            "8",
            "10"});
            this.comboBox3.Location = new System.Drawing.Point(397, 169);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(502, 45);
            this.comboBox3.TabIndex = 6;
            // 
            // StandardColor
            // 
            this.StandardColor.Location = new System.Drawing.Point(397, 3);
            this.StandardColor.Name = "StandardColor";
            this.StandardColor.Size = new System.Drawing.Size(502, 77);
            this.StandardColor.TabIndex = 7;
            this.StandardColor.Text = "Choose Color";
            this.StandardColor.UseVisualStyleBackColor = true;
            this.StandardColor.Click += new System.EventHandler(this.standardColor_Click);
            // 
            // RubberbandColor
            // 
            this.RubberbandColor.Location = new System.Drawing.Point(397, 86);
            this.RubberbandColor.Name = "RubberbandColor";
            this.RubberbandColor.Size = new System.Drawing.Size(502, 77);
            this.RubberbandColor.TabIndex = 8;
            this.RubberbandColor.Text = "Choose Color";
            this.RubberbandColor.UseVisualStyleBackColor = true;
            this.RubberbandColor.Click += new System.EventHandler(this.RubberbandColor_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(321, 529);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(323, 116);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.Location = new System.Drawing.Point(812, 529);
            this.Abbrechen.Name = "Abbrechen";
            this.Abbrechen.Size = new System.Drawing.Size(312, 115);
            this.Abbrechen.TabIndex = 2;
            this.Abbrechen.Text = "Abbrechen";
            this.Abbrechen.UseVisualStyleBackColor = true;
            this.Abbrechen.Click += new System.EventHandler(this.Abbrechen_Click);
            // 
            // colorStandard
            // 
            this.colorStandard.AutoSize = true;
            this.colorStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorStandard.Location = new System.Drawing.Point(905, 0);
            this.colorStandard.Name = "colorStandard";
            this.colorStandard.Size = new System.Drawing.Size(119, 83);
            this.colorStandard.TabIndex = 9;
            // 
            // colorRubberb
            // 
            this.colorRubberb.AutoSize = true;
            this.colorRubberb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorRubberb.Location = new System.Drawing.Point(905, 83);
            this.colorRubberb.Name = "colorRubberb";
            this.colorRubberb.Size = new System.Drawing.Size(119, 83);
            this.colorRubberb.TabIndex = 10;
            // 
            // Optionen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 824);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Optionen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Abbrechen;
        private System.Windows.Forms.Button StandardColor;
        private System.Windows.Forms.Button RubberbandColor;
        private System.Windows.Forms.Label colorStandard;
        private System.Windows.Forms.Label colorRubberb;
    }
}