using System;
using System.Threading;
using Asc.AppModel;

namespace Asc.UIAppModel {
	public interface ISynchronizationContextManager {
		void SetContext( SynchronizationContext context );
		void ExecuteAsync( IAction action, ActionExecutionContext actionContext);
		void Execute( IAction action, ActionExecutionContext actionContext );
	}
}
