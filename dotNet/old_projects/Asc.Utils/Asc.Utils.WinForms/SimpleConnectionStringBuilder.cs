using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Asc.Utils.WinForms {

	/// <summary>
	/// Класс аггрегирует SqlConnectionStringBuilder для того, чтобы предоставить только частоиспользуемые поля,
	/// а также реализует INotifyPropertyChanged для возможности биндить.
	/// </summary>
	public class SimpleConnectionStringBuilder : INotifyPropertyChanged
	{
		private SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

		public SimpleConnectionStringBuilder() {}

		/// <summary>
		/// Конструктор с заданной строкой подключения
		/// </summary>
		/// <param name="ConnectionString">Строка подключения</param>
		public SimpleConnectionStringBuilder(string ConnectionString) {
			stringBuilder.ConnectionString = ConnectionString;
		}

		/// <summary>
		/// Строка подключения
		/// </summary>
		public string ConnectionString {
			get { return stringBuilder.ConnectionString; }
			set { stringBuilder.ConnectionString = value; }
		}


		/// <summary>
		/// Имя или IP сервера баз данных
		/// </summary>
		public string ServerName {
			get { return stringBuilder.DataSource; }
			set {
				stringBuilder.DataSource = value;
				PropertyChanged(this, new PropertyChangedEventArgs("ServerName"));
			}
		}

		/// <summary>
		/// Имя базы данных
		/// </summary>
		public string Database {
			get { return stringBuilder.InitialCatalog; }
			set {
				stringBuilder.InitialCatalog = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Database"));
			}
		}

		/// <summary>
		/// Пользоватедль
		/// </summary>
		public string User {
			get { return stringBuilder.UserID; }
			set {
				stringBuilder.UserID = value;
				PropertyChanged(this, new PropertyChangedEventArgs("User"));
			}
		}

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password {
			get { return stringBuilder.Password; }
			set {
				stringBuilder.Password = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Password"));
			}
		}

		/// <summary>
		/// Определяет - использовать Windows или SQL Server аутентификацию.
		/// </summary>
		public bool IntegratedSecurity {
			get { return stringBuilder.IntegratedSecurity; }
			set {
				stringBuilder.IntegratedSecurity = value;
				PropertyChanged(this, new PropertyChangedEventArgs("IntegratedSecurity"));
			}
		}

		#region INotifyPropertyChanged Members

		/// <summary>
		/// Событие срабатывает на все публичные свойства, кроме ConnectionString
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}
