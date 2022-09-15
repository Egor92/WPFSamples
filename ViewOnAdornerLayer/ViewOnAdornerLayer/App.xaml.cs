using System.Windows;
using ViewOnAdornerLayer.ViewModels;

namespace ViewOnAdornerLayer;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(),
        };
        mainWindow.Show();
    }
}