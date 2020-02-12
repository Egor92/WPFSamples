using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LazyLoading.ViewModels
{
    public class ItemViewModel : ReactiveObject
    {
        #region Ctor

        public ItemViewModel(int index)
        {
            Index = index;
            Data = $"Loading item {index}....";
        }

        #endregion

        #region Index

        public int Index { get; }

        #endregion

        #region Data

        [Reactive] 
        public string Data { get; private set; }

        #endregion

        #region IsLoading

        [Reactive]
        public bool IsLoading { get; private set; } = true;
        
        #endregion

        #region LoadingRequested

        private readonly Subject<int> _loadingRequested = new Subject<int>();

        public IObservable<int> LoadingRequested
        {
            get { return _loadingRequested.AsObservable(); }
        }

        #endregion

        #region LoadCommand

        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get { return _loadCommand ?? ReactiveCommand.Create(Load); }
        }

        private void Load()
        {
            _loadingRequested.OnNext(Index);
        }

        #endregion

        public void Update(string data)
        {
            IsLoading = false;
            Data = data;
        }
    }
}