using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public App ()
		{
			  MasterDetailPage = new MasterDetailPage {
				Master = new menuPage (),
				Detail = new NavigationPage (new LinkPage ("A"))
			};
			MainPage = MasterDetailPage;
	
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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
