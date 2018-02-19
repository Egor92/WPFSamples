using System.Windows;
using Navigation.Constants;
using Navigation.Utils;
using Navigation.ViewModels;
using Navigation.Views;

namespace Navigation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();
            var navigationManager = new NavigationManager(Dispatcher, window.FrameContent);

            var viewModel = new MainWindowViewModel(navigationManager);
            window.DataContext = viewModel;

            navigationManager.Register<FoodSelectionViewModel, FoodSelectionView>(new FoodSelectionViewModel(navigationManager), NavigationKeys.FoodSelection);
            navigationManager.Register<FoodCookingViewModel, FoodCookingView>(new FoodCookingViewModel(navigationManager), NavigationKeys.FoodCooking);

            window.Show();
        }
    }
}