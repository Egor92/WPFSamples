using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace LazyLoading.Model
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly Random _random = new Random();

        private readonly Subject<Item[]> _itemsLoaded = new Subject<Item[]>();
        private readonly List<int> _requestedToLoadIndexes = new List<int>();
        private IDisposable _timerSubscription;

        public IObservable<Item[]> ItemsLoaded
        {
            get { return _itemsLoaded.AsObservable(); }
        }

        public void RequestLoading(int index)
        {
            _requestedToLoadIndexes.Add(index);

            _timerSubscription?.Dispose();
            _timerSubscription = Observable.Timer(TimeSpan.FromMilliseconds(100)).Subscribe(LoadItems);
        }

        private void LoadItems(long _)
        {
            var items = _requestedToLoadIndexes.Select(CreateItem).ToArray();
            _requestedToLoadIndexes.Clear();
            _itemsLoaded.OnNext(items);
        }

        private Item CreateItem(int index)
        {
            var price = _random.NextDouble() * 10000;
            return new Item
            {
                Index = index,
                Data = $"Item: {index}. Price: {price}"
            };
        }
    }
}