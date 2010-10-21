using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asc.Utils.Validation {
	public static class ValidationHelper {
		public static bool Validate<T>( IEnumerable<T> collection ) 
			where T : IValidatable {

			return collection.Count( item => !item.Validate() ) == 0;

		}
	}
}
