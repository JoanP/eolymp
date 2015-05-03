using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			/*MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/
			MainPage = new RootPage ();
		}
			
		public class RootPage : MasterDetailPage {
			public RootPage () {
				var menuPage = new MenuPage ();

				menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

				Master = menuPage;
				Detail = new NavigationPage (new ContentPage (){
					Content = new Label () {
						Text = "Detail",
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				});
			}
			void NavigateTo (MenuItem Menu) {
				Page displayPage = (Page)Activator.CreateInstance (Menu.TargetType);
				Detail = new NavigationPage (displayPage);

				IsPresented = false;


			}
		}
		public class MenuPage : ContentPage {
			public ListView Menu { get; set; }

			public MenuPage (){
				this.Icon = "settings.png";
				this.Title = "menu";
				this.BackgroundColor = Color.FromHex("333333");

				this.Menu = new MenuListView ();

				var menuLabel = new ContentView{
					Padding = new Thickness (10, 35, 0, 5),
					Content = new Label {
						TextColor = Color.FromHex("AAAAAA"),
						Text = "MENU",
					}
				};
				var layout = new StackLayout {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
				layout.Children.Add(menuLabel);
				layout.Children.Add(Menu);

				Content = layout;
			}
		}
		public class MenuListView : ListView
		{
			public MenuListView (){
				List<MenuItem> data = new MenuListData();

				ItemsSource = data;
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Color.Transparent;

				var cell = new DataTemplate (typeof(ImageCell));
				cell.SetBinding(TextCell.TextProperty, "Title");
				cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

				ItemTemplate = cell;
			}
		}
		public class MenuItem {
			public string Title { get; set;}
			public string IconSource { get; set;}
			public Type TargetType { get; set;}
		}
		
		public class MenuListData : List<MenuItem> {
		
				public MenuListData () {
					this.Add(new MenuItem () {
						Title = "Contracts",
						IconSource = "contracts.png",
					TargetType = typeof(ContentPage)
					});
					this.Add(new MenuItem () {
						Title = "Leads",
						IconSource = "Lead.png",
					TargetType = typeof(ContentPage)
					});
					this.Add(new MenuItem () {
						Title = "Accounts",
						IconSource = "Accounts.png",
					TargetType = typeof(ContentPage)
					});
					this.Add(new MenuItem () {
						Title = "Opportunities",
						IconSource = "Opportunity.png",
					TargetType = typeof(ContentPage)
					});
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
