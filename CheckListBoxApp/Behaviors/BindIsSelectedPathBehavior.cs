using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace CheckListBoxApp.Behaviors
{
	public class BindIsSelectedPathBehavior : Behavior<CheckBox>
	{
		#region IsSelectedPath

		public static readonly DependencyProperty IsSelectedPathProperty = DependencyProperty.Register("IsSelectedPath",
			typeof(string), typeof(BindIsSelectedPathBehavior), new PropertyMetadata(OnIsSelectedPathChanged));

		public string IsSelectedPath
		{
			get { return (string) GetValue(IsSelectedPathProperty); }
			set { SetValue(IsSelectedPathProperty, value); }
		}

		private static void OnIsSelectedPathChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var behavior = (BindIsSelectedPathBehavior) sender;
			behavior.OnIsSelectedPathChanged();
		}

		private void OnIsSelectedPathChanged()
		{
			ResetBinding();
		}

		#endregion

		protected override void OnAttached()
		{
			ResetBinding();
		}

		protected override void OnDetaching()
		{
			ClearBinding();
		}

		private void ResetBinding()
		{
			if (AssociatedObject == null || string.IsNullOrEmpty(IsSelectedPath))
			{
				ClearBinding();
			}
			else
			{
				SetBinding();
			}
		}

		private void SetBinding()
		{
			Binding binding = new Binding
			{
				Path = new PropertyPath(IsSelectedPath),
				Mode = BindingMode.TwoWay,
				UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
			};
			BindingOperations.SetBinding(AssociatedObject, ToggleButton.IsCheckedProperty, binding);
		}

		private void ClearBinding()
		{
			BindingOperations.ClearBinding(AssociatedObject, ToggleButton.IsCheckedProperty);
		}
	}
}