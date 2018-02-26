
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PackListApp.Models
{
    public class List
    {
        public string Title { get; set; }

        public ObservableCollection<ListItem> Items { get; set; }

    }
}