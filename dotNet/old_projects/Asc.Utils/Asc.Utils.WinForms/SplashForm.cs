using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Asc.Utils.WinForms {
	/// <summary>
	/// Заставка для приложения
	/// </summary>
	public partial class SplashForm : Form {		
		private static SplashForm instance;

		public SplashForm() {
			InitializeComponent();
			SetStyle( ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer, true );
		
			UpdateStyles();

			AssignRegion();
			SoftProductName = Application.ProductName;
			Version = Application.ProductVersion;
		}

		public string Copyrignt {
			get {
				return labelCopyright.Text;
			}
			set {
				labelCopyright.Text = value;
			}
		}

		/// <summary>
		/// Название программы
		/// </summary>
		public string SoftProductName {
			get {
				return labelProductName.Text;
			}
			set {
				labelProductName.Text = value;
			}
		}

		/// <summary>
		/// Версия программы
		/// </summary>
		public string Version {
			set {
				labelVersion.Text = String.Format( "Версия: {0}", value );
			}
		}

		#region painting
		private const int CS_DROPSHADOW = 0x00020000;
		private const int WS_EX_TOOLWINDOW = 0x00000080;

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= WS_EX_TOOLWINDOW;
				if ( IsSupportShadow() ) {
					cp.ClassStyle |= CS_DROPSHADOW;
				}
				return cp;
			}
		}

		private static bool IsSupportShadow() {
			return Environment.OSVersion.Platform == PlatformID.Win32NT &&
				   ( ( Environment.OSVersion.Version.Major >= 5 && Environment.OSVersion.Version.Minor >= 1 )
					|| Environment.OSVersion.Version.Major >= 6 );
		}

		private static GraphicsPath RoundRect( Rectangle rectangle, int roundRadius ) {
			Rectangle innerRect = Rectangle.Inflate( rectangle, -roundRadius, -roundRadius );
			var path = new GraphicsPath();

			path.StartFigure();

			path.AddArc( RoundBounds( innerRect.Right - 1, innerRect.Bottom - 1, roundRadius ), 0, 90 );
			path.AddArc( RoundBounds( innerRect.Left, innerRect.Bottom - 1, roundRadius ), 90, 90 );
			path.AddArc( RoundBounds( innerRect.Left, innerRect.Top, roundRadius ), 180, 90 );
			path.AddArc( RoundBounds( innerRect.Right - 1, innerRect.Top, roundRadius ), 270, 90 );
			path.CloseFigure();
			return path;
		}

		private static Rectangle RoundBounds( int x, int y, int rounding ) {
			return new Rectangle( x - rounding, y - rounding, 2 * rounding, 2 * rounding );
		}

		private void AssignRegion() {
			GraphicsPath rgRct = RoundRect( new Rectangle( Location, Size ), 5 );
			Region = new Region( rgRct );
		}

		[DllImport( "gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true )]
		private static extern bool FrameRgn( IntPtr hdc, IntPtr hrgn, IntPtr hbr, int nWidth, int nHeight );

		[DllImport( "gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true )]
		private static extern IntPtr CreateSolidBrush( Int32 crColor );

		[DllImport( "gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true )]
		private static extern bool DeleteObject( IntPtr hObject );

		protected override void OnPaint( PaintEventArgs e ) {
			e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			base.OnPaint( e );
			IntPtr hrgn = Region.GetHrgn( e.Graphics );
			IntPtr hdc = e.Graphics.GetHdc();
			IntPtr hBrush = CreateSolidBrush( ColorTranslator.ToOle( Color.Silver ) );

			FrameRgn( hdc, hrgn, hBrush, 1, 1 );
			Region.ReleaseHrgn( hrgn );
			DeleteObject( hBrush );
			e.Graphics.ReleaseHdc( hdc );
		}

		#endregion

		/// <summary>
		/// Отображает форму
		/// </summary>
		public static void ShowSelf() {
			if ( instance == null ) {
				instance = new SplashForm();
			}			
			Application.Run( instance );
		}

		/// <summary>
		/// Закрыть форму при возникновении события OnLoad в mainForm
		/// </summary>
		/// <param name="mainForm"></param>
		public static void CloseOnFormLoad( Form mainForm ) {
			mainForm.Load += mainForm_Load;
		}

		private static void mainForm_Load( object sender, EventArgs e ) {
			var mainForm = sender as Form;
			mainForm.Load -= mainForm_Load;
			mainForm.Activate();
			CloseSelf();

		}

		private delegate void InvokeDelegate();

		/// <summary>
		/// Закрыть форму
		/// </summary>
		public static void CloseSelf() {
			if ( instance != null ) {
				if ( !instance.InvokeRequired ) {
					if ( instance != null ) {
						instance.Close();
						instance.Dispose();
						instance = null;
					}
				}
				else {
					instance.Invoke( new InvokeDelegate( CloseSelf ) );
				}
			}
		}
	}
}