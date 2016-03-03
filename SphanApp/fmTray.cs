using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace SphanApp {
	public partial class fmTray : Form {
		public fmTray() {
			InitializeComponent();
		}

		readonly KeyboardHook keyboardHook = new KeyboardHook();

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

		private void miStartOnWindowsStartup_Click(object sender, EventArgs e) {
			this.miStartOnWindowsStartup.Checked = !this.miStartOnWindowsStartup.Checked;

			toggleWindowsStartup(this.miStartOnWindowsStartup.Checked);

			var settings = SphanSettings.Load();

			settings.LaunchAtWindowsStartup = this.miStartOnWindowsStartup.Checked;
			settings.Save();
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
		/// Load and apply settings.
		/// </summary>
		private void applySettings() {
			// Load all settings.
			var settings = SphanSettings.Load();
			settings.Save();

			/**
			 * GENERAL
			 */

			// Session switch
			if (settings.PauseSpotifyOnWindowsLock ||
				settings.ResumtPlayOnWindowsUnlock)
				SystemEvents.SessionSwitch += sessionSwitch;

			// Windows startup
			if (settings.LaunchAtWindowsStartup &&
			    !isProgramInWindowsStartup())
				toggleWindowsStartup(true);

			if (!settings.LaunchAtWindowsStartup &&
			    isProgramInWindowsStartup())
				toggleWindowsStartup(false);

			this.miStartOnWindowsStartup.Checked = settings.LaunchAtWindowsStartup;

			// App startup and minimize

			/**
			 * HOTKEYS
			 */

			// Set interpreter.
			this.keyboardHook.KeyPressed += keyboardHookOnKeyPressed;

			// Cycle and add all hotkeys.
			foreach (var entry in settings.HotkeyEntries) {
				var modifier = KeyboardHookHelper.CompileModifierKeys(
					entry.KeyAlt,
					entry.KeyCtrl,
					entry.KeyShift,
					entry.KeyWin);

				this.keyboardHook.RegisterHotKey(
					modifier,
					entry.Key);
			}

			/**
			 * TOAST
			 */

			/**
			 * WEBHOOKS
			 */
		}

		/// <summary>
		/// Checks in the Windows registry whether the app is setup for startup.
		/// </summary>
		private bool isProgramInWindowsStartup() {
			var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

			if (key == null)
				return false;

			var value = key.GetValue(Application.ProductName);

			if (value == null)
				return false;

			var value_ins = value.ToString();

			return value_ins != "0";
		}

		/// <summary>
		/// Translate global hotkeys and perform acordingly.
		/// </summary>
		private void keyboardHookOnKeyPressed(object sender, KeyPressedEventArgs e) {
			bool alt;
			bool ctrl;
			bool shift;
			bool win;

			KeyboardHookHelper.TranslateModifierKeys(
				e.Modifier,
				out alt,
				out ctrl,
				out shift,
				out win);

			var entry = SphanSettings.MatchHotkeyEntry(
				alt,
				ctrl,
				shift,
				win,
				e.Key);

			if (entry == null)
				return;

			switch (entry.Command) {
				case SpotifyCommand.CopySpotifyUriToClipboard:
					Clipboard.SetText(SpotifyControl.GetSpotifyUri());
					break;

				case SpotifyCommand.CopyTrackInfoToClipboard:
					Clipboard.SetText(SpotifyControl.GetTrackInfo());
					break;

				case SpotifyCommand.FastForward:
					// TODO: SpotifyCommand.FastForward
					break;

				case SpotifyCommand.Mute:
					SpotifyControl.ToggleMute();
					break;

				case SpotifyCommand.NextTrack:
					SpotifyControl.NextTrack();
					break;

				case SpotifyCommand.PlayPause:
					SpotifyControl.PlayPause();
					break;

				case SpotifyCommand.PreviousTrack:
					SpotifyControl.PreviousTrack();
					break;

				case SpotifyCommand.Rewind:
					// TODO: SpotifyCommand.Rewind
					break;

				case SpotifyCommand.ShowToast:
					// TODO: SpotifyCommand.ShowToast
					break;

				case SpotifyCommand.Stop:
					SpotifyControl.Stop();
					break;

				case SpotifyCommand.ToggleWindowState:
					SpotifyControl.ToggleWindowState();
					break;

				case SpotifyCommand.VolumeDown:
					SpotifyControl.VolumeDown();
					break;

				case SpotifyCommand.VolumeUp:
					SpotifyControl.VolumeUp();
					break;
			}
		}

		/// <summary>
		/// Toggle play/pause when moving in/out of Windows lock.
		/// </summary>
		private void sessionSwitch(object sender, SessionSwitchEventArgs e) {
			// Load all settings.
			var settings = SphanSettings.Load();

			switch (e.Reason) {
				case SessionSwitchReason.SessionLock:
					if (settings.PauseSpotifyOnWindowsLock &&
						SpotifyControl.IsPlaying)
						SpotifyControl.PlayPause();

					break;

				case SessionSwitchReason.SessionUnlock:
					if (settings.ResumtPlayOnWindowsUnlock &&
						!SpotifyControl.IsPlaying)
						SpotifyControl.PlayPause();

					break;
			}
		}

		/// <summary>
		/// Toggles the startup state of the app.
		/// </summary>
		private void toggleWindowsStartup(bool mode) {
			var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

			if (key == null)
				return;

			if (mode)
				key.SetValue(Application.ProductName, Application.ExecutablePath);
			else
				key.DeleteValue(Application.ProductName);
		}

		#endregion
	}
}