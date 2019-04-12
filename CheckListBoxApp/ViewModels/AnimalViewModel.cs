using System.Windows;

namespace CheckListBoxApp.ViewModels
{
	public class AnimalViewModel
	{
		private bool _isPet;

		public bool IsPet
		{
			get { return _isPet; }
			set
			{
				_isPet = value;
				MessageBox.Show($"{Name}. {nameof(IsPet)} = {value}");
			}
		}

		public string Name { get; set; }
	}
}