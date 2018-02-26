﻿using System;
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
	public partial class Main : ContentPage
	{
	    private readonly ObservableCollection<List> _quickies;

        public Main()
        {
            InitializeComponent();

            _quickies = GetQuickies();
            MainListView.ItemsSource = _quickies;
            //BindingContext = _quickies;
        }

	    public ObservableCollection<List> GetQuickies()
	    {
	        var quickies = new ObservableCollection<List>();

	        var itemList1 = new ObservableCollection<ListItem>() { new ListItem() { Item = "Handskar" } };
	        var itemList2 = new ObservableCollection<ListItem> { new ListItem() { Item = "Skor" } };

	        quickies.Add(new List() { Title = "Sol", Items = itemList1 });
	        quickies.Add(new List() { Title = "Vinter", Items = itemList2 });

	        return quickies;
	    }


        private async void MainListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var q = e.SelectedItem as List;

	        await Navigation.PushAsync(new MainListItems(q));
        }

	    private void MainListView_OnRefreshing(object sender, EventArgs e)
	    {
	        MainListView.EndRefresh();
        }

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        
	    }


	    private async void Add_OnClicked(object sender, EventArgs e)
	    {
            await Navigation.PushAsync(new NewList(_quickies));
        }
	}
}