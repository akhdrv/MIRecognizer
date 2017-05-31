namespace MIRecognizer
{
    partial class PlayerWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindow));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspacePanel = new System.Windows.Forms.Panel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.trackLength = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.PictureBox();
            this.drumsInd = new System.Windows.Forms.Label();
            this.voiceInd = new System.Windows.Forms.Label();
            this.violinInd = new System.Windows.Forms.Label();
            this.saxophoneInd = new System.Windows.Forms.Label();
            this.pianoInd = new System.Windows.Forms.Label();
            this.organInd = new System.Windows.Forms.Label();
            this.electricGuitarInd = new System.Windows.Forms.Label();
            this.acousticGuitarInd = new System.Windows.Forms.Label();
            this.fluteInd = new System.Windows.Forms.Label();
            this.celloInd = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.slider = new System.Windows.Forms.PictureBox();
            this.timeline = new System.Windows.Forms.PictureBox();
            this.playStopButton = new System.Windows.Forms.PictureBox();
            this.sliderTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu.SuspendLayout();
            this.workspacePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playStopButton)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(484, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openToolStripMenuItem.Text = "&Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "&Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearCacheToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.toolsToolStripMenuItem.Text = "&Опции";
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playPauseToolStripMenuItem.Text = "&Играть/Пауза";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.playPauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "&Стоп";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearCacheToolStripMenuItem.Text = "Очистить кэш";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "&Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "&О программе...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // workspacePanel
            // 
            this.workspacePanel.AllowDrop = true;
            this.workspacePanel.BackColor = System.Drawing.Color.White;
            this.workspacePanel.Controls.Add(this.fileNameLabel);
            this.workspacePanel.Controls.Add(this.trackLength);
            this.workspacePanel.Controls.Add(this.stopButton);
            this.workspacePanel.Controls.Add(this.drumsInd);
            this.workspacePanel.Controls.Add(this.voiceInd);
            this.workspacePanel.Controls.Add(this.violinInd);
            this.workspacePanel.Controls.Add(this.saxophoneInd);
            this.workspacePanel.Controls.Add(this.pianoInd);
            this.workspacePanel.Controls.Add(this.organInd);
            this.workspacePanel.Controls.Add(this.electricGuitarInd);
            this.workspacePanel.Controls.Add(this.acousticGuitarInd);
            this.workspacePanel.Controls.Add(this.fluteInd);
            this.workspacePanel.Controls.Add(this.celloInd);
            this.workspacePanel.Controls.Add(this.currentTime);
            this.workspacePanel.Controls.Add(this.slider);
            this.workspacePanel.Controls.Add(this.timeline);
            this.workspacePanel.Controls.Add(this.playStopButton);
            this.workspacePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.workspacePanel.Location = new System.Drawing.Point(0, 24);
            this.workspacePanel.Name = "workspacePanel";
            this.workspacePanel.Size = new System.Drawing.Size(484, 137);
            this.workspacePanel.TabIndex = 1;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.Location = new System.Drawing.Point(104, 112);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(324, 20);
            this.fileNameLabel.TabIndex = 18;
            // 
            // trackLength
            // 
            this.trackLength.BackColor = System.Drawing.Color.Transparent;
            this.trackLength.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackLength.Location = new System.Drawing.Point(434, 112);
            this.trackLength.Name = "trackLength";
            this.trackLength.Size = new System.Drawing.Size(44, 20);
            this.trackLength.TabIndex = 17;
            this.trackLength.Text = "00:00";
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Black;
            this.stopButton.Location = new System.Drawing.Point(33, 89);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(19, 21);
            this.stopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopButton.TabIndex = 16;
            this.stopButton.TabStop = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // drumsInd
            // 
            this.drumsInd.AutoSize = true;
            this.drumsInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drumsInd.Location = new System.Drawing.Point(115, 4);
            this.drumsInd.Name = "drumsInd";
            this.drumsInd.Size = new System.Drawing.Size(76, 21);
            this.drumsInd.TabIndex = 15;
            this.drumsInd.Text = "Ударные";
            // 
            // voiceInd
            // 
            this.voiceInd.AutoSize = true;
            this.voiceInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voiceInd.Location = new System.Drawing.Point(294, 34);
            this.voiceInd.Name = "voiceInd";
            this.voiceInd.Size = new System.Drawing.Size(55, 21);
            this.voiceInd.TabIndex = 14;
            this.voiceInd.Text = "Голос";
            // 
            // violinInd
            // 
            this.violinInd.AutoSize = true;
            this.violinInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violinInd.Location = new System.Drawing.Point(355, 34);
            this.violinInd.Name = "violinInd";
            this.violinInd.Size = new System.Drawing.Size(75, 21);
            this.violinInd.TabIndex = 13;
            this.violinInd.Text = "Скрипка";
            // 
            // saxophoneInd
            // 
            this.saxophoneInd.AutoSize = true;
            this.saxophoneInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saxophoneInd.Location = new System.Drawing.Point(202, 34);
            this.saxophoneInd.Name = "saxophoneInd";
            this.saxophoneInd.Size = new System.Drawing.Size(86, 21);
            this.saxophoneInd.TabIndex = 11;
            this.saxophoneInd.Text = "Саксофон";
            // 
            // pianoInd
            // 
            this.pianoInd.AutoSize = true;
            this.pianoInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pianoInd.Location = new System.Drawing.Point(92, 34);
            this.pianoInd.Name = "pianoInd";
            this.pianoInd.Size = new System.Drawing.Size(104, 21);
            this.pianoInd.TabIndex = 10;
            this.pianoInd.Text = "Фортепиано";
            // 
            // organInd
            // 
            this.organInd.AutoSize = true;
            this.organInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organInd.Location = new System.Drawing.Point(29, 34);
            this.organInd.Name = "organInd";
            this.organInd.Size = new System.Drawing.Size(57, 21);
            this.organInd.TabIndex = 9;
            this.organInd.Text = "Орган";
            // 
            // electricGuitarInd
            // 
            this.electricGuitarInd.AutoSize = true;
            this.electricGuitarInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.electricGuitarInd.Location = new System.Drawing.Point(372, 4);
            this.electricGuitarInd.Name = "electricGuitarInd";
            this.electricGuitarInd.Size = new System.Drawing.Size(91, 21);
            this.electricGuitarInd.TabIndex = 8;
            this.electricGuitarInd.Text = "Эл. Гитара";
            // 
            // acousticGuitarInd
            // 
            this.acousticGuitarInd.AutoSize = true;
            this.acousticGuitarInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acousticGuitarInd.Location = new System.Drawing.Point(268, 4);
            this.acousticGuitarInd.Name = "acousticGuitarInd";
            this.acousticGuitarInd.Size = new System.Drawing.Size(98, 21);
            this.acousticGuitarInd.TabIndex = 7;
            this.acousticGuitarInd.Text = "Акк. Гитара";
            // 
            // fluteInd
            // 
            this.fluteInd.AutoSize = true;
            this.fluteInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fluteInd.Location = new System.Drawing.Point(197, 4);
            this.fluteInd.Name = "fluteInd";
            this.fluteInd.Size = new System.Drawing.Size(65, 21);
            this.fluteInd.TabIndex = 6;
            this.fluteInd.Text = "Флейта";
            // 
            // celloInd
            // 
            this.celloInd.AutoSize = true;
            this.celloInd.BackColor = System.Drawing.Color.White;
            this.celloInd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.celloInd.Location = new System.Drawing.Point(12, 4);
            this.celloInd.Name = "celloInd";
            this.celloInd.Size = new System.Drawing.Size(102, 21);
            this.celloInd.TabIndex = 4;
            this.celloInd.Text = "Виолончель";
            // 
            // currentTime
            // 
            this.currentTime.BackColor = System.Drawing.Color.Transparent;
            this.currentTime.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTime.Location = new System.Drawing.Point(54, 112);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(44, 20);
            this.currentTime.TabIndex = 3;
            this.currentTime.Text = "00:00";
            // 
            // slider
            // 
            this.slider.Enabled = false;
            this.slider.Image = ((System.Drawing.Image)(resources.GetObject("slider.Image")));
            this.slider.Location = new System.Drawing.Point(473, 87);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(5, 25);
            this.slider.TabIndex = 2;
            this.slider.TabStop = false;
            // 
            // timeline
            // 
            this.timeline.BackColor = System.Drawing.Color.Transparent;
            this.timeline.Image = ((System.Drawing.Image)(resources.GetObject("timeline.Image")));
            this.timeline.Location = new System.Drawing.Point(58, 87);
            this.timeline.Name = "timeline";
            this.timeline.Size = new System.Drawing.Size(420, 25);
            this.timeline.TabIndex = 1;
            this.timeline.TabStop = false;
            this.timeline.MouseCaptureChanged += new System.EventHandler(this.timeline_MouseCaptureChanged);
            this.timeline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timeline_MouseDown);
            this.timeline.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Timeline_MouseMove);
            this.timeline.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timeline_MouseUp);
            // 
            // playStopButton
            // 
            this.playStopButton.Image = ((System.Drawing.Image)(resources.GetObject("playStopButton.Image")));
            this.playStopButton.Location = new System.Drawing.Point(7, 87);
            this.playStopButton.Name = "playStopButton";
            this.playStopButton.Size = new System.Drawing.Size(20, 25);
            this.playStopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playStopButton.TabIndex = 0;
            this.playStopButton.TabStop = false;
            this.playStopButton.Click += new System.EventHandler(this.playStopButton_Click);
            // 
            // sliderTimer
            // 
            this.sliderTimer.Tick += new System.EventHandler(this.sliderTimer_Tick);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.workspacePanel);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "PlayerWindow";
            this.Text = "Распознаватель музыкальных инструментов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerWindow_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerWindow_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.workspacePanel.ResumeLayout(false);
            this.workspacePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playStopButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel workspacePanel;
        private System.Windows.Forms.PictureBox playStopButton;
        private System.Windows.Forms.PictureBox timeline;
        private System.Windows.Forms.PictureBox slider;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.Label voiceInd;
        private System.Windows.Forms.Label violinInd;
        private System.Windows.Forms.Label saxophoneInd;
        private System.Windows.Forms.Label pianoInd;
        private System.Windows.Forms.Label organInd;
        private System.Windows.Forms.Label electricGuitarInd;
        private System.Windows.Forms.Label acousticGuitarInd;
        private System.Windows.Forms.Label fluteInd;
        private System.Windows.Forms.Label celloInd;
        private System.Windows.Forms.Label drumsInd;
        private System.Windows.Forms.PictureBox stopButton;
        private System.Windows.Forms.Label trackLength;
        private System.Windows.Forms.Timer sliderTimer;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
    }
}