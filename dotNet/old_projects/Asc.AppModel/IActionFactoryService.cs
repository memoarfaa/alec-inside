using System;
using Asc.Messaging;

namespace Asc.AppModel {
	/// <summary>
	/// Представляет сервис создания действий
	/// </summary>
	public interface IActionFactoryService {
		/// <summary>
		/// Создает действие для указанного сообщения
		/// </summary>
		IAction Create( Message message );

		/// <summary>
		/// Приоритет фабрики
		/// </summary>
		Priority Priority {
			get;
		}		
	}
}
