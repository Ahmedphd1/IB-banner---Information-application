using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace IBbanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;

        // app logic that runs the main instance and checks for multiple instances
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.StartupUri = new System.Uri("login.xaml", System.UriKind.Relative);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "IBbanner";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }
    }
}
