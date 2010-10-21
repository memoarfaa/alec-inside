using System;
using Asc.UIAppModel;
using System.Windows.Forms;
using Asc.Utils.WinForms;
using Asc.Logging;

namespace Asc.UIAppModel.WinForms {
    public class WinFormsAppInitialization : IUiApplicationBehavior {

        public void Initialize() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppExceptionHandling.SubscribeUnhandledExceptions(ExceptionPolicies.Common);
            DevExpress.UserSkins.OfficeSkins.Register();

            AppDomain.CurrentDomain.Load("Asc.AppModel");
            AppDomain.CurrentDomain.Load("Asc.Metal.Model.Aspects");
            AppDomain.CurrentDomain.Load("Asc.Logging");
            AppDomain.CurrentDomain.Load("Asc.Messaging.Wcf");
            AppDomain.CurrentDomain.Load("Asc.Metal.Core.Model");
            AppDomain.CurrentDomain.Load("Asc.Metal.Messages");
            AppDomain.CurrentDomain.Load("Asc.Metal.Model");
            AppDomain.CurrentDomain.Load("Asc.Metal.Operator.Runtime");
            AppDomain.CurrentDomain.Load("Asc.Metal.Operator.Services");
            AppDomain.CurrentDomain.Load("Asc.Metal.Operator.UI");
            AppDomain.CurrentDomain.Load("Asc.Metal.Security");
            AppDomain.CurrentDomain.Load("Asc.UIAppModel");
            AppDomain.CurrentDomain.Load("Asc.UIAppModel.WinForms");
            AppDomain.CurrentDomain.Load("Asc.Utils.CollectionExtensions");
            AppDomain.CurrentDomain.Load("Asc.Utils.DevExpress");
            AppDomain.CurrentDomain.Load("Asc.Utils.Validation");
            AppDomain.CurrentDomain.Load("Asc.Utils.WinForms");
            AppDomain.CurrentDomain.Load("BalloonHint");
            AppDomain.CurrentDomain.Load("DevExpress.Charts.v9.2.Core");
            AppDomain.CurrentDomain.Load("DevExpress.Data.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.OfficeSkins.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.Utils.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraBars.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraCharts.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraCharts.v9.2.UI");
            AppDomain.CurrentDomain.Load("DevExpress.XtraEditors.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraGauges.v9.2.Presets");
            AppDomain.CurrentDomain.Load("DevExpress.XtraGrid.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraLayout.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraNavBar.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraPrinting.v9.2");
            AppDomain.CurrentDomain.Load("DevExpress.XtraVerticalGrid.v9.2");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.EnterpriseLibrary.Common");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.EnterpriseLibrary.ExceptionHandling");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.EnterpriseLibrary.Logging");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.EnterpriseLibrary.Validation");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.ObjectBuilder2");
            AppDomain.CurrentDomain.Load("Microsoft.Practices.Unity");
            AppDomain.CurrentDomain.Load("PostSharp.Laos");
            AppDomain.CurrentDomain.Load("PostSharp.Public");

        }

    }
}
