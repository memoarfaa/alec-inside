using System;

namespace Asc.Utils.Validation {
	/// <summary>
	/// Запрещает автоматическую реализацию интерфейса <see cref="IValidatable"/>
	/// </summary>
	[AttributeUsage( AttributeTargets.Class)]
	public class DontValidateAttribute : Attribute  {
		
	}
}
