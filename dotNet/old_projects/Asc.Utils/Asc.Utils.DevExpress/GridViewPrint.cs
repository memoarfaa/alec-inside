using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraPrinting.Localization;

namespace Asc.Utils.DevEx {
	public static class GridViewPrint {
		#region Print
		/// <summary>
		/// Отображает мастер печати данных
		/// </summary>
		public static void Print( this GridView view ) {
			SetPrintOptions( view );
			PreparePrint( view.GridControl, CreateHeaderFooter( string.Empty ) );
		}

		/// <summary>
		/// Отображает мастер печати данных
		/// </summary>
		/// <param name="view"></param>
		public static void PrintWithHeader( this GridView view, string headerText, bool autoWidth ) {
			SetPrintOptions( view );
			view.OptionsPrint.AutoWidth = autoWidth;
			PreparePrint( view.GridControl, CreateHeaderFooter( headerText ) );
		}

		private static void SetPrintOptions( GridView view ) {
			if ( view != null ) {
				if ( view.VisibleColumns.Count > 5 ) {
					view.OptionsPrint.AutoWidth = false;
				}
				else {
					view.OptionsPrint.AutoWidth = true;
				}
				view.OptionsPrint.PrintFooter = false;
			}
		}

		private static void PreparePrint( IPrintable printControl, PageHeaderFooter headerFooter ) {
			PrintingSystem printingSystem = new PrintingSystem();
			PrintableComponentLink printableCompLink = new PrintableComponentLink();
			printingSystem.Links.Add( printableCompLink );

			printableCompLink.Margins = new System.Drawing.Printing.Margins( 50, 50, 50, 50 );
			printableCompLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
			printableCompLink.VerticalContentSplitting = VerticalContentSplitting.Smart;

			printableCompLink.Component = printControl;
			printableCompLink.PageHeaderFooter = headerFooter;
			printableCompLink.CreateDocument();
			printableCompLink.ShowPreviewDialog();
		}

		private static PageHeaderFooter CreateHeaderFooter( string headerText ) {
			return new PageHeaderFooter(
				new PageHeaderArea( new string[] { headerText, "", "" },
					new Font( "Tahoma", 9, FontStyle.Regular ), BrickAlignment.Center ),
				new PageFooterArea( new string[] { "Дата печати:" + 
					PreviewLocalizer.Active.GetLocalizedString( PreviewStringId.PageInfo_PageDate ) + 
					PreviewLocalizer.Active.GetLocalizedString( PreviewStringId.PageInfo_PageTime ), 
					"", 
					PreviewLocalizer.Active.GetLocalizedString( PreviewStringId.PageInfo_PageNumberOfTotal ) },
				new Font( "Tahoma", 9, FontStyle.Regular ), BrickAlignment.Center ) );
		}


		#endregion


	}
}
