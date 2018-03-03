using System.Collections.ObjectModel;
using PackListApp.Models;

namespace PackListApp.ViewModels
{
    public class EasyListViewModel: BaseViewModel
    {
        private readonly EasyList _easyList;

        public EasyListViewModel(EasyList easyList)
        {
            _easyList = easyList;
            Title = easyList.Title;
            Packed = easyList.EasyPacked;
            Items = easyList.Items;
            QuantityText = easyList.QuantityText;
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        private bool _packed;

        public bool Packed
        {
            get => _packed;
            set => SetValue(ref _packed, value);
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


    }
}