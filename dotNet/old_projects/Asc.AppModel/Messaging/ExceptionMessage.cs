using System;
using System.Runtime.Serialization;

namespace Asc.Messaging {
	[DataContract]
	public class ExceptionMessage : Message {
		public ExceptionMessage( Exception ex ) {
			Exception = ex;
		}
		[DataMember]
		public Exception Exception {
			get;
			private set;
		}
		[DataMember]
		public bool Handled {
			get;
			set;
		}
	}
}
