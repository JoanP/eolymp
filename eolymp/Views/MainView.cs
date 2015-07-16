using System;
using Xamarin.Forms;

namespace eolymp
{
	public class MainView : MasterDetailPage
	{
		private MainViewModel mVM;

		public MainView ()
		{
			mVM = new MainViewModel ();
			Master = new menuPage (mVM);
			Detail = new NavigationPage (new LinkPage ("A"));
		}

		public class menuPage : ContentPage
		{
			public ListView menu{ get; set;}
			public menuPage (MainViewModel mVM)
			{
				Icon = "menu55.png";
				Title = "Menu";
				menu = new MenuListView (mVM);
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

		public class MenuListView : ListView
		{
			public MenuListView (MainViewModel mVM)
			{
				var data = mVM.getMenuList();
				ItemsSource = data;
				SelectedItem = data.Find (x => x.Title.Equals ("INICIO"));
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Color.Transparent;

				var cell = new DataTemplate (typeof(ImageCell));
				cell.SetBinding(TextCell.TextProperty, "Title");
				cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
				ItemTemplate = cell;
				ItemTapped += (sender, e) => {
					MenuPageItem tapped = SelectedItem as MenuPageItem;
					if(tapped.Title =="Competeix") {/*App.MasterDetailPage.Detail*/((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage (new ActivitatsView());}
					else {/*App.MasterDetailPage.Detail*/((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage (new LinkPage(tapped.Title));}
					/*App.MasterDetailPage.IsPresented = false;*/
					((MasterDetailPage)App.Current.MainPage).IsPresented = false;
				};


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
				Command = new Command (o => /*App.MasterDetailPage.Detail.Navigation.PushAsync(new LinkPage(name))*/((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new LinkPage(name)));
			}
		}
	}
}

