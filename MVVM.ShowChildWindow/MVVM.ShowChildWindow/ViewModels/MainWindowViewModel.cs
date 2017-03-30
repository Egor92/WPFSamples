using System.Windows.Input;
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

        #region Number1

        private int _number1;

        public int Number1
        {
            get { return _number1; }
            set { this.RaiseAndSetIfChanged(ref _number1, value); }
        }

        #endregion

        #region Number2

        private int _number2;

        public int Number2
        {
            get { return _number2; }
            set { this.RaiseAndSetIfChanged(ref _number2, value); }
        }

        #endregion

        #region ShowSummaCommand

        private ICommand _showSummaCommand;

        public ICommand ShowSummaCommand
        {
            get { return _showSummaCommand ?? (_showSummaCommand = ReactiveCommand.Create(OnShowSumma)); }
        }

        private void OnShowSumma()
        {
            var childVM = new ChildViewModel()
            {
                Sum = Number1 + Number2,
            };
            _dialogManager.Show(childVM);
        }

        #endregion



    }
}
