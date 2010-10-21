using System;

namespace Asc.AppModel {
	/// <summary>
	/// Представляет действие
	/// </summary>
	public interface IAction {
		/// <summary>
		/// Выполняет действие
		/// </summary>
		/// <param name="context">Контекст выполнения</param>
		void Execute( ActionExecutionContext context );
	}
}
