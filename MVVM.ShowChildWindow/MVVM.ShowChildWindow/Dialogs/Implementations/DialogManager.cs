using System;
using System.Collections.Generic;
using System.Windows;
using MVVM.ShowChildWindow.Dialogs.Abstractions;

namespace MVVM.ShowChildWindow.Dialogs.Implementations
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, DialogData> _dialogDataByKey = new Dictionary<string, DialogData>();

        public void Register<TView>(string key, Func<object> getViewModel)
            where TView : FrameworkElement, new()
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (getViewModel == null)
            {
                throw new ArgumentNullException(nameof(getViewModel));
            }

            if (_dialogDataByKey.ContainsKey(key))
            {
                throw new ArgumentException($"Key {key} has already registered", nameof(key));
            }

            _dialogDataByKey[key] = new DialogData(getViewModel, () => new TView());
        }

        public object ShowDialog(string key, object data)
        {
            if (!_dialogDataByKey.ContainsKey(key))
            {
                throw new ArgumentException($"Key {key} wasn't registered", nameof(key));
            }

            var window = new Window()
            {
                Height = 200,
                Width = 300,
            };

            var dialogData = _dialogDataByKey[key];
            var view = (FrameworkElement) dialogData.ViewFunc();
            var viewModel = dialogData.ViewModelFunc();

            if (viewModel is IDataHolder dataHolder)
            {
                dataHolder.Data = data;
            }

            if (viewModel is IInteractionAware interactionAware)
            {
                interactionAware.FinishInteraction = () => window.Close();
            }

            window.Content = view;
            view.DataContext = viewModel;
            window.ShowDialog();

            return (viewModel as IResultHolder)?.Result;
        }
    }
}
