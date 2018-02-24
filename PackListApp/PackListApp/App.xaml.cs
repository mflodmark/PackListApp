using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace PackListApp
{
	public partial class App : Application
	{
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
	}
}
