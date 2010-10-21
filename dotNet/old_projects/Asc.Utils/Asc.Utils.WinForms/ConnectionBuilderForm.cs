using System;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Asc.Utils.WinForms {
	/// <summary>
	/// Форма предоставляет интерфейс, для удобного построения строки подключения к SQL серверу
	/// </summary>
	public partial class ConnectionBuilderForm : DevExpress.XtraEditors.XtraForm {

		/// <summary>
		/// Метод, который должен быть вызван для получения строки подключения от пользователя.
		/// </summary>
		/// <returns>Строка подключения</returns>
		public static string GetConnectionString() {
			ConnectionBuilderForm form = new ConnectionBuilderForm();
			return readstring(false, ref form);
		}

		public static string GetConnectionString(bool ShowTopMost) {
			ConnectionBuilderForm form = new ConnectionBuilderForm();
			return readstring(ShowTopMost, ref form);
		}

		/// <summary>
		///Метод, который должен быть вызван для получения строки подключения от пользователя.
		///Предварительно поля бутут забиндены заданной ConnectionString.
		/// </summary>
		/// <returns>Строка подключения</returns>
		public static string ModifyConnectionString(string ConnectionString) {
			return ReadString(ConnectionString, false);
		}

		/// <summary>
		///Метод, который должен быть вызван для получения строки подключения от пользователя.
		///Предварительно поля бутут забиндены заданной ConnectionString.
		/// </summary>
		/// <param name="ConnectionString"></param>
		/// <param name="ShowTopMost">Показывать поверх других окон</param>
		/// <returns>Строка подключения</returns>
		public static string ModifyConnectionString(string ConnectionString, bool ShowTopMost ) {
			return ReadString(ConnectionString, ShowTopMost);
		}

		private static string ReadString(string ConnectionString, bool ShowTopMost) {
			ConnectionBuilderForm form = new ConnectionBuilderForm(ConnectionString);
			return readstring(ShowTopMost, ref form);
		}

		private static string readstring(bool ShowTopMost, ref ConnectionBuilderForm form) {
			form.TopMost = ShowTopMost;
			form.ShowDialog();
			string connectionString = form.ConnectionString;
			form.Dispose();
			form = null;
			return connectionString;
		}	

		/// <summary>
		/// Конструктор
		/// </summary>
		public ConnectionBuilderForm() {
			InitializeComponent();
			simpleConnectionStringBuilderBindingSource.DataSource = ConnectionBuilder;
			ConnectionBuilder.PropertyChanged += new PropertyChangedEventHandler(ConnectionBuilder_PropertyChanged);
		}		

		/// <summary>
		/// Конструктор с заданной строкой подключения
		/// </summary>
		/// <param name="ConnectionString">Строка подключения</param>
		public ConnectionBuilderForm(string ConnectionString)
			: this() {
			ConnectionBuilder.ConnectionString = ConnectionString;
		}

		/// <summary>
		/// Строка подключения
		/// </summary>
		public string ConnectionString {
			get { return ConnectionBuilder.ConnectionString; }
			set { ConnectionBuilder.ConnectionString = value; }
		}

		private SimpleConnectionStringBuilder ConnectionBuilder = new SimpleConnectionStringBuilder();

		private bool needToReloadDataBases = true;

		private void ConnectionBuilder_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			cmbBd.Properties.Items.Clear();
			needToReloadDataBases = true;			
		}

		private void ReloadDatabases() {
			SqlConnection sqlConx = new SqlConnection(ConnectionBuilder.ConnectionString);
			
			try {
				sqlConx.Open();
				DataTable tblDatabases = tblDatabases = sqlConx.GetSchema("Databases");
				foreach (DataRow row in tblDatabases.Rows) {
					cmbBd.Properties.Items.Add(row["database_name"]);
				}
				cmbBd.ShowPopup();

			}
			finally {
				sqlConx.Close();
			}
		}		

		private void radioItegratedSequrity_SelectedIndexChanged(object sender, EventArgs e) {
			txtPassword.Enabled = !(bool)radioItegratedSequrity.EditValue;
			txtUser.Enabled = !(bool)radioItegratedSequrity.EditValue;
		}

		private void btnTest_Click(object sender, EventArgs e) {
			SqlConnection sqlConx = new SqlConnection(ConnectionBuilder.ConnectionString);
			bool success = true;
			Exception exception = null;
			try {
				sqlConx.Open();
			}
			catch (Exception exc) {
				success = false;
				exception = exc;
			}
			finally {
				sqlConx.Close();
			}

			if (success) {
				XtraMessageBox.Show("Подключение прошло успешно", "Успех");
			}
			else {
				XtraMessageBox.Show("Ошибка подключения:\n " + exception.Message, "Успех");
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			Close();
		}

		private void FindNetworkServers() {
			var instance = SqlDataSourceEnumerator.Instance;
			var table = instance.GetDataSources();
			foreach (DataRow row in table.Rows) {
				string serverName = row["ServerName"].ToString();
				string instanceName = row["InstanceName"].ToString();

				string serverFullName = serverName +
					(instanceName != string.Empty && instanceName != "\\" ? "\\" + instanceName : "");
				if (InvokeRequired) {
					Invoke(new Action(() => cmbServer.Properties.Items.Add(serverFullName)));
				}
				else {
					cmbServer.Properties.Items.Add(serverFullName);
				}
			}
		}
		
		private BackgroundWorker backgroundWorker = new BackgroundWorker();
		private bool serversBeenAlreadySearched = false;

		private void cmbServer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
			if (!backgroundWorker.IsBusy && !serversBeenAlreadySearched) {
				backgroundWorker.DoWork += new DoWorkEventHandler(bgw_DoWork);
				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
				backgroundWorker.RunWorkerAsync();
			}
		}

		private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			serversBeenAlreadySearched = true;
			ajax.Visible = false;
			cmbServer.ShowPopup();
		}

		private void bgw_DoWork(object sender, DoWorkEventArgs e) {
			Invoke(new Action(() => ajax.Visible = true));
			FindNetworkServers();
		}		

		private void cmbBd_Properties_Popup(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
			if (needToReloadDataBases) {
				ReloadDatabases();
			}
			needToReloadDataBases = false;
			
		}

	
	}
}