using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asc.AppModel {
	public enum ExecutionState {
		Initialization,
		Execution,
		Cancellation,
		Faulting
	}
}
