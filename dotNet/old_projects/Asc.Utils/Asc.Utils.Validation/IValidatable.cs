using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Asc.Utils.Validation {
	public interface IValidatable : IDataErrorInfo {
		/// <summary>
		/// Определяет валидность объекта
		/// </summary>
		bool IsValid {
			get;
		}

		/// <summary>
		/// Осуществляет валидацию объекта. 		
		/// </summary>
		/// <remarks>Если объект в невалидном состоянии, то валидация будет выполнятся
		/// автоматически при изменении свойств до тех пор, пока объект не перейдет в валидное
		/// состояние.
		/// </remarks>
		bool Validate();

		/// <summary>
		/// Осуществляет непрерывную валидацию объекта.
		/// </summary>
		/// <remarks>Если объект в невалидном состоянии, то валидация будет выполнятся
		/// все время автоматически при изменении свойств.
		/// </remarks>
		bool ValidateContinuously();

		/// <summary>
		/// Сбрасывает результаты валидации и отключает автослежение за валидностью объекта.
		/// </summary>
		void ClearValidation();

		/// <summary>
		/// Возвращает результаты валидации.
		/// </summary>
		/// <remarks>Возвращает <c>null</c> если валидация не запускалась или сбрасывалась.
		/// </remarks>
		ValidationResults Results {
			get;
		}

	}
}
