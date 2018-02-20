using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PackListApp.Models;

namespace PackListApp.ViewModels
{
    class UserPackListViewModel
    {
        public ObservableCollection<Quickies> UserPackLists { get; set; } = new ObservableCollection<Quickies>();
    }
}
