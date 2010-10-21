using System;
using System.Threading;
using Asc.AppModel;

namespace Asc.UIAppModel {
	internal class SynchronizationContextManager : ISynchronizationContextManager {

		private SynchronizationContext syncContext;

		public void SetContext( SynchronizationContext context ) {
			syncContext = context;
		}

		public void ExecuteAsync( IAction action, ActionExecutionContext actionContext ) {
			syncContext.Post( ExecuteAction,
				new ExecutionState {
					action = action,
					context = actionContext
				}
			);
		}

		public void Execute( IAction action, ActionExecutionContext actionContext ) {
			syncContext.Send( ExecuteAction,
				new ExecutionState {
					action = action,
					context = actionContext
				} 
			);
		}

		private static void ExecuteAction( object state ) {
			var executionState = (ExecutionState)state;			
			executionState.action.Execute( executionState.context );

		}

		private struct ExecutionState {
			public IAction action;
			public ActionExecutionContext context;
		}

	}
}
