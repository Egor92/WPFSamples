using System;

namespace MVVM.ShowChildWindow.Dialogs.Abstractions
{
    interface IInteractionAware
    {
        Action FinishInteraction { get; set; }
    }
}
