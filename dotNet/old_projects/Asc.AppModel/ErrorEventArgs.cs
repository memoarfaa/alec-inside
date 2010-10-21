using System;

namespace Asc.AppModel {
	public sealed class ErrorEventArgs : EventArgs {
		public ErrorEventArgs( Exception exception ) {
			Exception = exception;
		}

		/// <summary>
		/// Эксепшин
		/// </summary>
		public Exception Exception {
			get;
			private set;
		}
	}
}
