using System;

namespace Asc.Messaging {
	/// <summary>
	/// Представляет сервис отправки сообщений
	/// </summary>
	public interface IMessageSenderService {
		/// <summary>
		/// Отправляет сообщение
		/// </summary>
		/// <param name="message">сообщение</param>
		void Send( Message message );
	}
}
