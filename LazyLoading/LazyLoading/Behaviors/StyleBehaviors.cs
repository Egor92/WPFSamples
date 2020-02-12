using System.Windows;

namespace LazyLoading.Behaviors
{
    public static class StyleBehaviors
    {
        public static readonly DependencyProperty InvokeCommandOnVisibleBehaviorProperty =
            DependencyProperty.RegisterAttached("InvokeCommandOnVisibleBehavior",
                typeof(InvokeCommandOnVisibleBehavior), typeof(StyleBehaviors),
                new PropertyMetadata(StyleBehaviorsHelper.OnBehaviorChanged));

        public static void SetInvokeCommandOnVisibleBehavior(DependencyObject element, InvokeCommandOnVisibleBehavior value)
        {
            element.SetValue(InvokeCommandOnVisibleBehaviorProperty, value);
        }

        public static InvokeCommandOnVisibleBehavior GetInvokeCommandOnVisibleBehavior(DependencyObject element)
        {
            return (InvokeCommandOnVisibleBehavior) element.GetValue(InvokeCommandOnVisibleBehaviorProperty);
        }
    }
}