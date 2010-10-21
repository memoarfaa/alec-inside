namespace Asc.Utils.DevEx {
	partial class GridViewOptions {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btOk = new DevExpress.XtraEditors.SimpleButton();
			this.btCancel = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.dataColumnBindingSource = new System.Windows.Forms.BindingSource( this.components );
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colVisible = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.lineControl1 = new Asc.Utils.Controls.LineControl();
			( (System.ComponentModel.ISupportInitialize)( this.panelControl1 ) ).BeginInit();
			this.panelControl1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.panelControl2 ) ).BeginInit();
			this.panelControl2.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.gridControl1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataColumnBindingSource ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.gridView1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.repositoryItemCheckEdit1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.panelControl3 ) ).BeginInit();
			this.panelControl3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add( this.btOk );
			this.panelControl1.Controls.Add( this.btCancel );
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point( 0, 339 );
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size( 377, 49 );
			this.panelControl1.TabIndex = 1;
			// 
			// btOk
			// 
			this.btOk.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btOk.Location = new System.Drawing.Point( 178, 14 );
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size( 78, 23 );
			this.btOk.TabIndex = 1;
			this.btOk.Text = "OK";
			this.btOk.Click += new System.EventHandler( this.btOk_Click );
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point( 286, 14 );
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size( 79, 23 );
			this.btCancel.TabIndex = 0;
			this.btCancel.Text = "Отмена";
			this.btCancel.Click += new System.EventHandler( this.btCancel_Click );
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add( this.gridControl1 );
			this.panelControl2.Controls.Add( this.panelControl3 );
			this.panelControl2.Controls.Add( this.labelControl1 );
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl2.Location = new System.Drawing.Point( 0, 0 );
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Padding = new System.Windows.Forms.Padding( 10, 5, 10, 10 );
			this.panelControl2.Size = new System.Drawing.Size( 377, 338 );
			this.panelControl2.TabIndex = 3;
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.dataColumnBindingSource;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point( 10, 21 );
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange( new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1} );
			this.gridControl1.Size = new System.Drawing.Size( 357, 268 );
			this.gridControl1.TabIndex = 2;
			this.gridControl1.ViewCollection.AddRange( new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1} );
			// 
			// dataColumnBindingSource
			// 
			this.dataColumnBindingSource.DataSource = typeof( Asc.Utils.DevEx.GridViewOptions.DataColumn );
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange( new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVisible,
            this.colName} );
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gridView1.OptionsView.ShowColumnHeaders = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.OptionsView.ShowIndicator = false;
			this.gridView1.OptionsView.ShowVertLines = false;
			// 
			// colVisible
			// 
			this.colVisible.Caption = "Visible";
			this.colVisible.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colVisible.FieldName = "Visible";
			this.colVisible.Name = "colVisible";
			this.colVisible.OptionsColumn.FixedWidth = true;
			this.colVisible.Visible = true;
			this.colVisible.VisibleIndex = 0;
			this.colVisible.Width = 20;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler( this.repositoryItemCheckEdit1_EditValueChanged );
			// 
			// colName
			// 
			this.colName.Caption = "Name";
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.OptionsColumn.AllowEdit = false;
			this.colName.OptionsColumn.ReadOnly = true;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 1;
			this.colName.Width = 259;
			// 
			// panelControl3
			// 
			this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl3.Controls.Add( this.simpleButton2 );
			this.panelControl3.Controls.Add( this.simpleButton1 );
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl3.Location = new System.Drawing.Point( 10, 289 );
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size( 357, 39 );
			this.panelControl3.TabIndex = 4;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.simpleButton2.Location = new System.Drawing.Point( 143, 8 );
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size( 211, 23 );
			this.simpleButton2.TabIndex = 0;
			this.simpleButton2.Text = "Восстановить первоначальный вид";
			this.simpleButton2.Click += new System.EventHandler( this.simpleButton2_Click );
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point( 3, 8 );
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size( 114, 23 );
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "Отображать все";
			this.simpleButton1.Click += new System.EventHandler( this.simpleButton1_Click );
			// 
			// labelControl1
			// 
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point( 10, 5 );
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size( 357, 16 );
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Отображать столбцы:";
			// 
			// lineControl1
			// 
			this.lineControl1.BackColor = System.Drawing.Color.DimGray;
			this.lineControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lineControl1.Location = new System.Drawing.Point( 0, 338 );
			this.lineControl1.Name = "lineControl1";
			this.lineControl1.Size = new System.Drawing.Size( 377, 1 );
			this.lineControl1.TabIndex = 2;
			this.lineControl1.Text = "lineControl1";
			// 
			// DataViewOptions
			// 
			this.AcceptButton = this.btOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size( 377, 388 );
			this.Controls.Add( this.panelControl2 );
			this.Controls.Add( this.lineControl1 );
			this.Controls.Add( this.panelControl1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size( 370, 26 );
			this.Name = "DataViewOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройка отображения";
			( (System.ComponentModel.ISupportInitialize)( this.panelControl1 ) ).EndInit();
			this.panelControl1.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.panelControl2 ) ).EndInit();
			this.panelControl2.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.gridControl1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataColumnBindingSource ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.gridView1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.repositoryItemCheckEdit1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.panelControl3 ) ).EndInit();
			this.panelControl3.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton btOk;
		private DevExpress.XtraEditors.SimpleButton btCancel;
		private Asc.Utils.Controls.LineControl lineControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.BindingSource dataColumnBindingSource;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colVisible;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
	}
}