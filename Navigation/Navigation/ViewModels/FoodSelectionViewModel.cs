using System.Windows;
using Navigation.Constants;
using Navigation.Models;
using Navigation.Utils;
using System.Linq;

namespace Navigation.ViewModels
{
    public class FoodSelectionViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public FoodSelectionViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region Properties

        #region Foods

        private Food[] _foods;

        public Food[] Foods
        {
            get { return _foods; }
            private set { SetProperty(ref _foods, value); }
        }

        #endregion

        #region SelectedFood

        private Food _selectedFood;

        public Food SelectedFood
        {
            get { return _selectedFood; }
            set
            {
                SetProperty(ref _selectedFood, value);
                CookFoodCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region CookFoodCommand

        private DelegateCommand _cookFoodCommand;

        public DelegateCommand CookFoodCommand
        {
            get { return _cookFoodCommand ?? (_cookFoodCommand = new DelegateCommand(CookFood, CanCookFood)); }
        }

        private void CookFood(object arg)
        {
            MessageBox.Show(string.Format("Ваш заказ '{0}' отправлен к шеф-повару", SelectedFood.Name));
            _navigationManager.Navigate(NavigationKeys.FoodCooking, SelectedFood);
        }

        private bool CanCookFood(object obj)
        {
            return SelectedFood != null;
        }

        #endregion

        #endregion

        #region Implementation of INavigationAware

        public void OnNavigatingTo(object arg)
        {
            Foods = new Food[]
            {
                new Food("Борщ", 70), 
                new Food("Щи", 60), 
                new Food("Картофель", 30), 
                new Food("Рис", 25), 
                new Food("Макароны", 20), 
                new Food("Оливье", 45), 
                new Food("Чай", 15), 
                new Food("Компот", 20), 
            };

            SelectedFood = Foods.FirstOrDefault();
        }

        public void OnNavigatingFrom()
        {

        }

        #endregion
    }
}
