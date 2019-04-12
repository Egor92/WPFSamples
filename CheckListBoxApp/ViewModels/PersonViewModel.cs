using System.Windows;

namespace CheckListBoxApp.ViewModels
{
	public class PersonViewModel
	{
		private bool _isSelected;

		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				_isSelected = value;
				MessageBox.Show($"{Name}. {nameof(IsSelected)} = {value}");
			}
		}

		public string Name { get; set; }
	}
}