using System;
using System.Collections.Generic;

namespace Asc.Utils.CollectionExtensions {
	public static class DictionaryExtensions {
		public static Dictionary<TKey, TValue> Append<TKey, TValue>(
			this Dictionary<TKey, TValue> dict,
			TKey key,
			TValue value ) {

			dict.Add( key, value );
			return dict;
		}
		
	}
}
