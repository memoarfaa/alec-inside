using System;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Asc.Utils.DevEx {
	/// <summary>
	/// Утилиты для работы с PictureEdit
	/// </summary>
	public static class PictureEditUtils {
		private static PictureMenu GetMenu( PictureEdit edit ) {
			PropertyInfo pi = typeof( PictureEdit ).GetProperty( "Menu", 
				BindingFlags.NonPublic | BindingFlags.Instance );
			if ( pi != null ) {
				return pi.GetValue( edit, null ) as PictureMenu;
			}
			return null;
		}

		private static void InvokeMenuMethod( PictureMenu menu, String name ) {
			MethodInfo mi = typeof( PictureMenu ).GetMethod( name, 
				BindingFlags.NonPublic | BindingFlags.Instance );
			if ( mi != null && menu != null ) {
				mi.Invoke( menu, new object[] { menu, new EventArgs() } );
			}
		}
		/// <summary>
		/// Отображает диалог загрузки изображения из файла.
		/// </summary>
		/// <param name="editor"></param>
		public static void ShowLoadDialog( this PictureEdit editor ) {
			//the name can be on of the following values: OnClickedLoad;OnClickedSave;OnClickedCut;OnClickedCopy;OnClickedPaste;OnClickedDelete
			InvokeMenuMethod( GetMenu( editor ), "OnClickedLoad" );
		}
	}
}
