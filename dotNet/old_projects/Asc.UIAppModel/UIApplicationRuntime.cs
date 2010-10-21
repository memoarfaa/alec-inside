using System;
using Asc.AppModel;
using System.Threading;
using Microsoft.Practices.Unity;

namespace Asc.UIAppModel {
	public class UiApplicationRuntime : ApplicationRuntime {

		public event EventHandler UIClosed;
		private Thread uiThread;
		private ManualResetEvent uiWaitHandle;

		public UiApplicationRuntime() {
			RegisterService<ISynchronizationContextManager, SynchronizationContextManager>(
					new ContainerControlledLifetimeManager() );
		}

		protected override void StartRuntimeCore() {
			//UI Thread First!
			uiWaitHandle = new ManualResetEvent( false );
			RunUiThread();
			uiWaitHandle.WaitOne( 30000 );

			base.StartRuntimeCore();			
		}

		private void RunUiThread() {
			uiThread = new Thread( StartUI );
			uiThread.IsBackground = false;
			uiThread.SetApartmentState( ApartmentState.STA );
			uiThread.Start();
		}

		protected override void CheckMainServicesExists() {
			base.CheckMainServicesExists();
			if ( !ServiceLocationContainer.CanResolve<IMainView>() ) {
				throw new ServiceNotFoundException( typeof( IMainView ).Name );
			}
		}

		protected override void ExecuteAction( IAction action, ActionExecutionContext context ) {
			if ( action is IUiAction ) {
				var syncContext = ServiceLocationContainer.Resolve<ISynchronizationContextManager>();
				syncContext.Execute( action, context );
			}
			else {
				action.Execute( context );
			}
		}

		protected virtual void CheckApplicationResources() {
			var resourceCheckers = ServiceLocationContainer.ResolveAbsolutelyAll<IApplicationResource>();

			foreach ( var resource in resourceCheckers ) {
				if ( !resource.CheckAvailability() ) {
					if ( resource.HasUI && ServiceLocationContainer.CanResolve<ISplashScreen>() ) {
						ServiceLocationContainer.Resolve<ISplashScreen>().Close();
					}
					resource.MakeAvailable();
				}
			}
		}

		private void StartUI() {
			if ( ServiceLocationContainer.CanResolve<ISplashScreen>() ) {
				ServiceLocationContainer.Resolve<ISplashScreen>().Show();
			}  

			if ( ServiceLocationContainer.CanResolve<IUiApplicationBehavior>() ) {
				ServiceLocationContainer.Resolve<IUiApplicationBehavior>()
					.Initialize();
			}

			CheckApplicationResources();
			RunMainView();
		}

		private void RunMainView() {
			var mainView = ServiceLocationContainer.Resolve<IMainView>();
			mainView.Loaded += mainViewLoaded;
			mainView.Closed += mainViewClosed;
			mainView.Run();
		}

		private void mainViewClosed( object sender, EventArgs e ) {
			StopRuntime();
			if ( UIClosed != null ) {
				UIClosed( sender, e );
			}
			uiWaitHandle.Set();
		}

		private void mainViewLoaded( object sender, EventArgs e ) {
			if ( ServiceLocationContainer.CanResolve<ISplashScreen>() ) {
				ServiceLocationContainer.Resolve<ISplashScreen>().Close();
			}  
			uiWaitHandle.Set();
		}


	}
}
