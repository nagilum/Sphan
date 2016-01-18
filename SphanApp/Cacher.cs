using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphanApp {
	public class Cacher {
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
			return items[key];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public static T Get<T>(string key) where T : class {
			try {
				return (T) Get(key);
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
			if (items[key] != null)
				items[key] = data;
			else
				items.Add(
					key,
					data);
		}
	}
}