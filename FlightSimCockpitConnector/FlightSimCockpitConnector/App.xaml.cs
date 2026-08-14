using System.Configuration;
using System.Data;
using System.Windows;

namespace FlightSimCockpitConnector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (s, ex) =>
            {
                MessageBox.Show(
                    ex.Exception.ToString(),
                    "Unhandled exception");

                ex.Handled = true;
            };

            base.OnStartup(e);
        }
    }

}
