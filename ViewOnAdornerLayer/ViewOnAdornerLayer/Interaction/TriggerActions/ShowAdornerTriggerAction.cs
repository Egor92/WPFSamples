using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Xaml.Behaviors;
using ViewOnAdornerLayer.Views;

namespace ViewOnAdornerLayer.Interaction.TriggerActions;

public class ShowAdornerTriggerAction : TriggerAction<UIElement>
{
    protected override void Invoke(object parameter)
    {
        if (parameter is not ShowAdornerEventArgs args)
            return;

        var adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
        if (adornerLayer != null)
        {
            //Очистите исходный декоратор
            var adorners = adornerLayer.GetAdorners(AssociatedObject);
            if (adorners != null)
            {
                foreach (var adorner in adorners.OfType<DialogAdorner>())
                {
                    adornerLayer.Remove(adorner);
                }
            }

            adornerLayer.Add(new DialogAdorner(AssociatedObject, args.ViewModel));
        }
    }
}