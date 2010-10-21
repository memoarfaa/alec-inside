using System;
using Asc.AppModel;

namespace Asc.Messaging {
	/// <summary>
	/// Представляет службу асинхронного получения сообщений
	/// </summary>
	/// <remarks>
	/// Асинхронно отслеживает поступление сообщений и гененрирует событие MessageReceived для каждого из них.
	/// Зарегистрированные в MessageReceived обработчики выполняются не в потоке среды исполнения, а в потоке службы-получателя.
	/// Если в среде зарегистрировано несколько служб IAsyncMessageReceiverService, 
	/// то все сервисы регистриуемые в среде должны быть реализованы с учетом многопоточности (параллельного выполнения).
	/// </remarks>
	public interface IAsyncMessageReceiverService {
		/// <summary>
		/// Возникает при получении нового сообщения
		/// </summary>
		event EventHandler<MessageEventArgs> MessageReceived;

		/// <summary>
		/// Возникает при возбуждении исключения
		/// </summary>
        event EventHandler<ErrorEventArgs> ErrorOccured;

		/// <summary>
		/// Открывает канал получения сообщений
		/// </summary>
		void Open();

		/// <summary>
		/// Закрывает канал получения сообщений
		/// </summary>
		void Close();

		/// <summary>
		/// Приоритет открытия канала
		/// </summary>
		Priority Priority {
			get;
		}

		/// <summary>
		/// Открыт ли канал
		/// </summary>
		bool IsOpened {
			get;
		}
	}
}
