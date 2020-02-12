using System.Windows;
using LazyLoading.Model;
using LazyLoading.ViewModels;

namespace LazyLoading
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var application = new BusinessLogic();
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(application)
            };
            mainWindow.Show();
        }
    }
}