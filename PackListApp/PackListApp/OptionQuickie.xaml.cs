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
	public partial class OptionQuickie : ContentPage
	{
		public OptionQuickie ()
		{
			InitializeComponent ();
		}

	    private void SunBtn_OnClicked(object sender, EventArgs e)
	    {
            
	        PushToList();
	    }

	    private void SnowBtn_OnClicked(object sender, EventArgs e)
	    {

	        PushToList();
        }



        private async void PushToList()
	    {
	        await Navigation.PushAsync(new ListQuickie());
        }
	}
}