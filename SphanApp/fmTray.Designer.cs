namespace SphanApp {
	partial class fmTray {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTray));
			this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.miExit = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.miStartOnWindowsStartup = new System.Windows.Forms.ToolStripMenuItem();
			this.cmTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// niTray
			// 
			this.niTray.ContextMenuStrip = this.cmTray;
			this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
			this.niTray.Text = "Sphan";
			this.niTray.Visible = true;
			// 
			// cmTray
			// 
			this.cmTray.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings,
            this.miStartOnWindowsStartup,
            this.toolStripMenuItem1,
            this.miAbout,
            this.toolStripMenuItem3,
            this.miExit});
			this.cmTray.Name = "cmTray";
			this.cmTray.Size = new System.Drawing.Size(209, 126);
			// 
			// miSettings
			// 
			this.miSettings.Name = "miSettings";
			this.miSettings.Size = new System.Drawing.Size(208, 22);
			this.miSettings.Text = "&Settings";
			this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
			// 
			// miAbout
			// 
			this.miAbout.Name = "miAbout";
			this.miAbout.Size = new System.Drawing.Size(208, 22);
			this.miAbout.Text = "&About";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
			// 
			// miExit
			// 
			this.miExit.Name = "miExit";
			this.miExit.Size = new System.Drawing.Size(208, 22);
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Should not see me!";
			// 
			// miStartOnWindowsStartup
			// 
			this.miStartOnWindowsStartup.Name = "miStartOnWindowsStartup";
			this.miStartOnWindowsStartup.Size = new System.Drawing.Size(208, 22);
			this.miStartOnWindowsStartup.Text = "Start on &Windows Startup";
			this.miStartOnWindowsStartup.Click += new System.EventHandler(this.miStartOnWindowsStartup_Click);
			// 
			// fmTray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(228, 28);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmTray";
			this.ShowInTaskbar = false;
			this.Text = "Sphan";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.fmTray_Load);
			this.cmTray.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon niTray;
		private System.Windows.Forms.ContextMenuStrip cmTray;
		private System.Windows.Forms.ToolStripMenuItem miSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem miAbout;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem miExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem miStartOnWindowsStartup;
	}
}