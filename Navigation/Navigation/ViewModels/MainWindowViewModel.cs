using System.Windows.Input;
using Navigation.Constants;
using Navigation.Utils;

namespace Navigation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public MainWindowViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region ShowFoodSelectionCommand

        private ICommand _showFoodSelectionCommand;

        public ICommand ShowFoodSelectionCommand
        {
            get { return _showFoodSelectionCommand ?? (_showFoodSelectionCommand = new DelegateCommand(ShowFoodSelection)); }
        }

        private void ShowFoodSelection(object arg)
        {
            _navigationManager.Navigate(NavigationKeys.FoodSelection);
        }

        #endregion
    }
}
