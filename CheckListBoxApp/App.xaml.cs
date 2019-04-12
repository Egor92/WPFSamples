using System.Windows;
using CheckListBoxApp.ViewModels;
using CheckListBoxApp.Views;

namespace CheckListBoxApp
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var window = new Window
			{
				Content = new MainView()
				{
					DataContext = new MainViewModel()
				}
			};
			window.Show();
		}
	}
}