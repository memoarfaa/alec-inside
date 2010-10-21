using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.EntityClient;


namespace Asc.Utils.WinForms {
	/// <summary>
	/// Настраивает соединение с базой данных.
	/// </summary>
	public partial class EFDatabaseConnect : XtraForm {
		private string csSectionName;
		private EFDatabaseConnect() {
			InitializeComponent();
		}
		/// <summary>
		/// Создает экземпляр формы
		/// </summary>
		/// <param name="csSectionName">имя секции строки подключения</param>
		/// <param name="hasDomainNetwork">есть домен</param>
		public EFDatabaseConnect( string csSectionName, bool hasDomainNetwork ) : this() {
			this.csSectionName = csSectionName;
			if ( hasDomainNetwork ) {
				ddlAuth.SelectedIndex = 0;
				FindNetworkServers();
			}
			else {
				ddlAuth.SelectedIndex = 1;
				ddlAuth.Enabled = false;
			}

			var csBuilder = GetConnectionStringBuilder( csSectionName );
			txtServer.Text = csBuilder.DataSource;
		}
		/// <summary>
		/// Пробует соединиться с базой данных
		/// </summary>
		/// <param name="csSectionName">имя секции строки подключения</param>
		/// <returns>true в случае успеха</returns>
		public static bool TryConnect( string csSectionName ) {
			try {
				var csBuilder = GetConnectionStringBuilder( csSectionName );
				var conn = new SqlConnection( csBuilder.ConnectionString );
				conn.Open();
				conn.Close();
			}
			catch ( SqlException ) {
				return false;
			}
			return true;
		}

		private static SqlConnectionStringBuilder GetConnectionStringBuilder( string csSectionName ) {
			var config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
			var csSection = config.ConnectionStrings;
			var cs = csSection.ConnectionStrings[ csSectionName ];
			var csBuilderEntity = new EntityConnectionStringBuilder( cs.ConnectionString );
			return new SqlConnectionStringBuilder( csBuilderEntity.ProviderConnectionString );
		}


		private void FindNetworkServers() {
			var instance = SqlDataSourceEnumerator.Instance;
			var table = instance.GetDataSources();
			foreach ( DataRow row in table.Rows ) {
				string serverName = row[ "ServerName" ].ToString();
				string instanceName = row[ "InstanceName" ].ToString();

				string serverFullName = serverName +
					( instanceName != string.Empty && instanceName != "\\" ? "\\" + instanceName : "" );
				txtServer.Properties.Items.Add( serverFullName );

			}
		}


		private void btnConnect_Click( object sender, EventArgs e ) {			
			var config = ConfigurationManager.OpenExeConfiguration(
				ConfigurationUserLevel.None );
			var csSection = config.ConnectionStrings;
			var cs = csSection.ConnectionStrings[ csSectionName ];
			var csBuilderEntity = new EntityConnectionStringBuilder( cs.ConnectionString );
			var csBuilder = new SqlConnectionStringBuilder( csBuilderEntity.ProviderConnectionString );


			csBuilder.DataSource = txtServer.Text;			

			csBuilder.IntegratedSecurity = ( ddlAuth.SelectedIndex == 0 );

			if ( !csBuilder.IntegratedSecurity ) {
				csBuilder.UserID = txtUser.Text;
				csBuilder.Password = txtPassword.Text;
			}			

			var cn = new SqlConnection( csBuilder.ConnectionString );
			try {
				cn.Open();
				cn.Close();
				csBuilderEntity.ProviderConnectionString = csBuilder.ConnectionString;
				cs.ConnectionString = csBuilderEntity.ConnectionString;
				config.Save( ConfigurationSaveMode.Modified );
				ConfigurationManager.RefreshSection( "connectionStrings" );

				DialogResult = DialogResult.OK;
			}			
			catch {
				XtraMessageBox.Show( "Ошибка подключения к базе данных" );
			}
		}		

		private void btnCancel_Click( object sender, EventArgs e ) {
			DialogResult = DialogResult.Cancel;
		}

		private void ddlAuth_SelectedIndexChanged( object sender, EventArgs e ) {
			if ( ddlAuth.SelectedIndex == 0 ) {
				txtUser.Enabled = txtPassword.Enabled = false;
			}
			else {
				txtUser.Enabled = txtPassword.Enabled = true;
			}
		}

	}
}