﻿using System;
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
    public partial class NewQuickie : ContentPage
    {
        private readonly ObservableCollection<EasyListViewModel> _quickies;

        public NewQuickie(ObservableCollection<EasyListViewModel> quickies)
        {
            InitializeComponent();

            _quickies = quickies;
        }

        private void SunBtn_OnClicked(object sender, EventArgs e)
        {
            PushToList();
        }


        private async void PushToList()
        {
            try
            {
                await Navigation.PushAsync(new ListQuickie(_quickies));
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Can't access page", "Ok");
            }
        }

        private void Snow_OnTapped(object sender, EventArgs e)
        {
            PushToList();
        }

    }
}