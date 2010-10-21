using System;

namespace Asc.Messaging {
	/// <summary>
	/// Аргумент события связанного с сообщениями
	/// </summary>
	public sealed class MessageEventArgs : EventArgs {
		public MessageEventArgs( Message message ) {
			Message = message;
		}

		/// <summary>
		/// Сообщение
		/// </summary>
		public Message Message {
			get;
			private set;
		}
	}
}
