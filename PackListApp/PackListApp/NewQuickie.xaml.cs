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
    public partial class NewQuickie : ContentPage
    {
        public NewQuickie(ObservableCollection<Quickies> quickie)
        {
            InitializeComponent();
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