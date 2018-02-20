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
	public partial class UserPackList : ContentPage
	{
	    private ObservableCollection<Quickies> _quickies;

        public UserPackList ()
		{
            //BindingContext = new UserPackListViewModel();

            InitializeComponent();

		    //BindingContext = GetQuickies();
		    _quickies = GetQuickies();
		    MyListView.ItemsSource = _quickies;

		    //MyListView.ItemsSource = new ObservableCollection<Quickies>();

		}

	    public ObservableCollection<Quickies> GetQuickies()
	    {
	        var quickies = new ObservableCollection<Quickies>();

	        var itemList1 = new ObservableCollection<QuickieItem>() { new QuickieItem() { Item = "Handskar" } };
	        var itemList2 = new ObservableCollection<QuickieItem> { new QuickieItem() { Item = "Skor" } };

	        quickies.Add(new Quickies() { Title = "Sol", Items = itemList1 });
	        quickies.Add(new Quickies() { Title = "Vinter", Items = itemList2 });

	        return quickies;
	    }


        private async void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var q = e.SelectedItem as Quickies;

            await Navigation.PushAsync(new ListQuickieItem(q));

	        //MyListView.SelectedItem = null;
        }

        private void MyListView_OnRefreshing(object sender, EventArgs e)
	    {
	        MyListView.EndRefresh();
        }

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        
	    }


	    private async void Add_OnClicked(object sender, EventArgs e)
	    {
            await Navigation.PushAsync(new Options(_quickies));
        }

	    private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        
	    }
	}
}