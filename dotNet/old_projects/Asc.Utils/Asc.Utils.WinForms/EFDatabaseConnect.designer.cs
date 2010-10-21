using System.Windows.Forms;
namespace Asc.Utils.WinForms
{
	partial class EFDatabaseConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.lblDelimiter = new System.Windows.Forms.Label();
			this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.txtServer = new DevExpress.XtraEditors.MRUEdit();
			this.ddlAuth = new DevExpress.XtraEditors.ComboBoxEdit();
			this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel( this.components );
			( (System.ComponentModel.ISupportInitialize)( this.txtServer.Properties ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.ddlAuth.Properties ) ).BeginInit();
			this.SuspendLayout();
			// 
			// lblDelimiter
			// 
			this.lblDelimiter.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblDelimiter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDelimiter.Font = new System.Drawing.Font( "Tahoma", 0.1F );
			this.lblDelimiter.Location = new System.Drawing.Point( 11, 135 );
			this.lblDelimiter.Name = "lblDelimiter";
			this.lblDelimiter.Size = new System.Drawing.Size( 352, 2 );
			this.lblDelimiter.TabIndex = 1;
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnConnect.Location = new System.Drawing.Point( 176, 147 );
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size( 106, 23 );
			this.btnConnect.TabIndex = 5;
			this.btnConnect.Text = "Подключиться";
			this.btnConnect.Click += new System.EventHandler( this.btnConnect_Click );
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point( 288, 148 );
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Выход";
			this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point( 91, 106 );
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size( 273, 21 );
			this.txtPassword.TabIndex = 4;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point( 91, 75 );
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size( 273, 21 );
			this.txtUser.TabIndex = 3;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point( 11, 107 );
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size( 41, 13 );
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Пароль:";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point( 11, 14 );
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size( 67, 13 );
			this.labelControl2.TabIndex = 5;
			this.labelControl2.Text = "Имя сервера:";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point( 11, 77 );
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size( 76, 13 );
			this.labelControl3.TabIndex = 6;
			this.labelControl3.Text = "Пользователь:";
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point( 11, 45 );
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size( 70, 13 );
			this.labelControl4.TabIndex = 7;
			this.labelControl4.Text = "Авторизация:";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point( 91, 13 );
			this.txtServer.Name = "txtServer";
			this.txtServer.Properties.Buttons.AddRange( new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)} );
			this.txtServer.Size = new System.Drawing.Size( 272, 20 );
			this.txtServer.TabIndex = 1;
			// 
			// ddlAuth
			// 
			this.ddlAuth.Location = new System.Drawing.Point( 91, 44 );
			this.ddlAuth.Name = "ddlAuth";
			this.ddlAuth.Properties.Buttons.AddRange( new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)} );
			this.ddlAuth.Properties.Items.AddRange( new object[] {
            "Windows",
            "SQLServer"} );
			this.ddlAuth.Size = new System.Drawing.Size( 272, 20 );
			this.ddlAuth.TabIndex = 2;
			this.ddlAuth.SelectedIndexChanged += new System.EventHandler( this.ddlAuth_SelectedIndexChanged );
			// 
			// defaultLookAndFeel1
			// 
			this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
			// 
			// EFDatabaseConnect
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size( 375, 182 );
			this.Controls.Add( this.ddlAuth );
			this.Controls.Add( this.txtServer );
			this.Controls.Add( this.labelControl1 );
			this.Controls.Add( this.btnCancel );
			this.Controls.Add( this.txtPassword );
			this.Controls.Add( this.btnConnect );
			this.Controls.Add( this.labelControl2 );
			this.Controls.Add( this.lblDelimiter );
			this.Controls.Add( this.labelControl3 );
			this.Controls.Add( this.txtUser );
			this.Controls.Add( this.labelControl4 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EFDatabaseConnect";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Подключение к  базе данных";
			( (System.ComponentModel.ISupportInitialize)( this.txtServer.Properties ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.ddlAuth.Properties ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

        }

        #endregion

        private Label lblDelimiter;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private TextBox txtPassword;
        private TextBox txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MRUEdit txtServer;
        private DevExpress.XtraEditors.ComboBoxEdit ddlAuth;
		private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;

    }
}