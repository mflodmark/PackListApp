using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PackListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPackList : ContentPage
	{
		public UserPackList ()
		{
			InitializeComponent ();
		}


	    private void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        
	    }

	    private void MyListView_OnRefreshing(object sender, EventArgs e)
	    {
	        
	    }

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        
	    }


	    private async void Add_OnClicked(object sender, EventArgs e)
	    {
            await Navigation.PushAsync(new Options());
        }
	}
}