using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asc.Utils.Controls {
	public partial class LineControl : Control {
		public LineControl() {
			InitializeComponent();
		}

		protected override void OnPaint( PaintEventArgs pe ) {
			// TODO: Add custom paint code here

			// Calling the base class OnPaint
			base.OnPaint( pe );
		}
	}
}
