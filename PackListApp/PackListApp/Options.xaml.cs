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
	public partial class Options : ContentPage
	{
		public Options ()
		{
			InitializeComponent ();
		}

		private async void QuickBtn_OnClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new OptionQuickie());
		}

		private void MyOwnBtn_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void NewBlankBtn_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}