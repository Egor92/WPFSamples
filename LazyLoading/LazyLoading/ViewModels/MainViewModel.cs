using System;
using System.Collections.Generic;
using System.Linq;
using LazyLoading.Model;
using ReactiveUI;

namespace LazyLoading.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private readonly IBusinessLogic _businessLogic;
        private readonly Dictionary<int, ItemViewModel> _itemVMsByIndex;

        public MainViewModel(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            businessLogic.ItemsLoaded.Subscribe(OnItemsLoaded);

            ItemVMs = Enumerable.Range(1, 10000).Select(i => new ItemViewModel(i)).ToList();
            foreach (var itemVM in ItemVMs)
            {
                itemVM.LoadingRequested.Subscribe(OnLoadingRequested);
            }

            _itemVMsByIndex = ItemVMs.ToDictionary(x => x.Index);
        }

        public List<ItemViewModel> ItemVMs { get; }

        private void OnItemsLoaded(Item[] items)
        {
            foreach (var item in items)
            {
                var itemVM = _itemVMsByIndex[item.Index];
                itemVM.Update(item.Data);
            }
        }

        private void OnLoadingRequested(int index)
        {
            _businessLogic.RequestLoading(index);
        }
    }
}