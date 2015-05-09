using System;
using Xamarin.Forms;

namespace eolymp
{
	public class menuPage : ContentPage
	{
		public ListView menu{ get; set;}
		public menuPage ()
		{
			menu = new MenuListView ();
			var menuLabel = new ContentView {
				Padding = new Thickness (10,35,0,5),
				Content = new Label {
					TextColor = Color.White,
					Text = "Menu",
				}
			};
			/*Content = new StackLayout {
				Padding = new Thickness (0, Device.OnPlatform<int> (20, 0, 0), 0, 0),
				Children = 
				
				
				
				{
					new MainLink ("INICIO"),
					new MainLink ("ACTIVIDAD"),
					new MainLink ("CONFIGURACIÓN"),
				}
			};*/
			var layout = new StackLayout {
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			layout.Children.Add(menuLabel);
			layout.Children.Add(menu);
			Content = layout;
			Title = "Master";
			BackgroundColor = Color.Gray.WithLuminosity (0.9);
			//Icon = "menu.png";
		}
	}
}

