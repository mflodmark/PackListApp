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
	    private readonly Quickies _quickies;

		public MainListItems (Quickies quickies)
		{
			InitializeComponent ();

		    _quickies = quickies;

		    BindingContext = _quickies;

		    MainListItemsListView.ItemsSource = _quickies.Items;
		}

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        
	    }

	    private void Add_OnClicked(object sender, EventArgs e)
	    {
	        
	    }
	}
}