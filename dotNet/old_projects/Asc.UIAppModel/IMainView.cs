using System;

namespace Asc.UIAppModel {
	public interface IMainView {
		event EventHandler Loaded;
		event EventHandler Closed;
		void Run();
		void AddChild( IStandaloneView view );
	}
}
