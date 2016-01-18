using System.Collections.Generic;

namespace SphanApp {
	/// <summary>
	/// 
	/// </summary>
	public class Cacher {
		/// <summary>
		/// 
		/// </summary>
		private static readonly Dictionary<string, object> items = new Dictionary<string, object>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		public static void Clean(string key = null) {
			if (string.IsNullOrWhiteSpace(key))
				items.Clear();
			else
				items.Remove(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static object Get(string key) {
			return items.ContainsKey(key) ? items[key] : null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public static T Get<T>(string key) where T : class {
			if (!items.ContainsKey(key))
				return default(T);

			try {
				return (T) items[key];
			}
			catch {
				return default(T);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public static void Set(string key, object data) {
			if (items.ContainsKey(key))
				items[key] = data;
			else
				items.Add(
					key,
					data);
		}
	}
}