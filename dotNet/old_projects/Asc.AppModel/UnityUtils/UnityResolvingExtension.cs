using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;

namespace Asc.AppModel {
	public static class UnityResolvingExtension {
		
		/// <summary>
		/// Determines whether this type can be resolved 
		/// </summary>
		/// <typeparam name="T">The type to test for resolution</typeparam>
		/// <param name="container"></param>
		/// <returns><c>true</c> if type can be resolved; otherwise, <c>false</c></returns>
		public static bool CanResolve<T>( this IUnityContainer container ) {
			return container.CanResolve<T>( null );
		}

		/// <summary>
		/// Determines whether this type can be resolved
		/// </summary>
		/// <typeparam name="T">The type to test for resolution</typeparam>
		/// <param name="container"></param>
		/// <param name="name">Registration name</param>
		/// <returns><c>true</c> if type can be resolved; otherwise, <c>false</c></returns>
		public static bool CanResolve<T>( this IUnityContainer container, string name ) {			
			bool canResolve = container.Configure<TypeTrackingExtension>()
				.HasRegistration( typeof(T).TypeHandle, name);
			
			if ( !canResolve && container.Parent != null ) {
				canResolve = container.Parent.CanResolve<T>( name );
			}
			return canResolve;
		}

		/// <summary>
		/// Возвращяет все экземляры для указанного типа и именованные и неименованные
		/// </summary>
		public static IEnumerable<T> ResolveAbsolutelyAll<T>( this IUnityContainer container ) {
			var namedInstances = container.ResolveAll<T>();
			var resultList = new List<T>();
			if ( namedInstances != null ) {
				resultList.AddRange( namedInstances );
			}
			if ( container.CanResolve<T>() ) {
				resultList.Add( container.Resolve<T>() );
			}

			if ( resultList.Count == 0 ) {
				return null;
			}

			return new ReadOnlyCollection<T>( resultList );
		}
	}
}
