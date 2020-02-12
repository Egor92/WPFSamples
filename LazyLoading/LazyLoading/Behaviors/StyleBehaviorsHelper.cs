using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace LazyLoading.Behaviors
{
    public static class StyleBehaviorsHelper
    {
        public static void OnBehaviorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue)
                return;

            if (e.OldValue != null)
            {
                var behavior = (Behavior) e.OldValue;
                behavior.Detach();
            }

            if (e.NewValue != null)
            {
                var behavior = (Behavior) e.NewValue;
                behavior.Attach(d);
            }
        }
    }
}