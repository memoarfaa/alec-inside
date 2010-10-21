using System;
using Asc.Utils.WinForms;
using System.Windows.Forms;
using Asc.UIAppModel;

namespace Asc.UIAppModel.WinForms {
	public class EFConnectionChecker : IApplicationResource {
		private string modelName;

		public EFConnectionChecker( string modelName ) {
			this.modelName = modelName;
		}

		public bool HasUI {
			get {
				return true;
			}
		}

		public bool CheckAvailability() {
			return EFDatabaseConnect.TryConnect( modelName );
		}

		public void MakeAvailable() {
			using ( var connectForm = new EFDatabaseConnect( modelName, false ) ) {
				if ( connectForm.ShowDialog() == DialogResult.Cancel ) {
					Environment.Exit( -1 );
				}				
			}
		}




	}
}
