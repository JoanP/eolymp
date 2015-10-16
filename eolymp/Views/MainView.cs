using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;




namespace eolymp
{
	public class MainView : MasterDetailPage
	{
		private MainViewModel mVM;
		public MainView ()
		{
			mVM = new MainViewModel ();
			Master = new menuPage (mVM);
			Detail = new NavigationPage (new IniciView());
		}

		public class menuPage : ContentPage
		{
			public ListView menu{ get; set;}
			public menuPage (MainViewModel mVM)
			{
				Icon = "menu55.png";
				Title = "Menu";
				menu = new MenuListView (mVM);
				var lab = new Label{
					Text = "Menu",
					TextColor = Color.White
				};
				lab.HorizontalOptions = LayoutOptions.CenterAndExpand;
				var menuLabel = new ContentView {
					Padding = new Thickness (10,35,0,5),
					Content = lab,
				};
				var layout = new StackLayout {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};
				Device.OnPlatform (iOS: () => {
					layout.Spacing = 5;
				});
				layout.Children.Add(menuLabel);
				layout.Children.Add(apartatPerfil());
				Device.OnPlatform (Android: () => {
					layout.Children[0].BackgroundColor = Color.Black;
					layout.Children[1].BackgroundColor = Color.Black;
				});
				layout.Children.Add(menu);
				Content = layout;
				Device.OnPlatform (iOS: () => {
					BackgroundColor = Color.Black.WithLuminosity (0.1);
				});
				Device.OnPlatform (Android: () => {
					BackgroundColor = Color.White;
				});
			}
			private StackLayout apartatPerfil(){
				var userFoto = new CircleImage
				{
					BorderColor = Color.White,
					BorderThickness = 3,
					HeightRequest = 80,
					WidthRequest = 80,
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Center,
					Source = "perfil.jpg",
				};
				var nom = new Label {
					Text = "Joan Pol",
					TextColor = Color.White,
				};
				var cognoms = new Label {
					Text = "Farre Serrano",
					TextColor = Color.White,
				};
				nom.FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label));
				cognoms.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				var logout = new Button { 
					Text = "Log out",
					TextColor = Color.Blue,
					BackgroundColor = Color.Transparent,
					BorderColor = Color.Transparent,
				};
				logout.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				var principal = new StackLayout{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};
				var secundari = new StackLayout {
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					//HorizontalOptions = LayoutOptions.EndAndExpand,
				};
				secundari.Children.Add (nom);
				secundari.Children.Add (cognoms);
				secundari.Children.Add (logout);
				//secundari.BackgroundColor = Color.White;
				principal.Spacing = 10;
				principal.Children.Add (userFoto);
				principal.Children.Add (secundari);
				principal.Children[0].WidthRequest = 100;
				principal.Padding = new Thickness (10, 0, 0, 0);
				return principal;

			}
		}
		public class tempImageCell : ImageCell {
			
			public tempImageCell(){
				Device.OnPlatform (iOS: () => {
					TextColor = Color.White;
				});
				Device.OnPlatform (Android: () => {
					TextColor = Color.Black;
				});
			}
		}
		public class MenuListView : ListView
		{
			public MenuListView (MainViewModel mVM)
			{
				var data = mVM.getMenuList();
				ItemsSource = data;
				SelectedItem = data.Find (x => x.Title.Equals ("Inici"));
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Color.Transparent;

				var cell = new DataTemplate (typeof(tempImageCell));
				cell.SetBinding(TextCell.TextProperty, "Title");
				cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
				ItemTemplate = cell;
				ItemTapped += (sender, e) => {
					MenuPageItem tapped = SelectedItem as MenuPageItem;
					if(tapped.Title =="Competeix") {/*App.MasterDetailPage.Detail*/((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage (new ActivitatsView());}
					else if(tapped.Title == "Inici") {((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage (new IniciView());}
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

