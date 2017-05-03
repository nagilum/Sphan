using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SphanApp {
	public class SpotifyControl {
		#region DLL Import

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll")]
		internal static extern IntPtr SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

		[DllImport("user32.dll")]
		internal static extern IntPtr SetFocus(IntPtr hWnd);

		[DllImport("user32.dll")]
		internal static extern bool SetForegroundWindow(IntPtr hWnd);

	    [DllImport("user32.dll", SetLastError = true)]
	    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        internal const uint WM_APPCOMMAND = 0x0319;
		internal const int WM_SETTEXT = 0x000C;

		internal const int SW_SHOWMINIMIZED = 2;
		internal const int SW_SHOWNOACTIVATE = 4;
		internal const int SW_SHOW = 5;
		internal const int SW_RESTORE = 9;

		internal const int WM_CLOSE = 0x10;
		internal const int WM_QUIT = 0x12;

		internal struct WINDOWPLACEMENT {
			public int length;
			public int flags;
			public int showCmd;
			public System.Drawing.Point ptMinPosition;
			public System.Drawing.Point ptMaxPosition;
			public System.Drawing.Rectangle rcNormalPosition;
		}

	    public static void PressKey(Keys key, bool up) {
	        const int KEYEVENTF_EXTENDEDKEY = 0x1;
	        const int KEYEVENTF_KEYUP = 0x2;

	        if (up) {
	            keybd_event((byte) key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr) 0);
	        }
	        else {
	            keybd_event((byte) key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr) 0);
	        }
	    }

	    #endregion
        #region Public Commands

        /// <summary>
        /// Toggle play/pause.
        /// </summary>
        public static void PlayPause() {
            //SendMessage(
            //	getSpotifyHandle(),
            //	WM_APPCOMMAND,
            //	IntPtr.Zero,
            //	new IntPtr(917504));

            PressKey(Keys.MediaPlayPause, false);
            PressKey(Keys.MediaPlayPause, true);
        }

		/// <summary>
		/// Stop playing.
		/// </summary>
		public static void Stop() {
            //SendMessage(
            //	getSpotifyHandle(),
            //	WM_APPCOMMAND,
            //	IntPtr.Zero,
		    //	new IntPtr(851968));

		    PressKey(Keys.MediaStop, false);
		    PressKey(Keys.MediaStop, true);
        }

		/// <summary>
		/// Trigger previous track.
		/// </summary>
		public static void PreviousTrack() {
            //SendMessage(
            //	getSpotifyHandle(),
            //	WM_APPCOMMAND,
            //	IntPtr.Zero,
		    //	new IntPtr(786432));

		    PressKey(Keys.MediaPreviousTrack, false);
		    PressKey(Keys.MediaPreviousTrack, true);
        }

		/// <summary>
		/// Trigger next track.
		/// </summary>
		public static void NextTrack() {
			//SendMessage(
			//	getSpotifyHandle(),
			//	WM_APPCOMMAND,
			//	IntPtr.Zero,
			//	new IntPtr(720896));

            PressKey(Keys.MediaNextTrack, false);
		    PressKey(Keys.MediaNextTrack, true);
        }

		/// <summary>
		/// Toggle mute.
		/// </summary>
		public static void ToggleMute() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(524288));
		}

		/// <summary>
		/// Turn volume down, slightly.
		/// </summary>
		public static void VolumeDown() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(589824));
		}

		/// <summary>
		/// Turn volume up, slightly.
		/// </summary>
		public static void VolumeUp() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(655360));
		}

		/// <summary>
		/// Minimize/restore the main window.
		/// </summary>
		public static void ToggleWindowState() {
			var hwnd = getSpotifyHandle();

			if (hwnd == IntPtr.Zero)
				return;

			var placement = new WINDOWPLACEMENT();
			GetWindowPlacement(hwnd, ref placement);

			if (placement.showCmd == SW_SHOWMINIMIZED) {
				ShowWindow(hwnd, SW_RESTORE);
				SetForegroundWindow(hwnd);
				SetFocus(hwnd);
			}
			else {
				ShowWindow(hwnd, SW_SHOWMINIMIZED);
			}
		}

		#endregion
		#region Public Info

		/// <summary>
		/// Get the current track playing in Spotify.
		/// </summary>
		public static string GetTrackInfo() {
			var proc = getSpotifyProcess();

			if (proc == null)
				return null;

			return proc.MainWindowTitle == "Spotify"
				? null
				: proc.MainWindowTitle;
		}

		/// <summary>
		/// 
		/// </summary>
		public static string GetSpotifyUri() {
			return null;
		}

		/// <summary>
		/// Determines whether or not Spotify is currently playing a track.
		/// </summary>
		public static bool IsPlaying {
			get {
				var proc = getSpotifyProcess();
				return proc != null &&
				       proc.MainWindowTitle != "Spotify";
			}
		}

		/// <summary>
		/// Determines whether or not Spotify is running.
		/// </summary>
		public static bool IsRunning {
			get {
				return getSpotifyProcess() != null;
			}
		}

		#endregion
		#region Helper Functions/Properties

		/// <summary>
		/// Get the Spotify main window handle.
		/// </summary>
		private static IntPtr getSpotifyHandle() {
			return FindWindow("SpotifyMainWindow", null);
		}

		/// <summary>
		/// Get the Spotify main window process.
		/// </summary>
		private static Process getSpotifyProcess() {
			return Process
				.GetProcesses()
				.FirstOrDefault(p => p.ProcessName.Contains("Spotify") &&
				                     !string.IsNullOrWhiteSpace(p.MainWindowTitle));
		}

		#endregion
	}
}
