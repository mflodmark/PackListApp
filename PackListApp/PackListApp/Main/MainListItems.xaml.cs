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
        private readonly EasyList _selectedList;

        public MainListItems(EasyList selectedList)
        {
            InitializeComponent();

            _selectedList = selectedList;

            //BindingContext = _selectedList;

            MainListItemsListView.ItemsSource = _selectedList.Items;
        }

        private void Delete_OnClicked(object sender, EventArgs e)
        {

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
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var q = e.SelectedItem as ListItemViewModel;

            ToEntryPage(q);

            ((ListView)sender).SelectedItem = null;
        }

    }
}