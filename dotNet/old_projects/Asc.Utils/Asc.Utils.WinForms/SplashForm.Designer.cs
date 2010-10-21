namespace Asc.Utils.WinForms {
	partial class SplashForm {
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelCopyright
			// 
			this.labelCopyright.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
			this.labelCopyright.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ) );
			this.labelCopyright.ForeColor = System.Drawing.Color.SteelBlue;
			this.labelCopyright.Location = new System.Drawing.Point( 119, 206 );
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size( 348, 13 );
			this.labelCopyright.TabIndex = 0;
			this.labelCopyright.Text = "© 2009 ЗАО \"Автоматизированные системы и комплексы\"";
			// 
			// labelProductName
			// 
			this.labelProductName.BackColor = System.Drawing.Color.Transparent;
			this.labelProductName.Font = new System.Drawing.Font( "Tahoma", 19.25F, System.Drawing.FontStyle.Bold );
			this.labelProductName.ForeColor = System.Drawing.Color.SlateGray;
			this.labelProductName.Location = new System.Drawing.Point( 17, 57 );
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size( 419, 69 );
			this.labelProductName.TabIndex = 1;
			this.labelProductName.Text = "АРМ Технолога";
			this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.BackColor = System.Drawing.Color.Transparent;
			this.labelVersion.Font = new System.Drawing.Font( "Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ) );
			this.labelVersion.ForeColor = System.Drawing.Color.DimGray;
			this.labelVersion.Location = new System.Drawing.Point( 21, 136 );
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size( 75, 14 );
			this.labelVersion.TabIndex = 3;
			this.labelVersion.Text = "Версия: {0}";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ) );
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point( 16, 12 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 261, 13 );
			this.label3.TabIndex = 2;
			this.label3.Text = "Система управления производством  АСК-Металл";
			// 
			// SplashForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Asc.Utils.WinForms.Properties.Resources.AscSplashFon1;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size( 476, 227 );
			this.Controls.Add( this.labelVersion );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.labelProductName );
			this.Controls.Add( this.labelCopyright );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplashForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label label3;
	}
}
