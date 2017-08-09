using System.Windows;
using WpfApplication2.ViewModels;
using WpfApplication2.Views;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Width = 500,
                Height = 500,
                Content = new MainView()
                {
                    DataContext = new MainViewModel()
                    {
                        Bool = false,
                        A = 255,
                        R = 34,
                        G = 62,
                        B = 165,
                        String = "Violet",
                    }
                }
            };
            window.Show();
        }
    }
}
