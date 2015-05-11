using System;
using Xamarin.Forms;

namespace eolymp
{
	public class menuPage : ContentPage
	{
		public ListView menu{ get; set;}
		public menuPage ()
		{
			Icon = "menu55.png";
			Title = "Menu";
			menu = new MenuListView ();
			var menuLabel = new ContentView {
				Padding = new Thickness (10,35,0,5),
				Content = new Label {
					TextColor = Color.White,
					Text = "Menu",
				}
			};
			var layout = new StackLayout {
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			layout.Children.Add(menuLabel);
			layout.Children.Add(menu);
			Content = layout;
			BackgroundColor = Color.Gray.WithLuminosity (0.9);
		}
	}
}

