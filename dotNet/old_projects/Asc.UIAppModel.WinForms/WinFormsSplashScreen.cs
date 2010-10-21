using System;
using Asc.UIAppModel;
using System.Threading;
using System.Windows.Forms;

namespace Asc.UIAppModel.WinForms {
	public class WinFormsSplashScreen<T> : ISplashScreen where T : Form, new() {
		private static T instance;
		private static Thread splashThread;		

		public void Show() {
			if ( instance == null ) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				splashThread = new Thread( ShowSplash );
				splashThread.IsBackground = true;
				splashThread.SetApartmentState( ApartmentState.STA );
				splashThread.Start();
			}
		}

		public void Close() {
			if ( instance != null ) {				
				if ( !instance.InvokeRequired ) {
					if ( instance != null ) {
						instance.Close();
						instance.Dispose();
						instance = null;
						splashThread = null;
					}
				}
				else {				
					instance.Invoke( new Action( Close ) );
				}
			}

		}

		private static void ShowSplash() {
			if ( instance == null ) {
				instance = new T();
				instance.Load += OnInstanceLoad;
				//force handle creation 
				if ( instance.Handle == IntPtr.Zero ) {
					return;
				}
			}
			Application.Run( instance );			
		}

		private static void OnInstanceLoad( object sender, EventArgs e ) {
			var form = sender as Form;
			if ( form != null ) {
				form.Activate();
			}
		}
	}
}
