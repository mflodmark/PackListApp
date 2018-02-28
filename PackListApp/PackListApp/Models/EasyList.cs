
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

    }
}