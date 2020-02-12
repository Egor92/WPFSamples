using System;

namespace LazyLoading.Model
{
    public interface IBusinessLogic
    {
        IObservable<Item[]> ItemsLoaded { get; }

        void RequestLoading(int index);
    }
}