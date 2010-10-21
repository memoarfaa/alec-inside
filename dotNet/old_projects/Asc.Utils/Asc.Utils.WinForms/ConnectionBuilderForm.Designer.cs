namespace Asc.Utils.WinForms {
	partial class ConnectionBuilderForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnTest = new DevExpress.XtraEditors.SimpleButton();
			this.cmbBd = new DevExpress.XtraEditors.ComboBoxEdit();
			this.simpleConnectionStringBuilderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtUser = new DevExpress.XtraEditors.TextEdit();
			this.radioItegratedSequrity = new DevExpress.XtraEditors.RadioGroup();
			this.cmbServer = new DevExpress.XtraEditors.ComboBoxEdit();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.ajax = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleConnectionStringBuilderBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioItegratedSequrity.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ajax)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
			this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
			this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
			this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Controls.Add(this.btnTest);
			this.layoutControl1.Controls.Add(this.cmbBd);
			this.layoutControl1.Controls.Add(this.txtPassword);
			this.layoutControl1.Controls.Add(this.txtUser);
			this.layoutControl1.Controls.Add(this.radioItegratedSequrity);
			this.layoutControl1.Controls.Add(this.cmbServer);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(364, 230);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(268, 194);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 28);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(166, 194);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(91, 28);
			this.btnTest.TabIndex = 9;
			this.btnTest.Text = "Тест";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// cmbBd
			// 
			this.cmbBd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.simpleConnectionStringBuilderBindingSource, "Database", true));
			this.cmbBd.Location = new System.Drawing.Point(112, 163);
			this.cmbBd.Name = "cmbBd";
			this.cmbBd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbBd.Size = new System.Drawing.Size(246, 20);
			this.cmbBd.TabIndex = 8;
			this.cmbBd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbBd_Properties_Popup);
			// 
			// simpleConnectionStringBuilderBindingSource
			// 
			this.simpleConnectionStringBuilderBindingSource.DataSource = typeof(Asc.Utils.WinForms.SimpleConnectionStringBuilder);
			// 
			// txtPassword
			// 
			this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.simpleConnectionStringBuilderBindingSource, "Password", true));
			this.txtPassword.Location = new System.Drawing.Point(112, 132);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(246, 20);
			this.txtPassword.TabIndex = 7;
			// 
			// txtUser
			// 
			this.txtUser.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.simpleConnectionStringBuilderBindingSource, "User", true));
			this.txtUser.Location = new System.Drawing.Point(112, 101);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(246, 20);
			this.txtUser.TabIndex = 6;
			// 
			// radioItegratedSequrity
			// 
			this.radioItegratedSequrity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.simpleConnectionStringBuilderBindingSource, "IntegratedSecurity", true));
			this.radioItegratedSequrity.Location = new System.Drawing.Point(7, 38);
			this.radioItegratedSequrity.Name = "radioItegratedSequrity";
			this.radioItegratedSequrity.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.radioItegratedSequrity.Properties.Appearance.Options.UseBackColor = true;
			this.radioItegratedSequrity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.radioItegratedSequrity.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Windows Authentification"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "SQL Server Authentification")});
			this.radioItegratedSequrity.Size = new System.Drawing.Size(351, 52);
			this.radioItegratedSequrity.TabIndex = 5;
			this.radioItegratedSequrity.SelectedIndexChanged += new System.EventHandler(this.radioItegratedSequrity_SelectedIndexChanged);
			// 
			// cmbServer
			// 
			this.cmbServer.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.simpleConnectionStringBuilderBindingSource, "ServerName", true));
			this.cmbServer.Location = new System.Drawing.Point(112, 7);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbServer.Size = new System.Drawing.Size(246, 20);
			this.cmbServer.TabIndex = 4;
			this.cmbServer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbServer_ButtonClick);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "Root";
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(364, 230);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "Root";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cmbServer;
			this.layoutControlItem1.CustomizationFormText = "Имя сервера:";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(362, 31);
			this.layoutControlItem1.Text = "Имя сервера:";
			this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(100, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.radioItegratedSequrity;
			this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 31);
			this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 63);
			this.layoutControlItem2.MinSize = new System.Drawing.Size(61, 63);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(362, 63);
			this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem2.Text = "layoutControlItem2";
			this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextToControlDistance = 0;
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.txtUser;
			this.layoutControlItem3.CustomizationFormText = "Имя пользователя: ";
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 94);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(362, 31);
			this.layoutControlItem3.Text = "Имя пользователя: ";
			this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(100, 13);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.txtPassword;
			this.layoutControlItem4.CustomizationFormText = "Пароль:";
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 125);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(362, 31);
			this.layoutControlItem4.Text = "Пароль:";
			this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem4.TextSize = new System.Drawing.Size(100, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.cmbBd;
			this.layoutControlItem5.CustomizationFormText = "База данных:";
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 156);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(362, 31);
			this.layoutControlItem5.Text = "База данных:";
			this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem5.TextSize = new System.Drawing.Size(100, 13);
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnTest;
			this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
			this.layoutControlItem6.Location = new System.Drawing.Point(159, 187);
			this.layoutControlItem6.MaxSize = new System.Drawing.Size(102, 39);
			this.layoutControlItem6.MinSize = new System.Drawing.Size(102, 39);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(102, 41);
			this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem6.Text = "layoutControlItem6";
			this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextToControlDistance = 0;
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.btnSave;
			this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
			this.layoutControlItem7.Location = new System.Drawing.Point(261, 187);
			this.layoutControlItem7.MaxSize = new System.Drawing.Size(101, 39);
			this.layoutControlItem7.MinSize = new System.Drawing.Size(101, 39);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(101, 41);
			this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem7.Text = "layoutControlItem7";
			this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextToControlDistance = 0;
			this.layoutControlItem7.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 187);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(159, 41);
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// ajax
			// 
			this.ajax.BackColor = System.Drawing.Color.Transparent;
			this.ajax.Image = global::Asc.Utils.WinForms.Properties.Resources.ajax_loader;
			this.ajax.Location = new System.Drawing.Point(83, 4);
			this.ajax.Name = "ajax";
			this.ajax.Size = new System.Drawing.Size(26, 26);
			this.ajax.TabIndex = 12;
			this.ajax.TabStop = false;
			this.ajax.Visible = false;
			// 
			// ConnectionBuilderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 230);
			this.ControlBox = false;
			this.Controls.Add(this.ajax);
			this.Controls.Add(this.layoutControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ConnectionBuilderForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройка подключения";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbBd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleConnectionStringBuilderBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioItegratedSequrity.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ajax)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraEditors.ComboBoxEdit cmbServer;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.RadioGroup radioItegratedSequrity;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraEditors.ComboBoxEdit cmbBd;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private DevExpress.XtraEditors.TextEdit txtUser;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnTest;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private System.Windows.Forms.BindingSource simpleConnectionStringBuilderBindingSource;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private System.Windows.Forms.PictureBox ajax;
	}
}