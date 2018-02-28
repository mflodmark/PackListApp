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
	    private readonly ObservableCollection<EasyList> _quickies;

        public Main()
        {
            InitializeComponent();

            _quickies = GetQuickies();
            MainListView.ItemsSource = _quickies;
            //BindingContext = _quickies;
        }

	    public ObservableCollection<EasyList> GetQuickies()
	    {
	        var quickies = new ObservableCollection<EasyList>();

	        var itemList1 = new ObservableCollection<ListItemViewModel>() { new ListItemViewModel() { Item = "Handskar" } };
	        var itemList2 = new ObservableCollection<ListItemViewModel> { new ListItemViewModel() { Item = "Skor" } };

	        quickies.Add(new EasyList() { Title = "Sol", Items = itemList1 });
	        quickies.Add(new EasyList() { Title = "Vinter", Items = itemList2 });

	        return quickies;
	    }


        private async void MainListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var q = e.SelectedItem as EasyList;

	        await Navigation.PushAsync(new MainListItems(q));

            ((ListView)sender).SelectedItem = null; 
        }



        private void MainListView_OnRefreshing(object sender, EventArgs e)
	    {
	        MainListView.EndRefresh();
        }

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        
	    }


	    private async void Add_OnClicked(object sender, EventArgs e)
	    {
            await Navigation.PushAsync(new NewList(_quickies));
        }
	}
}