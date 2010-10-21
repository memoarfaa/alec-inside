using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asc.AppModel {
	/// <summary>
	/// Определяет действие-завершитель. Действие реализующее этот интерфейс исполняется
	/// даже если выполнение отменено
	/// </summary>
	public interface IFinallyAction : IAction {
	}
}
