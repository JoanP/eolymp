using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace eolymp
{
	public class MenuListView : ListView
	{
		public MenuListView ()
		{
				List<MenuPageItem> data = new MenuListData();
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
					if(tapped.Title =="Competeix") {App.MasterDetailPage.Detail = new NavigationPage (new ActivitatsView());}
					else {App.MasterDetailPage.Detail = new NavigationPage (new LinkPage(tapped.Title));}
					App.MasterDetailPage.IsPresented = false;
				};
				

		}
	}

	public class MenuListData : List<MenuPageItem>
	{
		public MenuListData ()
		{
			this.Add(new MenuPageItem () {
				Title = "Inici",
				IconSource = "home24.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuPageItem () {
				Title = "Entrena",
				IconSource = "crono.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuPageItem () {
				Title = "Competeix",
				IconSource = "Competeix.png",
				TargetType = typeof(TabbedPage)
			});
			this.Add(new MenuPageItem () {
				Title = "Socialitza",
				IconSource = "Socialitza.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuPageItem () {
				Title = "Configuració",
				IconSource = "settings24.png",
				TargetType = typeof(ContentPage)
			});
		}
	}
	public class MenuPageItem
	{
		public string Title { get; set;}
		public string IconSource { get; set;}
		public Type TargetType { get; set;}

		public MenuPageItem ()
		{	
			Title = "";
			IconSource = "";
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

}

