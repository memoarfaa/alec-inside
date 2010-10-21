using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.XtraGrid;

namespace Asc.Utils.DevEx {
	/// <summary>
	/// Управляет сохранением состояния контрола
	/// </summary>
	public class GridViewLayoutController {

		private GridView view;
		private string id;

		private static string companyName = "Asc";
		public static string CompanyName {
			get {
				return companyName;
			}
			set {
				companyName = value;
			}
		}

		/// <summary>
		/// Сохраняет настройки по-умолчанию и загружает сохраненные ранее
		/// </summary>
		/// <param name="view">Контрол</param>
		/// <param name="id">Идентификатор экземпляра контрола в программе</param>
		public GridViewLayoutController( GridView view, string id ) {
			this.view = view;
			this.id = id;
			//сохраним настройки по умолчанию
			StoreDefaultLayout();
			//загрузим сохраненные
			RestoreLayout();
		}

		/// <summary>
		/// Возвращает путь для сохранения
		/// </summary>
		/// <returns></returns>
		protected virtual string GetAppDataPath() {
			return String.Format( "{0}\\{1}\\{2}",
				Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ),
				companyName,
				Application.ProductName );
		}

		#region GridView Options 
		/// <summary>
		/// Отображает окно настроек
		/// </summary>
		public void ShowOptionsDialog() {
			ShowOptionsDialogCore();
		}

		protected virtual void ShowOptionsDialogCore() {
			using ( GridViewOptions dlg = new GridViewOptions( view, RestoreDeafultLayout ) ) {
				dlg.ShowDialog();
			}
		}

		#endregion 

		#region User Options

		/// <summary>
		/// Сохраняет настройки
		/// </summary>
		public void StoreLayout() {
			DirectoryInfo dirInfo = new DirectoryInfo( GetAppDataPath() );
			if ( !dirInfo.Exists ) {
				dirInfo.Create();
			}
			StoreLayoutCore( dirInfo.FullName );
		}

		/// <summary>
		/// Реализует сохранение настроек 
		/// </summary>
		/// <param name="path"></param>
		protected virtual void StoreLayoutCore( string path ) {
			if ( view != null ) {
				view.GridControl.ForceInitialize();
				try {
					view.SaveLayoutToXml( path + @"\" +
						GetOptionsFileName( ) );
				}
				catch {
					if ( Debugger.IsAttached ) {
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Возвращает имя файла для хранения настроек
		/// </summary>
		/// <returns></returns>
		protected virtual string GetOptionsFileName() {
			return view.GridControl.Name + "." + view.Name + "." + id + ".xml";
		}

		/// <summary>
		/// Восстанавливает ранее сохраненные настройки 
		/// </summary>
		public void RestoreLayout() {
			DirectoryInfo dirInfo = new DirectoryInfo( GetAppDataPath() );
			if ( dirInfo.Exists ) {
				RestoreLayoutCore( dirInfo.FullName );
			}
		}

		/// <summary>
		/// Реализует восстановление настроек
		/// </summary>
		/// <param name="path"></param>
		protected virtual void RestoreLayoutCore( string path ) {
			if ( view != null ) {
				FileInfo file = new FileInfo( path + @"\" + GetOptionsFileName() );
				if ( file.Exists ) {
					view.GridControl.ForceInitialize();
					try {
						view.RestoreLayoutFromXml( file.FullName );
						view.ClearColumnsFilter();
					}
					catch {
						if ( Debugger.IsAttached ) {
							throw;
						}
					}
				}
			}
		}

		#endregion

		#region Default Options

		protected Stream defaultLayout;

		/// <summary>
		/// Запоминает настройки по умолчанию 
		/// </summary>
		protected virtual void StoreDefaultLayout() {
			if ( defaultLayout == null ) {
				defaultLayout = new MemoryStream();

				if ( view != null ) {
					view.GridControl.ForceInitialize();
					view.SaveLayoutToStream( defaultLayout );
					defaultLayout.Seek( 0, System.IO.SeekOrigin.Begin );
					return;
				}
			}
		}

		/// <summary>
		/// Восстанавливает настройки по умолчанию
		/// </summary>
		public virtual void RestoreDeafultLayout() {
			if ( defaultLayout != null ) {
				if ( view != null ) {
					view.GridControl.ForceInitialize();
					view.RestoreLayoutFromStream( defaultLayout );
					defaultLayout.Seek( 0, System.IO.SeekOrigin.Begin );
					return;
				}
			}
		}
		#endregion
	}
}
