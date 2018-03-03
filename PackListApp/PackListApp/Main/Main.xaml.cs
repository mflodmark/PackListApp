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
	public partial class Main : ContentPage
	{
	    private readonly ObservableCollection<EasyListViewModel> _easyLists;

        public Main()
        {
            InitializeComponent();

            _easyLists = GetQuickies();
            MainListView.ItemsSource = _easyLists;
            //BindingContext = _easyLists;
        }


        public ObservableCollection<EasyListViewModel> GetQuickies()
	    {
	        var quickies = new ObservableCollection<EasyListViewModel>();

	        var itemList1 = new ObservableCollection<ListItemViewModel>() { new ListItemViewModel() { Item = "Handskar", Quantity = 2} };
	        var itemList2 = new ObservableCollection<ListItemViewModel> { new ListItemViewModel() { Item = "Skor", Quantity = 1} };

	        quickies.Add(new EasyListViewModel(new EasyList() { Title = "Sol", Items = itemList1 }));
            quickies.Add(new EasyListViewModel(new EasyList() { Title = "Vinter", Items = itemList2}));

            return quickies;
	    }


        private async void MainListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var q = e.SelectedItem as EasyListViewModel;

	        await Navigation.PushAsync(new MainListItems(q));

            ((ListView)sender).SelectedItem = null; 
        }



        private void MainListView_OnRefreshing(object sender, EventArgs e)
	    {
	        MainListView.ItemsSource = _easyLists;

            MainListView.EndRefresh();
        }

	    private async void Delete_OnClicked(object sender, EventArgs e)
	    {
	        var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
	        if (!response) return;

	        var selected = (sender as MenuItem)?.CommandParameter as EasyListViewModel;
	        _easyLists.Remove(selected);
	    }


	    private async void Add_OnClicked(object sender, EventArgs e)
	    {
            await Navigation.PushAsync(new NewList(_easyLists));
        }
	}
}