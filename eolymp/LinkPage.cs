using System;
using Xamarin.Forms;

namespace eolymp
{
	public class LinkPage : ContentPage
	{
		public LinkPage (string name)
		{
			Title = name;
			/*var t = new ToolbarItem();
			t.Icon = "settings.png";
			ToolbarItems.Add (t);*/
			Content = new StackLayout {
				BackgroundColor = Color.White,
				Children = {
					new SubLink (name + ".1"),
					new SubLink (name + ".2"),
					new SubLink (name + ".3"),
				},
			};
		}
	}
}

