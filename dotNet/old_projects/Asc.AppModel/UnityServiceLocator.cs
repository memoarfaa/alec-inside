using System;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace Asc.AppModel {
	public class UnityServiceLocator : IServiceLocator, IParentContainer {
		private IUnityContainer container;

		public UnityServiceLocator( IUnityContainer container ) {
			this.container = container;
		}

		public T GetService<T>() {
			return container.Resolve<T>();
		}

		public T GetService<T>( string name ) {
			return container.Resolve<T>( name );
		}

		public IUnityContainer CreateChildContainer() {
			var child = container.CreateChildContainer();
			child.AddNewExtension<TypeTrackingExtension>();
			return child;
		}

		public IEnumerable<T> GetAllServices<T>() {
			return container.ResolveAbsolutelyAll<T>();
		}

		public T BuildUp<T>( T existing ) {
			return container.BuildUp( existing );
		}

		public T BuildUp<T>( T existing, string name ) {
			return container.BuildUp( existing, name );
		}
	}
}
