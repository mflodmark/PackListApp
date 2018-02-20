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
	public partial class ListQuickie : ContentPage
	{
		public ListQuickie ()
		{
			InitializeComponent ();

		    var quickie = new Quickies();

            var list = new ObservableCollection<QuickieItem>()
            {
                new QuickieItem() {Item = "Hat"},
                new QuickieItem() {Item = "Gloves"}
            };


		    quickie.Items = list;

		    QuickieListView.ItemsSource = quickie.Items;
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {


            await Navigation.PopToRootAsync();
	    }
	}
}