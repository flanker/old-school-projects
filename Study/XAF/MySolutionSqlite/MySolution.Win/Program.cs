using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Data.SQLite;

namespace MySolution.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if EASYTEST
			DevExpress.ExpressApp.EasyTest.WinAdapter.RemotingRegistration.Register(4100);
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            MySolutionWindowsFormsApplication winApplication = new MySolutionWindowsFormsApplication();
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                

                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                SQLiteConnection conn = new SQLiteConnection(connectionString);

                winApplication.Connection = conn;

                //winApplication.ConnectionString = connectionString;
                //DevExpress.Xpo.XpoDefault.DataLayer = DevExpress.Xpo.XpoDefault.GetDataLayer(connectionString, 
                //    DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            }
            try
            {
                winApplication.Setup();
                winApplication.Start();
            }
            catch (Exception e)
            {
                winApplication.HandleException(e);
            }
        }
    }
}
