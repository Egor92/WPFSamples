using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Navigation.Constants;
using Navigation.Models;
using Navigation.Utils;

namespace Navigation.ViewModels
{
    public class FoodCookingViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public FoodCookingViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region Properties

        #region Food

        private Food _food;

        public Food Food
        {
            get { return _food; }
            private set { SetProperty(ref _food, value); }
        }

        #endregion

        #region CookingProgress

        private int _cookingProgress;

        public int CookingProgress
        {
            get { return _cookingProgress; }
            private set { SetProperty(ref _cookingProgress, value); }
        }

        #endregion

        #endregion

        #region Implementation of INavigationAware

        public void OnNavigatingTo(object arg)
        {
            Food = (Food)arg;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    CookingProgress = i;
                    Thread.Sleep(50);
                }

                MessageBox.Show(string.Format("Ваше блюдо готово. Садитесь кушать {0}, пожалуйста", Food.Name));
                _navigationManager.Navigate(NavigationKeys.FoodSelection);
            });

        }

        public void OnNavigatingFrom()
        {

        }

        #endregion
    }
}
