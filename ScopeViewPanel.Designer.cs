namespace SDRSharp.ScopeView
{
    partial class ScopeViewPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scopePanel = new System.Windows.Forms.Panel();
            this.markerTimer = new System.Windows.Forms.Timer(this.components);
            this.bothChannelsCheckbox = new System.Windows.Forms.CheckBox();
            this.scopeSpeedLbl = new System.Windows.Forms.Label();
            this.scopeSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.amplitudeLbl = new System.Windows.Forms.Label();
            this.amplitudeTrackBar = new System.Windows.Forms.TrackBar();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.cbGreenScope = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scopeSpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.scopePanel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 257);
            this.panel1.TabIndex = 0;
            // 
            // scopePanel
            // 
            this.scopePanel.BackColor = System.Drawing.Color.Black;
            this.scopePanel.Location = new System.Drawing.Point(3, 29);
            this.scopePanel.Name = "scopePanel";
            this.scopePanel.Size = new System.Drawing.Size(800, 175);
            this.scopePanel.TabIndex = 0;
            // 
            // bothChannelsCheckbox
            // 
            this.bothChannelsCheckbox.AutoSize = true;
            this.bothChannelsCheckbox.Location = new System.Drawing.Point(0, 360);
            this.bothChannelsCheckbox.Name = "bothChannelsCheckbox";
            this.bothChannelsCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bothChannelsCheckbox.Size = new System.Drawing.Size(95, 17);
            this.bothChannelsCheckbox.TabIndex = 11;
            this.bothChannelsCheckbox.Text = "Both Channels";
            this.bothChannelsCheckbox.UseVisualStyleBackColor = true;
            // 
            // scopeSpeedLbl
            // 
            this.scopeSpeedLbl.AutoSize = true;
            this.scopeSpeedLbl.Location = new System.Drawing.Point(12, 325);
            this.scopeSpeedLbl.Name = "scopeSpeedLbl";
            this.scopeSpeedLbl.Size = new System.Drawing.Size(38, 13);
            this.scopeSpeedLbl.TabIndex = 10;
            this.scopeSpeedLbl.Text = "Speed";
            // 
            // scopeSpeedTrackBar
            // 
            this.scopeSpeedTrackBar.Location = new System.Drawing.Point(49, 321);
            this.scopeSpeedTrackBar.Maximum = 20;
            this.scopeSpeedTrackBar.Minimum = 1;
            this.scopeSpeedTrackBar.Name = "scopeSpeedTrackBar";
            this.scopeSpeedTrackBar.Size = new System.Drawing.Size(164, 45);
            this.scopeSpeedTrackBar.TabIndex = 9;
            this.scopeSpeedTrackBar.TickFrequency = 2;
            this.scopeSpeedTrackBar.Value = 4;
            // 
            // amplitudeLbl
            // 
            this.amplitudeLbl.AutoSize = true;
            this.amplitudeLbl.Location = new System.Drawing.Point(-3, 279);
            this.amplitudeLbl.Name = "amplitudeLbl";
            this.amplitudeLbl.Size = new System.Drawing.Size(53, 13);
            this.amplitudeLbl.TabIndex = 8;
            this.amplitudeLbl.Text = "Amplitude";
            // 
            // amplitudeTrackBar
            // 
            this.amplitudeTrackBar.Location = new System.Drawing.Point(49, 277);
            this.amplitudeTrackBar.Maximum = 100;
            this.amplitudeTrackBar.Minimum = 1;
            this.amplitudeTrackBar.Name = "amplitudeTrackBar";
            this.amplitudeTrackBar.Size = new System.Drawing.Size(164, 45);
            this.amplitudeTrackBar.TabIndex = 7;
            this.amplitudeTrackBar.TickFrequency = 10;
            this.amplitudeTrackBar.Value = 25;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Location = new System.Drawing.Point(110, 360);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 12;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            this.cbActive.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(173, 363);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(36, 21);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "S";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cbGreenScope
            // 
            this.cbGreenScope.AutoSize = true;
            this.cbGreenScope.Location = new System.Drawing.Point(110, 388);
            this.cbGreenScope.Name = "cbGreenScope";
            this.cbGreenScope.Size = new System.Drawing.Size(87, 17);
            this.cbGreenScope.TabIndex = 14;
            this.cbGreenScope.Text = "Green scope";
            this.cbGreenScope.UseVisualStyleBackColor = true;
            this.cbGreenScope.CheckedChanged += new System.EventHandler(this.cbGreenScope_CheckedChanged);
            // 
            // ScopeViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbGreenScope);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.bothChannelsCheckbox);
            this.Controls.Add(this.scopeSpeedLbl);
            this.Controls.Add(this.scopeSpeedTrackBar);
            this.Controls.Add(this.amplitudeLbl);
            this.Controls.Add(this.amplitudeTrackBar);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "ScopeViewPanel";
            this.Size = new System.Drawing.Size(226, 429);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scopeSpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer markerTimer;
        private System.Windows.Forms.Panel scopePanel;
        private System.Windows.Forms.CheckBox bothChannelsCheckbox;
        private System.Windows.Forms.Label scopeSpeedLbl;
        private System.Windows.Forms.TrackBar scopeSpeedTrackBar;
        private System.Windows.Forms.Label amplitudeLbl;
        private System.Windows.Forms.TrackBar amplitudeTrackBar;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox cbGreenScope;
    }
}
