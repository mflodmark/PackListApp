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
	public partial class NewList : ContentPage
	{
	    private readonly ObservableCollection<Quickies> _quickies;

	    public NewList (ObservableCollection<Quickies> quickies)
		{
			InitializeComponent ();

		    _quickies = quickies;
		}

		private async void QuickBtn_OnClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewQuickie(_quickies));
		}

		private void MyOwnBtn_OnClicked(object sender, EventArgs e)
		{
			
		}

		private void NewBlankBtn_OnClicked(object sender, EventArgs e)
		{
			
		}
	}
}