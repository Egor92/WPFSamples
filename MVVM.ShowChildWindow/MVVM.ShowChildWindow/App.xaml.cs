using System.Windows;
using MVVM.ShowChildWindow.ViewModels;
using MVVM.ShowChildWindow.Views;

namespace MVVM.ShowChildWindow
{
    public partial class App : Application
    {
        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            var dialogManager = new DialogManager();
            dialogManager.Register<ChildViewModel, ChildView>();

            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(dialogManager),
            };
            mainWindow.Show();
        }

        #endregion
    }
}
