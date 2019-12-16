using System.Windows;
using MVVM.ShowChildWindow.Dialogs;
using MVVM.ShowChildWindow.Dialogs.Implementations;
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
            dialogManager.Register<NumberInputView>(DialogKeys.InputNumber, () => new NumberInputViewModel());
            dialogManager.Register<NumberDisplayView>(DialogKeys.DisplayNumber, () => new NumberDisplayViewModel());

            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(dialogManager),
            };
            mainWindow.Show();
        }

        #endregion
    }
}
