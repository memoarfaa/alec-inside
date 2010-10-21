using System;
using Asc.AppModel;

namespace Asc.Messaging {
	public class ManualMessageGenerator : IAsyncMessageReceiverService, IMessageSenderService {

		#region IAsyncMessageReceiverService Members

		public event EventHandler<MessageEventArgs> MessageReceived;

		public event EventHandler<Asc.AppModel.ErrorEventArgs> ErrorOccured;

		public void Open() {
			IsOpened = true;
		}

		public void Close() {
			IsOpened = false;
		}

		public Priority Priority {
			get {
				return Priority.High;
			}
		}

		public bool IsOpened {
			get;
			private set;
		}

		#endregion

		#region IMessageSenderService Members

		public void Send( Message message ) {
			if ( message == null ) {
				throw new ArgumentNullException( "message" );
			}
			if ( MessageReceived != null ) {
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
	}
}
