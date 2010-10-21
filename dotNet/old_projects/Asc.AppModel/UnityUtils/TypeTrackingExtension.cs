using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Asc.AppModel {

	public class TypeTrackingExtension : UnityContainerExtension {

		private readonly Dictionary<RuntimeTypeHandle, HashSet<string>> registeredTypes =
			new Dictionary<RuntimeTypeHandle, HashSet<string>>();

		protected override void Initialize() {
			Context.RegisteringInstance += RegisterInstance;
			Context.Registering += RegisterType;
		}

		public override void Remove() {
			Context.Registering -= RegisterType;
			Context.RegisteringInstance -= RegisterInstance;
		}

		public bool HasRegistration( RuntimeTypeHandle typeHandle, string name ) {			
			HashSet<string> names;
			if ( registeredTypes.TryGetValue( typeHandle, out names ) ) {
				return names.Contains( name ?? string.Empty );
			}
			return false;
		}

		private void RegisterInstance( object sender, RegisterInstanceEventArgs e ) {
			Register( e.RegisteredType.TypeHandle, e.Name );
		}

		private void RegisterType( object sender, RegisterEventArgs e ) {
			Register( e.TypeFrom.TypeHandle, e.Name );
		}

		private void Register( RuntimeTypeHandle typeHandle, string name ) {
			string regName = name ?? string.Empty;
			HashSet<string> names;
			if ( !registeredTypes.TryGetValue( typeHandle, out names ) ) {
				registeredTypes.Add( typeHandle,
					new HashSet<string>( new string[] { regName } ) );
			}
			else {
				names.Add( regName );
			}
		}

	}
}
