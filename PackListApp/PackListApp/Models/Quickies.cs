
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PackListApp.Models
{
	public class Quickies
	{
	    public string Title { get; set; }

	    public ObservableCollection<QuickieItem> Items { get; set; }

	}
}