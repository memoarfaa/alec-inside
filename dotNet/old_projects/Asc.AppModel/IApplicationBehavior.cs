using System;

namespace Asc.AppModel {
	/// <summary>
	/// Представляет расширение поведения приложения.
	/// </summary>
	public interface IApplicationBehavior {
		/// <summary>
		/// Вызывается при запуске среды
		/// </summary>
		void OnStart();

		/// <summary>
		/// Вызывается при остановке среды
		/// </summary>
		void OnStop();
	}
}
