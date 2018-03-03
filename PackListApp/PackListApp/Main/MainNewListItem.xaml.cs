using System;
using System.Collections.Generic;
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
	public partial class MainNewListItem : ContentPage
	{
	    private readonly ListItemViewModel _item;
	    private readonly EasyList _selectedList;
	    private readonly bool _editItem;

	    public MainNewListItem (EasyList selectedList, ListItemViewModel listItem = null)
		{
			InitializeComponent ();

		    _selectedList = selectedList;

		    _item = listItem ?? new ListItemViewModel() {Item = "", Quantity = 0};
		    _editItem = listItem != null;

            if (listItem != null)
		    {
		        Stepper.Value = listItem.Quantity;
            }

            BindingContext = _item;
		}

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _item.Item = e.NewTextValue; 
        }

        private async void Done_Clicked(object sender, EventArgs e)
        {
            _item.Quantity = (int) Stepper.Value;

            if (_item.Item.Replace(" ", "").Length == 0)
            {
                await DisplayAlert("Missing value", "Enter name", "Ok");
            }
            else if (_editItem)
            {
                await Navigation.PopModalAsync();
            }
            else if (_editItem == false)
            {
                _selectedList.Items.Add(_item);

                await Navigation.PopModalAsync();
            }
        }

	    private async void Cancel_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync();
        }
    }
}