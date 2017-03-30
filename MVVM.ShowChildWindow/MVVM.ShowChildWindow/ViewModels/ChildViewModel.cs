using ReactiveUI;

namespace MVVM.ShowChildWindow.ViewModels
{
    public class ChildViewModel : ReactiveObject
    {
        #region Sum

        private int _sum;

        public int Sum
        {
            get { return _sum; }
            set { this.RaiseAndSetIfChanged(ref _sum, value); }
        }

        #endregion
    }
}
