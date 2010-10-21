using System;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Windows.Forms;

namespace Asc.Utils.DevEx {
	/// <summary>
	/// Утилиты для работы с GridView.
	/// </summary>
	public static class GridViewUtils {

		#region Incremetal search
		public static void IncrementalSearch( GridColumn column, string text, bool down ) {
			GridView view = column.View as GridView;
			if ( view == null ) {
				return;
			}
			if ( String.IsNullOrEmpty( text ) ) {
				view.StopIncrementalSearch();
			}
			else if ( view.State == GridState.IncrementalSearch &&
				String.Compare( view.GetIncrementalText(), text, StringComparison.CurrentCultureIgnoreCase ) == 0 ) {
				IncrementalSearchMove( view, down );
			}
			else {
				view.FocusedColumn = column;
				view.StartIncrementalSearch( text );
			}

		}

		private static void IncrementalSearchMove( GridView view, bool down ) {
			if ( view.State == GridState.IncrementalSearch ) {
				int newRow = InvokeViewFindRow( view,
					new FindRowArgs( view.FocusedRowHandle, view.FocusedColumn,
						view.GetIncrementalText(), true, true, down ) );
				if ( newRow != GridControl.InvalidRowHandle ) {
					view.FocusedRowHandle = newRow;
				}
			}
		}
		private static RuntimeMethodHandle? gridViewFindRowHandle = null;

		private static int InvokeViewFindRow( GridView view, FindRowArgs args ) {
			if ( gridViewFindRowHandle == null ) {
				MethodInfo frmi = typeof( GridView ).GetMethod( "FindRow",
					BindingFlags.NonPublic | BindingFlags.Instance );
				gridViewFindRowHandle = frmi.MethodHandle;
			}
			MethodBase mi = MethodBase.GetMethodFromHandle( gridViewFindRowHandle.Value );
			if ( mi != null && view != null ) {
				return (int)mi.Invoke( view, new object[] { args } );
			}
			return GridControl.InvalidRowHandle;
		}
		#endregion

		public static bool IsDataRow( this GridView view, MouseEventArgs gridConrolMouseEventsArg ) {
					
			GridHitInfo hitInfo = view.CalcHitInfo( gridConrolMouseEventsArg.X - view.ViewRect.X,
				gridConrolMouseEventsArg.Y - view.ViewRect.Y );

			return ( hitInfo != null &&
				hitInfo.InRow &&
				hitInfo.HitTest != GridHitTest.CellButton &&
				hitInfo.HitTest != GridHitTest.RowDetail &&
				hitInfo.RowHandle != GridControl.AutoFilterRowHandle );
		}

	}
}
