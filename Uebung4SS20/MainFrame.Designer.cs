namespace Uebung4SS20
{
    partial class MainFrame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.circleButton = new System.Windows.Forms.ToolStripButton();
            this.polylineButton = new System.Windows.Forms.ToolStripButton();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2800, 61);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(131, 57);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(375, 66);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(375, 66);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(259, 57);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(538, 66);
            this.optionenToolStripMenuItem.Text = "Optionen";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineButton,
            this.circleButton,
            this.polylineButton,
            this.infoButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 61);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(2800, 93);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lineButton
            // 
            this.lineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(98, 84);
            this.lineButton.Text = "Linie";
            this.lineButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleButton.Name = "circleButton";
            this.circleButton.RightToLeftAutoMirrorImage = true;
            this.circleButton.Size = new System.Drawing.Size(101, 84);
            this.circleButton.Text = "Kreis";
            this.circleButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.circleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.polylineButton.Image = ((System.Drawing.Image)(resources.GetObject("polylineButton.Image")));
            this.polylineButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.polylineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(156, 84);
            this.polylineButton.Text = "Polylinie";
            this.polylineButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.polylineButton.Click += new System.EventHandler(this.polylineButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(86, 84);
            this.infoButton.Text = "Info";
            this.infoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 45, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2800, 63);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(354, 48);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStripStatusLabel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 154);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2800, 1198);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2800, 1415);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrame";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton circleButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton polylineButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton infoButton;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
    }
}

