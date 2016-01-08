using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SphanApp {
	public class SphanSettings {
		#region General

		public bool LaunchAtWindowsStartup { get; set; }

		public bool LaunchSpotifyOnAppStart { get; set; }

		public bool MinimizeSpotifyOnLaunch { get; set; }

		public bool CloseSpotifyOnAppClose { get; set; }

		public bool PauseSpotifyOnWindowsLock { get; set; }

		public bool ResumtPlayOnWindowsUnlock { get; set; }

		#endregion
		#region Hotkeys

		public bool EnableHotkeys { get; set; }

		public List<HotkeyEntry> HotkeyEntries = new List<HotkeyEntry>();

		#endregion
		#region Toast

		public bool EnableToast { get; set; }

		public bool OnlyShowToastOnHotkey { get; set; }

		public int ToastWidth { get; set; }

		public int ToastHeight { get; set; }

		public int ToastLeft { get; set; }

		public int ToastTop { get; set; }

		public int ToastFadeOutTime { get; set; }

		public int ToastFadeOutLength { get; set; }

		#endregion
		#region Webhooks

		public bool EnableWebhooks { get; set; }

		public int WebserverPort { get; set; }

		public bool WebserverBasicAuth { get; set; }

		public string WebserverUsername { get; set; }

		public string WebserverPassword { get; set; }

		#endregion
		#region Methods

		public static SphanSettings Load() {
			SphanSettings settings = null;

			var filename =
				Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('.')) +
				".json";

			if (File.Exists(filename))
				settings = new JavaScriptSerializer().Deserialize<SphanSettings>(File.ReadAllText(filename));

			if (settings != null)
				return settings;

			// Default values
			settings = new SphanSettings {
				// General
				LaunchAtWindowsStartup = true,
				LaunchSpotifyOnAppStart = true,
				MinimizeSpotifyOnLaunch = true,
				CloseSpotifyOnAppClose = true,
				PauseSpotifyOnWindowsLock = true,
				ResumtPlayOnWindowsUnlock = true,

				// Hotkeys
				EnableHotkeys = true,
				HotkeyEntries = new List<HotkeyEntry> {
					new HotkeyEntry {
						Command = SpotifyCommand.PlayPause,
						KeyCtrl = true,
						KeyAlt = true,
						Key = Keys.Home
					},
					new HotkeyEntry {
						Command = SpotifyCommand.Stop,
						KeyCtrl = true,
						KeyAlt = true,
						Key = Keys.End
					},
					new HotkeyEntry {
						Command = SpotifyCommand.NextTrack,
						KeyCtrl = true,
						KeyAlt = true,
						Key = Keys.PageDown
					},
					new HotkeyEntry {
						Command = SpotifyCommand.PreviousTrack,
						KeyCtrl = true,
						KeyAlt = true,
						Key = Keys.PageUp
					}
				},

				// Toast
				EnableToast = true,
				ToastWidth = 300,
				ToastHeight = 75,
				ToastLeft = Screen.PrimaryScreen.WorkingArea.Width - 305,
				ToastTop = Screen.PrimaryScreen.WorkingArea.Height - 80,
				ToastFadeOutTime = 1000,
				ToastFadeOutLength = 250,

				// Webhooks

				WebserverPort = 18709
			};

			return settings;
		}

		public void Save() {
			var filename =
				Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('.')) +
				".json";

			File.WriteAllText(
				filename,
				new JavaScriptSerializer().Serialize(this));
		}

		#endregion
	}

	public enum SpotifyCommand {
		PlayPause,
		Stop,
		PreviousTrack,
		NextTrack,
		Mute,
		VolumeDown,
		VolumeUp,
		ShowToast,
		MinimizeRestoreSpotify,
		CopyTrackInfoToClipboard,
		CopySpotifyUriToClipboard,
		FastForward,
		Rewind
	}

	public class HotkeyEntry {
		public SpotifyCommand Command { get; set; }
		public bool KeyCtrl { get; set; }
		public bool KeyShift { get; set; }
		public bool KeyAlt { get; set; }
		public bool KeyWin { get; set; }
		public Keys Key { get; set; }
	}
}