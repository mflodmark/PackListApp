using System.Collections.ObjectModel;
using System.Linq;
using PackListApp.Models;

namespace PackListApp.ViewModels
{
    public class EasyListViewModel: BaseViewModel
    {
        public EasyListViewModel(EasyList easyList)
        {
            Title = easyList.Title;
            Items = easyList.Items;
            EasyPacked = easyList.EasyPacked;
            QuantityText = easyList.QuantityText;
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        private bool _easyPacked;

        public bool EasyPacked
        {
            get => _easyPacked;
            set => SetValue(ref _easyPacked, GetPackedItems() == GetTotalItems());
        }
        
        private string _quantityText;

        public string QuantityText
        {
            get => _quantityText;
            set => SetValue(ref _quantityText, value);
        }

        private ObservableCollection<ListItemViewModel> _items;

        public ObservableCollection<ListItemViewModel> Items
        {
            get => _items;
            set => SetValue(ref _items, value);
        }

        public string Item
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public int GetPackedItems()
        {
            var packedItems = Items.Where(p => p.Packed).ToList().Count;

            return packedItems;
        }

        public int GetTotalItems()
        {
            return Items.Count;
        }


    }
}