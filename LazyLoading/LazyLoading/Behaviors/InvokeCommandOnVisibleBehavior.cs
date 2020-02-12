using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace LazyLoading.Behaviors
{
    public class InvokeCommandOnVisibleBehavior : Behavior<UIElement>
    {
        private IDisposable _isVisibleChangedSubscription;
        private IDisposable _timerSubscription;

        #region Command

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(InvokeCommandOnVisibleBehavior));

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Delay

        public static readonly DependencyProperty DelayProperty = DependencyProperty.Register(
            "Delay", typeof(double), typeof(InvokeCommandOnVisibleBehavior), new PropertyMetadata(500.0));

        public double Delay
        {
            get { return (double) GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        #endregion

        #region Overridden members

        protected override void OnAttached()
        {
            AssociatedObject.IsVisibleChanged += AssociatedObject_IsVisibleChanged;
            _isVisibleChangedSubscription = Disposable.Create(() =>
            {
                AssociatedObject.IsVisibleChanged -= AssociatedObject_IsVisibleChanged;
            });

            OnIsVisibleChanged();
        }

        protected override void OnDetaching()
        {
            _isVisibleChangedSubscription?.Dispose();
            _timerSubscription?.Dispose();
        }

        #endregion

        private void AssociatedObject_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            OnIsVisibleChanged();
        }

        private void OnIsVisibleChanged()
        {
            if (!AssociatedObject.IsVisible)
            {
                _timerSubscription?.Dispose();
                return;
            }

            _timerSubscription = Observable.Timer(TimeSpan.FromMilliseconds(Delay)).ObserveOnDispatcher().Subscribe(_ =>
            {
                if (Command?.CanExecute(null) == true)
                {
                    Command.Execute(null);
                }
            });
        }
    }
}