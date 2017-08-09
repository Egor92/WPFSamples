using System;
using System.Windows.Input;

namespace WpfApplication2
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _command;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action command, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            _canExecute = canExecute;
            _command = command;
        }

        public void Execute(object parameter)
        {
            _command();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
