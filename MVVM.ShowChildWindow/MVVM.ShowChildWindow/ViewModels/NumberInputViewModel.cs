using System;
using System.Windows.Input;
using MVVM.ShowChildWindow.Dialogs.Abstractions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MVVM.ShowChildWindow.ViewModels
{
    public class NumberInputViewModel : ReactiveObject, IDataHolder, IResultHolder, IInteractionAware
    {
        #region Implementation of IDataHolder

        public object Data { get; set; }

        #endregion

        #region Implementation of IResultHolder

        public object Result { get; set; }

        #endregion

        #region Implementation of IInteractionAware

        public Action FinishInteraction { get; set; }

        #endregion

        #region Number

        [Reactive]
        public int Number { get; set; }

        #endregion

        #region ChooseNumberCommand

        private ICommand _chooseNumberCommand;

        public ICommand ChooseNumberCommand
        {
            get { return _chooseNumberCommand ??= ReactiveCommand.Create(ChooseNumber); }
        }

        private void ChooseNumber()
        {
            Result = Number;
            FinishInteraction();
        }

        #endregion
    }
}
