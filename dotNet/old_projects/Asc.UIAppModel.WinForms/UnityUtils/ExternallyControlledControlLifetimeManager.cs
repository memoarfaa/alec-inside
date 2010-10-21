using System;
using Microsoft.Practices.Unity;
using System.Windows.Forms;

namespace Asc.AppModel {
	public class ExternallyControlledControlLifetimeManager : ExternallyControlledLifetimeManager {
		public override object GetValue() {
			var value = base.GetValue();
			if ( value != null ) {
				var control = value as Control;
				if ( control != null && control.IsDisposed ) {
					return null;
				}
			}
			return value;
		}
	}
}
