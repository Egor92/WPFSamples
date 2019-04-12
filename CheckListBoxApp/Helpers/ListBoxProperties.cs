using System.Windows;

namespace CheckListBoxApp.Helpers
{
	public static class ListBoxProperties
	{
		public static readonly DependencyProperty IsCheckedPathProperty = DependencyProperty.RegisterAttached(
			"IsCheckedPath", typeof(string), typeof(ListBoxProperties));

		public static void SetIsCheckedPath(DependencyObject element, string value)
		{
			element.SetValue(IsCheckedPathProperty, value);
		}

		public static string GetIsCheckedPath(DependencyObject element)
		{
			return (string) element.GetValue(IsCheckedPathProperty);
		}
	}
}