using System;
using Xamarin.Forms;

namespace eolymp
{
	public class MainLink : Button
	{
		public MainLink (string name)
		{
			Text = name;
			Device.OnPlatform (Android: () => {
				TextColor = Color.Black;
			});
			BackgroundColor = Color.Transparent;
			Command = new Command (o => {
				App.MasterDetailPage.Detail = new NavigationPage(new LinkPage(name));
				App.MasterDetailPage.IsPresented = false;
			});
		}
	}
}

