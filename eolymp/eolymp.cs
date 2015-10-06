using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new MainView ();
			DependencyService.Get<ICouchBase> ().crearDb ();
		}
		protected override void OnStart ()
		{
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
