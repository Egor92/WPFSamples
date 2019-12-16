using System;

namespace MVVM.ShowChildWindow.Dialogs.Implementations
{
    public class DialogData
    {
        public DialogData(Func<object> viewModelFunc, Func<object> viewFunc)
        {
            ViewModelFunc = viewModelFunc;
            ViewFunc = viewFunc;
        }

        public Func<object> ViewModelFunc { get; }

        public Func<object> ViewFunc { get; }
    }
}
