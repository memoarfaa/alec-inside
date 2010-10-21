using System;
using System.Collections.Generic;

namespace Asc.Utils.CollectionExtensions {
	public static class ICollectionExtensions {
		public static void AddIfNotNull<T>( this ICollection<T> list, T item ) {
			if ( item != null ) {
				list.Add( item );
			}
		}
	}
}
