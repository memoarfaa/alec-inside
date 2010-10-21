using System;
using System.Collections.Generic;

namespace Asc.AppModel {
	/// <summary>
	/// Определяет набор допустимых приоритетов фабрики действий
	/// </summary>
	public enum Priority {
		Normal = 0,
		Low = -1,
		High = 1,
		Filter = 100
	}	
}
