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
	    private readonly ObservableCollection<Quickies> _quickies;
	    private string _titel = "";

	    public ListQuickie (ObservableCollection<Quickies> quickies)
		{
			InitializeComponent ();

		    _quickies = quickies;

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
	        try
	        {
	            if (_titel.Length == 0)
	            {
	                await DisplayAlert("Missing Title", "Please enter a title", "Ok");
	            }
	            else
	            {
	                var quickie = new Quickies();

	                var list = new ObservableCollection<QuickieItem>()
	                {
	                    new QuickieItem() {Item = "Hat"},
	                    new QuickieItem() {Item = "Gloves"}
	                };

	                quickie.Items = list;
	                quickie.Title = _titel;

	                _quickies.Add(quickie);

	                await Navigation.PopToRootAsync();
	            }
            }
	        catch (Exception exception)
	        {
	            Console.WriteLine(exception);
	            DisplayAlert("Error", "Something went wrong", "Ok");
	        }


            
	    }

	    private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        _titel = e.NewTextValue;
	    }
	}
}