using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

		[DllImport("user32.dll")]
		internal static extern IntPtr SetFocus(IntPtr hWnd);

		[DllImport("user32.dll")]
		internal static extern bool SetForegroundWindow(IntPtr hWnd);

		internal const uint WM_APPCOMMAND = 0x0319;

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

		#endregion
		#region Public Commands

		/// <summary>
		/// 
		/// </summary>
		public static void PlayPause() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(917504));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void Stop() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(851968));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void PreviousTrack() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(786432));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void NextTrack() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(720896));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void ToggleMute() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(524288));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void VolumeDown() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(589824));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void VolumeUp() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(655360));
		}

		/// <summary>
		/// 
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

		/// <summary>
		/// 
		/// </summary>
		public static void GetTrackInfo() {
		}

		/// <summary>
		/// 
		/// </summary>
		public static void GetSpotifyUri() {
		}

		/// <summary>
		/// 
		/// </summary>
		public static void FastForward() {
		}

		/// <summary>
		/// 
		/// </summary>
		public static void Rewind() {
		}

		#endregion
		#region Helper Functions/Properties

		/// <summary>
		/// 
		/// </summary>
		private static IntPtr getSpotifyHandle() {
			return FindWindow("SpotifyMainWindow", null);
		}

		#endregion
	}
}
