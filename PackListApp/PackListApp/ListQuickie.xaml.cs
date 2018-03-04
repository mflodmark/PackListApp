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
    public partial class ListQuickie : ContentPage
    {
        private readonly ObservableCollection<EasyListViewModel> _quickies;
        private string _titel = "";

        public ListQuickie(ObservableCollection<EasyListViewModel> quickies)
        {
            InitializeComponent();

            _quickies = quickies;

            var quickie = new EasyList();

            var list = new ObservableCollection<ListItemViewModel>()
            {
                new ListItemViewModel() {Item = "Hat"},
                new ListItemViewModel() {Item = "Gloves"}
            };

            quickie.Items = list;

            QuickieListView.ItemsSource = quickie.Items;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (_titel.Replace(" ", "").Length == 0)
                {
                    await DisplayAlert("Missing Title", "Please enter a title", "Ok");
                }
                else
                {
                    var quickie = new EasyListViewModel();

                    var list = new ObservableCollection<ListItemViewModel>()
                    {
                        new ListItemViewModel() {Item = "Hat"},
                        new ListItemViewModel() {Item = "Gloves"}
                    };

                    quickie.Items = list;
                    quickie.Title = _titel;
                    quickie.QuantityText = $"{quickie.GetPackedItems()} / {quickie.GetTotalItems()}";

                    _quickies.Add(quickie);

                    await Navigation.PopToRootAsync();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                await DisplayAlert("Error", "Something went wrong", "Ok");
            }



        }

        private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _titel = e.NewTextValue;
        }
    }
}