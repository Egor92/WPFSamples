using System.Windows;

namespace CheckListBoxApp.ViewModels
{
	public class ShapeViewModel
	{
		private bool _isTriangle;

		public bool IsTriangle
		{
			get { return _isTriangle; }
			set
			{
				_isTriangle = value;
				MessageBox.Show($"{Name}. {nameof(IsTriangle)} = {value}");
			}
		}

		public string Name { get; set; }
	}
}