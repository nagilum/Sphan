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

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		internal const uint WM_APPCOMMAND = 0x0319;

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
		public static void Mute() {
			SendMessage(
				getSpotifyHandle(),
				WM_APPCOMMAND,
				IntPtr.Zero,
				new IntPtr(524288));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void ToggleWindowState() {
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
