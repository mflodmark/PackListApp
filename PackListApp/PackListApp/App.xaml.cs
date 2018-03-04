using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using PackListApp.ViewModels;
using Xamarin.Forms;

namespace PackListApp
{
	public partial class App : Application
	{
	    private const string MainListKey = "MainList";

		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Main())
			{
			    BarBackgroundColor = Color.FromHex("#82ccdd"),
			    BarTextColor = Color.White
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			AppCenter.Start("ios=b4040b68-8906-4063-9c16-da1252213ee9;" +
							"uwp={Your UWP App secret here};" +
							"android={Your Android App secret here}",
				typeof(Analytics), typeof(Crashes));

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    public ObservableCollection<EasyListViewModel> MainList
	    {
	        get => GetMainList();
	        set => SetMainList(value);
	    }

	    private ObservableCollection<EasyListViewModel> GetMainList()
	    {
	        ObservableCollection<EasyListViewModel> mainList;
	        if (Properties.ContainsKey(MainListKey))
	        {
	            var serializedValue = Properties[MainListKey].ToString();
	            mainList = JsonConvert.DeserializeObject<ObservableCollection<EasyListViewModel>>(serializedValue);
            }
	        else
	        {
                mainList = new ObservableCollection<EasyListViewModel>();
            }

            return mainList;
	    }

	    private void SetMainList(ObservableCollection<EasyListViewModel> newMainList)
	    {
	        var temp = JsonConvert.SerializeObject(newMainList);
	        Properties[MainListKey] = temp;

	    }
    }
}
