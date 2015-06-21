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
				Detail = new NavigationPage (new LinkPage ("A")),

			};
			MainPage = MasterDetailPage;
	
		}
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
