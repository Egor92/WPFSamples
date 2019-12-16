using System.Windows.Input;
using MVVM.ShowChildWindow.Dialogs;
using MVVM.ShowChildWindow.Dialogs.Abstractions;
using ReactiveUI;
using ReactiveCommand = ReactiveUI.ReactiveCommand;

namespace MVVM.ShowChildWindow.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        #region Fields

        private readonly IDialogManager _dialogManager;

        #endregion

        #region Ctor

        public MainWindowViewModel(IDialogManager dialogManager)
        {
            _dialogManager = dialogManager;
        }

        #endregion

        #region ShowSummaCommand

        private ICommand _showSummaCommand;

        public ICommand ShowSummaCommand
        {
            get { return _showSummaCommand ??= ReactiveCommand.Create(OnShowSumma); }
        }

        private void OnShowSumma()
        {
            var number1 = (int) _dialogManager.ShowDialog(DialogKeys.InputNumber, 1);
            var number2 = (int) _dialogManager.ShowDialog(DialogKeys.InputNumber, 2);

            var sum = number1 + number2;
            _dialogManager.ShowDialog(DialogKeys.DisplayNumber, sum);
        }

        #endregion
    }
}
