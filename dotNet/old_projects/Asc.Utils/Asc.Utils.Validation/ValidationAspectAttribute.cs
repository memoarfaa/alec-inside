using System;
using System.Linq;
using PostSharp.Laos;
using System.Data.Objects.DataClasses;

namespace Asc.Utils.Validation {
	[Serializable]
	public class ValidationAspectAttribute : CompositionAspect {
		public override bool CompileTimeValidate( Type type ) {
			return !type.IsDefined( typeof( DontValidateAttribute ), false )
				&& ( type.IsSubclassOf( typeof( EntityObject ) ) ||
					type.GetInterfaces().Contains( typeof( IEntityWithKey ) )
				);

		}


		public override object CreateImplementationObject( InstanceBoundLaosEventArgs eventArgs ) {
			return new ValidatableImplementation( eventArgs.Instance );
		}

		/// <summary>
		/// Called at compile-time, gets the interface that should be publicly exposed.
		/// </summary>
		/// <param name="containerType">Type on which the interface will be implemented.</param>
		/// <returns></returns>
		public override Type GetPublicInterface( Type containerType ) {
			return typeof( IValidatable );
		}


		/// <summary>
		/// Gets weaving options.
		/// </summary>
		/// <returns>Weaving options specifying that the implementation accessor interface (<see cref="IComposed{T}"/>)
		/// should be exposed, and that the implementation of interfaces should be silently ignored if they are
		/// already implemented in the parent types.</returns>
		public override CompositionAspectOptions GetOptions() {
			return
				CompositionAspectOptions.GenerateImplementationAccessor |
				CompositionAspectOptions.IgnoreIfAlreadyImplemented;
		}


	}
}
