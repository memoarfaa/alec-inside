using System;
using System.Runtime.Serialization;

namespace Asc.Messaging {
	/// <summary>
	/// Представляет идентифицируемое сообщение
	/// </summary>
	[DataContract]
	[Serializable]
	public abstract class IdentifiedMessage : Message {		
		public abstract object Id {
			get;
		}
	}
}
