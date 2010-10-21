using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Asc.Utils.DevEx {
	/// <summary>
	/// Представляет форму для редактирования настроек GridView 
	/// </summary>
	public partial class GridViewOptions : DevExpress.XtraEditors.XtraForm {
		private DataColumn[] columns;
		private GridView gridView;
		private RestoreDefaultLayout layoutRestorer;

		/// <summary>
		/// Ссылка на метод восстанавливающий настройки по умолчанию
		/// </summary>
		public delegate void RestoreDefaultLayout();


		private GridViewOptions() {
			InitializeComponent();
		}

		public GridViewOptions( GridView view, RestoreDefaultLayout restorer )
			: this() {
			gridView = view;
			layoutRestorer = restorer;
			LoadItems( view );
		}

		private void LoadItems( GridView view ) {
			dataColumnBindingSource.DataSource = null;
			columns = new DataColumn[ view.Columns.Count ];
			for ( int colIndex = 0; colIndex < view.Columns.Count; ++colIndex ) {
				columns[ colIndex ] = new DataColumn( view.Columns[ colIndex ], view.Columns[ colIndex ].Caption );
				columns[ colIndex ].Visible = view.Columns[ colIndex ].Visible;
			}
			dataColumnBindingSource.DataSource = columns;
		}

		private void repositoryItemCheckEdit1_EditValueChanged( object sender, EventArgs e ) {
			gridView1.CloseEditor();
			gridView1.UpdateCurrentRow();
		}

		private void btCancel_Click( object sender, EventArgs e ) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void btOk_Click( object sender, EventArgs e ) {
			if ( columns.Length > 0 ) {
				foreach ( DataColumn item in columns ) {					
					if ( item.Visible ) {
						item.Column.VisibleIndex = gridView.Columns.IndexOf( item.Column );
					}
					else {
						item.Column.Visible = false;
					}
				}
			}
			this.DialogResult = DialogResult.OK;
		}

		private void simpleButton1_Click( object sender, EventArgs e ) {
			if ( columns.Length > 0 ) {
				foreach ( DataColumn item in columns ) {
					item.Visible = true;
				}
				dataColumnBindingSource.ResetBindings( false );
			}
		}

		private void simpleButton2_Click( object sender, EventArgs e ) {
			if ( layoutRestorer != null ) {
				layoutRestorer();
				if ( gridView != null ) {
					LoadItems( gridView );
				}
			}
		}

		/// <summary>
		/// Представляет колонку GridView или TreeList
		/// </summary>
		public class DataColumn {
			private bool _visible;
			private string _name;
			private GridColumn _column;
			public DataColumn( GridColumn column, string name ) {
				_column = column;
				_name = name;
			}

			/// <summary>
			/// Определяет будет ли колонка видна
			/// </summary>
			public bool Visible {
				get {
					return _visible;
				}
				set {
					_visible = value;
				}
			}

			/// <summary>
			/// Возвращает имя колонки
			/// </summary>
			public string Name {
				get {
					return _name;
				}
			}

			/// <summary>
			/// Возвращает реальную колонку
			/// </summary>
			public GridColumn Column {
				get {
					return _column;
				}
			}
		}


	}
}