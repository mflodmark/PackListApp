using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PackListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainNewListItem : ContentPage
	{
	    private ListItem _item;
	    private readonly List _selectedList;

	    public MainNewListItem (List selectedList)
		{
			InitializeComponent ();

		    _selectedList = selectedList;

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _item = new ListItem() {Item = e.NewTextValue}; 
        }

        private async void Done_Clicked(object sender, EventArgs e)
        {
            if (_item.Item.Length == 0)
            {
            }
            else
            {
                _selectedList.Items.Add(_item);

                await Navigation.PopModalAsync();
            }
        }
    }
}