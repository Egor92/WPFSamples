using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Navigation.Utils
{
    public class NavigationManager : INavigationManager
    {
        #region Fields

        private readonly Dispatcher _dispatcher;
        private readonly ContentControl _frameControl;
        private readonly IDictionary<string, object> _viewModelsByNavigationKey = new Dictionary<string, object>();
        private readonly IDictionary<Type, Type> _viewTypesByViewModelType = new Dictionary<Type, Type>();

        #endregion

        #region Ctor

        public NavigationManager(Dispatcher dispatcher, ContentControl frameControl)
        {
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");
            if (frameControl == null)
                throw new ArgumentNullException("frameControl");

            _dispatcher = dispatcher;
            _frameControl = frameControl;
        }

        #endregion

        public void Register<TViewModel, TView>(TViewModel viewModel, string navigationKey)
            where TViewModel : class
            where TView : FrameworkElement
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");
            if (navigationKey == null)
                throw new ArgumentNullException("navigationKey");

            _viewModelsByNavigationKey[navigationKey] = viewModel;
            _viewTypesByViewModelType[typeof (TViewModel)] = typeof (TView);
        }

        public void Navigate(string navigationKey, object arg = null)
        {
            if (navigationKey == null)
                throw new ArgumentNullException("navigationKey");

            InvokeInMainThread(() =>
            {
                InvokeNavigatingFrom();
                var viewModel = GetNewViewModel(navigationKey);
                InvokeNavigatingTo(viewModel, arg);

                var view = CreateNewView(viewModel);
                _frameControl.Content = view;
            });
        }

        private void InvokeInMainThread(Action action)
        {
            _dispatcher.Invoke(action);
        }

        private FrameworkElement CreateNewView(object viewModel)
        {
            var viewType = _viewTypesByViewModelType[viewModel.GetType()];
            var view = (FrameworkElement)Activator.CreateInstance(viewType);
            view.DataContext = viewModel;
            return view;
        }

        private object GetNewViewModel(string navigationKey)
        {
            return _viewModelsByNavigationKey[navigationKey];
        }

        private void InvokeNavigatingFrom()
        {
            var oldView = _frameControl.Content as FrameworkElement;
            if (oldView == null)
                return;

            var navigationAware = oldView.DataContext as INavigationAware;
            if (navigationAware == null)
                return;

            navigationAware.OnNavigatingFrom();
        }

        private static void InvokeNavigatingTo(object viewModel, object arg)
        {
            var navigationAware = viewModel as INavigationAware;
            if (navigationAware == null)
                return;

            navigationAware.OnNavigatingTo(arg);
        }
    }
}