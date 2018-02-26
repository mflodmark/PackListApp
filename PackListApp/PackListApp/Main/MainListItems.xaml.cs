using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PackListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainListItems : ContentPage
    {
        private readonly List _selectedList;

        public MainListItems(List selectedList)
        {
            InitializeComponent();

            _selectedList = selectedList;

            //BindingContext = _selectedList;

            MainListItemsListView.ItemsSource = _selectedList.Items;
        }

        private void Delete_OnClicked(object sender, EventArgs e)
        {

        }

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainNewListItem(_selectedList));
        }
    }
}