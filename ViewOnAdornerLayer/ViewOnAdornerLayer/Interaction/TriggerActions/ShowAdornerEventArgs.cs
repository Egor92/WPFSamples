using System;

namespace ViewOnAdornerLayer.Interaction.TriggerActions;

public class ShowAdornerEventArgs : EventArgs
{
    public object ViewModel { get; set; }
}