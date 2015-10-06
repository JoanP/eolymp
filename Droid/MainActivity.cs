using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Droid;

namespace eolymp.Droid
{
	[Activity (Label = "eolymp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			ImageCircleRenderer.Init();
			//DependencyService.Get<ICouchBase>().crearDb();
			LoadApplication (new App ());
		}
	}
}

