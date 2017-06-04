namespace MIRecognizer
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.trackLengthLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.PictureBox();
            this.currentTime = new System.Windows.Forms.Label();
            this.slider = new System.Windows.Forms.PictureBox();
            this.timeline = new System.Windows.Forms.PictureBox();
            this.playPauseButton = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gacLabel = new System.Windows.Forms.Label();
            this.celLabel = new System.Windows.Forms.Label();
            this.saxLabel = new System.Windows.Forms.Label();
            this.gelLabel = new System.Windows.Forms.Label();
            this.vioLabel = new System.Windows.Forms.Label();
            this.fluLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.voiLabel = new System.Windows.Forms.Label();
            this.orgLabel = new System.Windows.Forms.Label();
            this.piaLabel = new System.Windows.Forms.Label();
            this.druLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearCacheToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear Cache";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.toolsToolStripMenuItem.Text = "&Playback";
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.ShortcutKeyDisplayString = "Space";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.fileNameLabel);
            this.panel1.Controls.Add(this.trackLengthLabel);
            this.panel1.Controls.Add(this.stopButton);
            this.panel1.Controls.Add(this.currentTime);
            this.panel1.Controls.Add(this.slider);
            this.panel1.Controls.Add(this.timeline);
            this.panel1.Controls.Add(this.playPauseButton);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 122);
            this.panel1.TabIndex = 1;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.Location = new System.Drawing.Point(104, 94);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(324, 20);
            this.fileNameLabel.TabIndex = 25;
            // 
            // trackLengthLabel
            // 
            this.trackLengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.trackLengthLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackLengthLabel.Location = new System.Drawing.Point(434, 94);
            this.trackLengthLabel.Name = "trackLengthLabel";
            this.trackLengthLabel.Size = new System.Drawing.Size(44, 20);
            this.trackLengthLabel.TabIndex = 24;
            this.trackLengthLabel.Text = "00:00";
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Black;
            this.stopButton.Location = new System.Drawing.Point(33, 68);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(19, 21);
            this.stopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopButton.TabIndex = 23;
            this.stopButton.TabStop = false;
            // 
            // currentTime
            // 
            this.currentTime.BackColor = System.Drawing.Color.Transparent;
            this.currentTime.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTime.Location = new System.Drawing.Point(54, 94);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(44, 20);
            this.currentTime.TabIndex = 22;
            this.currentTime.Text = "00:00";
            // 
            // slider
            // 
            this.slider.Enabled = false;
            this.slider.Image = ((System.Drawing.Image)(resources.GetObject("slider.Image")));
            this.slider.Location = new System.Drawing.Point(473, 66);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(5, 25);
            this.slider.TabIndex = 21;
            this.slider.TabStop = false;
            // 
            // timeline
            // 
            this.timeline.BackColor = System.Drawing.Color.Transparent;
            this.timeline.Enabled = false;
            this.timeline.Image = ((System.Drawing.Image)(resources.GetObject("timeline.Image")));
            this.timeline.Location = new System.Drawing.Point(58, 66);
            this.timeline.Name = "timeline";
            this.timeline.Size = new System.Drawing.Size(420, 25);
            this.timeline.TabIndex = 20;
            this.timeline.TabStop = false;
            // 
            // playPauseButton
            // 
            this.playPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("playPauseButton.Image")));
            this.playPauseButton.Location = new System.Drawing.Point(7, 66);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(20, 25);
            this.playPauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playPauseButton.TabIndex = 19;
            this.playPauseButton.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.12121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.88129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.36114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.9621F));
            this.tableLayoutPanel1.Controls.Add(this.gacLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.celLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saxLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.gelLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.vioLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fluLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 56);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gacLabel
            // 
            this.gacLabel.AutoSize = true;
            this.gacLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gacLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gacLabel.Location = new System.Drawing.Point(383, 0);
            this.gacLabel.Name = "gacLabel";
            this.gacLabel.Size = new System.Drawing.Size(98, 28);
            this.gacLabel.TabIndex = 9;
            this.gacLabel.Text = "Ac. Guitar";
            this.gacLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // celLabel
            // 
            this.celLabel.AutoSize = true;
            this.celLabel.BackColor = System.Drawing.Color.Transparent;
            this.celLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.celLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.celLabel.Location = new System.Drawing.Point(3, 0);
            this.celLabel.Name = "celLabel";
            this.celLabel.Size = new System.Drawing.Size(52, 28);
            this.celLabel.TabIndex = 5;
            this.celLabel.Text = "Cello";
            this.celLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saxLabel
            // 
            this.saxLabel.AutoSize = true;
            this.saxLabel.BackColor = System.Drawing.Color.Transparent;
            this.saxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saxLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saxLabel.Location = new System.Drawing.Point(177, 0);
            this.saxLabel.Name = "saxLabel";
            this.saxLabel.Size = new System.Drawing.Size(106, 28);
            this.saxLabel.TabIndex = 8;
            this.saxLabel.Text = "Saxophone";
            this.saxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gelLabel
            // 
            this.gelLabel.AutoSize = true;
            this.gelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gelLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gelLabel.Location = new System.Drawing.Point(289, 0);
            this.gelLabel.Name = "gelLabel";
            this.gelLabel.Size = new System.Drawing.Size(88, 28);
            this.gelLabel.TabIndex = 10;
            this.gelLabel.Text = "El. Guitar";
            this.gelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vioLabel
            // 
            this.vioLabel.AutoSize = true;
            this.vioLabel.BackColor = System.Drawing.Color.Transparent;
            this.vioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vioLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vioLabel.Location = new System.Drawing.Point(61, 0);
            this.vioLabel.Name = "vioLabel";
            this.vioLabel.Size = new System.Drawing.Size(56, 28);
            this.vioLabel.TabIndex = 6;
            this.vioLabel.Text = "Violin";
            this.vioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fluLabel
            // 
            this.fluLabel.AutoSize = true;
            this.fluLabel.BackColor = System.Drawing.Color.Transparent;
            this.fluLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fluLabel.Location = new System.Drawing.Point(123, 0);
            this.fluLabel.Name = "fluLabel";
            this.fluLabel.Size = new System.Drawing.Size(48, 28);
            this.fluLabel.TabIndex = 7;
            this.fluLabel.Text = "Flute";
            this.fluLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.voiLabel, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.orgLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.piaLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.druLabel, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 31);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(478, 22);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // voiLabel
            // 
            this.voiLabel.AutoSize = true;
            this.voiLabel.BackColor = System.Drawing.Color.Transparent;
            this.voiLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.voiLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voiLabel.Location = new System.Drawing.Point(319, 0);
            this.voiLabel.Name = "voiLabel";
            this.voiLabel.Size = new System.Drawing.Size(73, 22);
            this.voiLabel.TabIndex = 9;
            this.voiLabel.Text = "Voice";
            this.voiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orgLabel
            // 
            this.orgLabel.AutoSize = true;
            this.orgLabel.BackColor = System.Drawing.Color.Transparent;
            this.orgLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orgLabel.Location = new System.Drawing.Point(82, 0);
            this.orgLabel.Name = "orgLabel";
            this.orgLabel.Size = new System.Drawing.Size(73, 22);
            this.orgLabel.TabIndex = 7;
            this.orgLabel.Text = "Organ";
            this.orgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // piaLabel
            // 
            this.piaLabel.AutoSize = true;
            this.piaLabel.BackColor = System.Drawing.Color.Transparent;
            this.piaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piaLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.piaLabel.Location = new System.Drawing.Point(161, 0);
            this.piaLabel.Name = "piaLabel";
            this.piaLabel.Size = new System.Drawing.Size(73, 22);
            this.piaLabel.TabIndex = 6;
            this.piaLabel.Text = "Piano";
            this.piaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // druLabel
            // 
            this.druLabel.AutoSize = true;
            this.druLabel.BackColor = System.Drawing.Color.Transparent;
            this.druLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.druLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.druLabel.Location = new System.Drawing.Point(240, 0);
            this.druLabel.Name = "druLabel";
            this.druLabel.Size = new System.Drawing.Size(73, 22);
            this.druLabel.TabIndex = 8;
            this.druLabel.Text = "Drums";
            this.druLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 146);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "View";
            this.Text = "Musical Instruments Recognizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label celLabel;
        private System.Windows.Forms.Label saxLabel;
        private System.Windows.Forms.Label fluLabel;
        private System.Windows.Forms.Label vioLabel;
        private System.Windows.Forms.Label gacLabel;
        private System.Windows.Forms.Label gelLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label voiLabel;
        private System.Windows.Forms.Label druLabel;
        private System.Windows.Forms.Label orgLabel;
        private System.Windows.Forms.Label piaLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label trackLengthLabel;
        private System.Windows.Forms.PictureBox stopButton;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.PictureBox slider;
        private System.Windows.Forms.PictureBox timeline;
        private System.Windows.Forms.PictureBox playPauseButton;
    }
}