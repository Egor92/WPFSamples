using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using ViewOnAdornerLayer.Infrastructure;
using ViewOnAdornerLayer.Interaction.TriggerActions;

namespace ViewOnAdornerLayer.ViewModels;

public class MainWindowViewModel
{
    #region ShowAdornerRequested

    [SuppressMessage("ReSharper", "EventNeverSubscribedTo.Global")]
    public event EventHandler<ShowAdornerEventArgs> ShowAdornerRequested;

    protected void RaiseShowAdornerRequested(object viewModel)
    {
        ShowAdornerRequested?.Invoke(this, new ShowAdornerEventArgs()
        {
            ViewModel = viewModel,
        });
    }

    #endregion

    #region ShowAdorderCommand

    private ICommand _showAdornerCommand;

    public ICommand ShowAdornerCommand
    {
        get { return _showAdornerCommand ??= new RelayCommand(ShowAdorner); }
    }

    private void ShowAdorner(object obj)
    {
        RaiseShowAdornerRequested(new DialogViewModel
        {
            Text = "Success!",
        });
    }

    #endregion
}