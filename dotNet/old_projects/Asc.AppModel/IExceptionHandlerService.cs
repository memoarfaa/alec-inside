using System;
using Asc.Messaging;

namespace Asc.AppModel {
	public interface IExceptionHandlerService {
		void Handle( ExceptionMessage message );
	}
}
