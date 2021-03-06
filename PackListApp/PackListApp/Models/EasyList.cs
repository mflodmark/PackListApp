﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PackListApp.ViewModels;

namespace PackListApp.Models
{
    public class EasyList
    {
        public string Title { get; set; }

        public ObservableCollection<ListItemViewModel> Items { get; set; }

        public int ManCount { get; set; }

        public int WomenCount { get; set; }

        public int ChildrenCount { get; set; }

        public int TravelDays { get; set; }

        public bool EasyPacked => GetPackedItems() == GetTotalItems();

        public string QuantityText => $"{GetPackedItems()} / {GetTotalItems()}";

        public int GetPackedItems()
        {
            var packedItems = Items.Where(p => p.Packed).ToList().Count;

            return packedItems;
        }

        public int GetTotalItems()
        {
            return Items.Count;
        }

    }
}