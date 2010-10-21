using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Asc.UIAppModel.WinForms {
	public class WinFormsMainView<T> : IMainView where T : Form {
		private readonly T instance;		

		public event EventHandler Loaded;
		public event EventHandler Closed;

		public WinFormsMainView( ISynchronizationContextManager syncContextManager, T mainForm ) {
			instance = mainForm;
			instance.Load += OnLoaded;
			instance.FormClosed += OnClosed;
			syncContextManager.SetContext( SynchronizationContext.Current );
		}


		public void Run() {
			Application.Run( instance );
		}

		

		private void OnLoaded( object sender, EventArgs e ) {
			if ( Loaded != null ) {
				WindowHelper.SetForeground( instance );
				instance.Activate();
				Loaded( sender, e );				
			}			
		}

		private void OnClosed( object sender, FormClosedEventArgs e ) {
			if ( Closed != null ) {
				Closed( sender, e );
			}
		}

		public void AddChild( IStandaloneView view ) {
			Debug.Assert( view is Form, "Ожидался параметр типа Form" );
			var childForm = (Form)view;
			childForm.FormClosed += ChildFormClosed;
			if ( !instance.OwnedForms.Contains( childForm ) ) {
				instance.AddOwnedForm( childForm );
			}
		}

		private void ChildFormClosed( object sender, FormClosedEventArgs e ) {
			if ( e.CloseReason == CloseReason.UserClosing
				|| e.CloseReason == CloseReason.None ) {

				instance.RemoveOwnedForm( (Form)sender );
			}
		}
	}

	internal static class WindowHelper {
		[DllImport( "user32.dll" )]
		private static extern bool SetForegroundWindow( IntPtr hWnd );

		public static void SetForeground( Form form ) {
			SetForegroundWindow( form.Handle );
		}
	}
}
