using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.XtraEditors;

namespace Asc.Utils.WinForms {
	/// <summary>
	/// Отлавливает необработанные исключения и передает их в Exception Handling Application Block
	/// </summary>
	public static class AppExceptionHandling {
		private static string exceptionPolicyName;
		/// <summary>
		/// Расставляет слушателей необработанных исключений.
		/// </summary>
		/// <param name="policyName">Имя политики в конфигурации Exception Handling</param>
		public static void SubscribeUnhandledExceptions( string policyName ) {
			exceptionPolicyName = policyName;
			Application.ThreadException += new ThreadExceptionEventHandler( AppUnhandledThreadException );

			// Set the unhandled exception mode to force all Windows Forms errors to go through
			// our handler.
			Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException );

			// Add the event handler for handling non-UI thread exceptions to the event. 
			AppDomain.CurrentDomain.UnhandledException +=
				new UnhandledExceptionEventHandler( AppUnhandledException );
		}

		private static void AppUnhandledException( object sender, UnhandledExceptionEventArgs ex ) {
			ExceptionPolicy.HandleException( (Exception)ex.ExceptionObject, exceptionPolicyName );
			XtraMessageBox.Show( "Во время выполнения программы произошла ошибка. \n" +
					"Информация об ошибке записана в журнал. Обратитесь к разработчикам.",
					"Ошибка приложения" );
		}		

		private static void AppUnhandledThreadException( object sender, ThreadExceptionEventArgs ex ) {
			ExceptionPolicy.HandleException( ex.Exception, exceptionPolicyName );
			XtraMessageBox.Show( "Во время выполнения программы произошла ошибка. \n" +
					"Информация об ошибке записана в журнал. Обратитесь к разработчикам.",
					"Ошибка приложения" );
		}
	}
}
