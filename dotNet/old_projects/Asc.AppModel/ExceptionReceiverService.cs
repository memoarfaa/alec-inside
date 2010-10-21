using System;
using Asc.Messaging;

namespace Asc.AppModel {
	internal class ExceptionReceiverService : IExceptionHandlerService, IAsyncMessageReceiverService {
		private bool opened;
		#region IExceptionHandlerService Members

		public void Handle( ExceptionMessage message ) {
			if ( opened && MessageReceived != null && message != null ) {
				try {
					MessageReceived( this, new MessageEventArgs( message ) );
				}
				catch ( Exception ex ) {
					if ( ErrorOccured != null ) {
						ErrorOccured( this, new ErrorEventArgs( ex ) );
					}
					else {
						throw;
					}
				}
			}
		}

		#endregion

		#region IAsyncMessageReceiverService Members

		public event EventHandler<MessageEventArgs> MessageReceived;

		public event EventHandler<ErrorEventArgs> ErrorOccured;

		public void Open() {
			opened = true;
		}

		public void Close() {
			opened = false;
		}

		public Priority Priority {
			get {
				return Priority.High;
			}
		}
		public bool IsOpened {
			get {
				return opened;
			}
		}

		#endregion
	}
}
