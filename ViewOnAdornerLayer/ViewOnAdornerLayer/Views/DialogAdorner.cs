using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace ViewOnAdornerLayer.Views;

public class DialogAdorner : Adorner
{
    private readonly VisualCollection _visuals;
    private readonly DialogView _dialogView;

    public DialogAdorner(UIElement uiElement, object viewModel)
        : base(uiElement)
    {
        _visuals = new VisualCollection(this);

        #region Определите, как выглядит декоратор

        _dialogView = new DialogView
        {
            DataContext = viewModel,
        };

        #endregion

        _visuals.Add(_dialogView);
    }

    protected override int VisualChildrenCount
    {
        get { return _visuals.Count; }
    }

    protected override Visual GetVisualChild(int index)
    {
        return _visuals[index];
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        _dialogView.Arrange(new Rect(finalSize));
        _dialogView.Margin = new Thickness(0, 0, 0, 0); //Нарисуйте окончательное положение декоратора на элементе
        return base.ArrangeOverride(finalSize);
    }
}