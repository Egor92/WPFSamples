using System.Collections.ObjectModel;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : NotificationObject
    {
        #region Ctor

        public MainViewModel()
        {
            FamilyVMs = new ObservableCollection<FamilyViewModel>();
        }

        #endregion

        #region FamilyVMs

        private ObservableCollection<FamilyViewModel> _FamilyVMs;

        public ObservableCollection<FamilyViewModel> FamilyVMs
        {
            get { return _FamilyVMs; }
            set { SetProperty(ref _FamilyVMs, value, () => FamilyVMs); }
        }

        #endregion

        #region AddFamilyCommand

        private DelegateCommand _AddFamilyCommand;

        public DelegateCommand AddFamilyCommand
        {
            get { return _AddFamilyCommand ?? (_AddFamilyCommand = new DelegateCommand(AddFamilyExecute)); }
        }

        private void AddFamilyExecute()
        {
            FamilyVMs.Add(new FamilyViewModel());
        }

        #endregion
    }
}
