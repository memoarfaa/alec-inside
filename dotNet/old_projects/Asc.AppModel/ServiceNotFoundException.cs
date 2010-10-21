using System;

namespace Asc.AppModel {
	/// <summary>
	/// Исключение: не найдена необходимая служба
	/// </summary>
	public class ServiceNotFoundException : Exception {
		public ServiceNotFoundException() {
			
		}
		public ServiceNotFoundException( string serviceTypeName )
			: this( serviceTypeName, null ) {
			
		}
		public ServiceNotFoundException( string serviceTypeName, Exception innerException )
			: base( String.Format( "Не зарегистрирована служба {0}", serviceTypeName ), innerException ) {
			
		}
		protected ServiceNotFoundException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
			: base( info, context ) {
			
		}
	}
}
