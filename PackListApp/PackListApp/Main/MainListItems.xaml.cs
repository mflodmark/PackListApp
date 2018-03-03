using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackListApp.Models;
using PackListApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PackListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainListItems : ContentPage
    {
        private readonly EasyListViewModel _selectedList;

        public MainListItems(EasyListViewModel selectedList)
        {
            InitializeComponent();

            _selectedList = selectedList;

            BindingContext = _selectedList;

            UpdateTitle();
            MainListItemsListView.ItemsSource = _selectedList.Items;
        }

        private void UpdateTitle()
        {
            TitleLabel.Text = $"{_selectedList.GetPackedItems()} / {_selectedList.GetTotalItems()}";
            _selectedList.QuantityText = $"{_selectedList.GetPackedItems()} / {_selectedList.GetTotalItems()}";
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
            if (!response) return;

            var selected = (sender as MenuItem)?.CommandParameter as ListItemViewModel;
            _selectedList.Items.Remove(selected);

            UpdateTitle();
        }

        private void Add_OnClicked(object sender, EventArgs e)
        {
            ToEntryPage();
        }

        private async void ToEntryPage(ListItemViewModel listItem = null)
        {
            await Navigation.PushModalAsync(new MainNewListItem(_selectedList, listItem));

        }

        private void MainListItemsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //ItemSelected is called on deselection, which results in SelectedItem being set to null
            switch (e.SelectedItem)
            {
                case null:
                    return;
                case ListItemViewModel selected:
                    selected.Packed = !selected.Packed;
                    break;
            }
            
            ((ListView)sender).SelectedItem = null;

            UpdateTitle();
        }

        private void Edit_OnClicked(object sender, EventArgs e)
        {
            var selected = (sender as MenuItem)?.CommandParameter as ListItemViewModel;
            ToEntryPage(selected);
        }
    }
}