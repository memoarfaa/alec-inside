using System;

namespace Asc.UIAppModel {
	public interface IApplicationResource {		
		bool CheckAvailability();		
		void MakeAvailable();
		bool HasUI {
			get;
		}
	}
}
