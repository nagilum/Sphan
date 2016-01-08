using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SphanApp {
	public partial class fmTray : Form {
		public fmTray() {
			InitializeComponent();
		}

		#region Form Methods

		private void fmTray_Load(object sender, EventArgs e) {
			this.Hide();

			// 
			this.applySettings();
		}

		private void miSettings_Click(object sender, EventArgs e) {
			var fmSettings = new fmSettings();
			fmSettings.Show(this);
		}

		private void miAbout_Click(object sender, EventArgs e) {
			var fmAbout = new fmAbout();
			fmAbout.Show(this);
		}

		private void miExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		#endregion
		#region App Methods

		/// <summary>
		/// 
		/// </summary>
		private void applySettings() {
			// Load all settings.
			var settings = SphanSettings.Load();
			settings.Save();

			// General
			if (settings.PauseSpotifyOnWindowsLock ||
				settings.ResumtPlayOnWindowsUnlock)
				SystemEvents.SessionSwitch += sessionSwitch;

			// Hotkeys

			// Toast

			// Webhooks
		}

		/// <summary>
		/// 
		/// </summary>
		private void sessionSwitch(object sender, SessionSwitchEventArgs e) {
			// Load all settings.
			var settings = SphanSettings.Load();

			switch (e.Reason) {
				case SessionSwitchReason.SessionLock:
					if (settings.PauseSpotifyOnWindowsLock) {
					}

					break;

				case SessionSwitchReason.SessionUnlock:
					if (settings.ResumtPlayOnWindowsUnlock) {
					}

					break;
			}
		}

		#endregion
	}
}