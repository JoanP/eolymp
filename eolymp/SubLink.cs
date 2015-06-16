using System;
using Xamarin.Forms;

namespace eolymp
{
	public class SubLink : Button
	{
		public SubLink (string name)
		{
			BackgroundColor = Color.Transparent;
			Text = name;
			TextColor = Color.Blue;
			Command = new Command (o => App.MasterDetailPage.Detail.Navigation.PushAsync(new LinkPage(name)));
		}
	}
}

