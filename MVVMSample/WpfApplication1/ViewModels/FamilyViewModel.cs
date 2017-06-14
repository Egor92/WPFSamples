using System.Collections.ObjectModel;

namespace WpfApplication1.ViewModels
{
    public class FamilyViewModel : NotificationObject
    {
        #region Ctor

        public FamilyViewModel()
        {
            PersonVMs = new ObservableCollection<PersonViewModel>();
        }

        #endregion

        #region Surname

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value, () => Surname); }
        }

        #endregion

        #region PersonVMs

        private ObservableCollection<PersonViewModel> _personVMs;

        public ObservableCollection<PersonViewModel> PersonVMs
        {
            get { return _personVMs; }
            set { SetProperty(ref _personVMs, value, () => PersonVMs); }
        }

        #endregion

        #region AddPersonCommand

        private DelegateCommand _AddPersonCommand;

        public DelegateCommand AddPersonCommand
        {
            get { return _AddPersonCommand ?? (_AddPersonCommand = new DelegateCommand(AddPersonExecute)); }
        }

        private void AddPersonExecute()
        {
            PersonVMs.Add(new PersonViewModel());
        }

        #endregion
    }
}
