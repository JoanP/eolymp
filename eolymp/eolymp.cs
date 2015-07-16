using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class App : Application
	{
		public App ()
		{
			DependencyService.Get<ICouchBase>().crearDb();
			MainPage = new MainView ();
	
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
