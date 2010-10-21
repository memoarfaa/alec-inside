using System;
using System.Runtime.Serialization;

namespace Asc.Messaging {
	/// <summary>
	/// Представляет сообщение
	/// </summary>
	[DataContract]
	[Serializable]
	[KnownType( typeof( IdentifiedMessage ) )]
	public abstract class Message {
	}
}
