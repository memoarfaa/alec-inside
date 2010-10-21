using System;
using System.Collections.Generic;

namespace Asc.Utils.CollectionExtensions {
	public static class ForEachExtension {
		public static void ForEach<T>( this IEnumerable<T> enumeration, Action<T> action ) {
			foreach ( T item in enumeration ) {
				action( item );
			}
		}
		public static void ForEachIf<T>( this IEnumerable<T> enumeration, Predicate<T> match, Action<T> action ) {
			foreach ( T item in enumeration ) {
				if ( match( item ) ) {
					action( item );
				}
			}
		}
	}
}
