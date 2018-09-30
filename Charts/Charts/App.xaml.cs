using System.Windows;
using Charts.ViewModels;
using Charts.Views;

namespace Charts
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window
            {
                Title = "Charts demonstration app",
                Content = new MainView
                {
                    DataContext = new MainViewModel(),
                },
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };
            window.Show();
        }
    }
}
