using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace eolymp
{
	public class MenuListView : ListView
	{
		public MenuListView ()
		{
				List<MenuItem> data = new MenuListData();
				ItemsSource = data;
				SelectedItem = data.Find (x => x.Title.Equals ("INICIO"));
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Color.Transparent;

				var cell = new DataTemplate (typeof(ImageCell));
				cell.SetBinding(TextCell.TextProperty, "Title");
				cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
				ItemTemplate = cell;
				ItemTapped += (sender, e) => {
					MenuItem tapped = SelectedItem as MenuItem;
					if(tapped.Title =="ACTIVIDAD") {App.MasterDetailPage.Detail = new NavigationPage (new ActivitatsView());}
					else {App.MasterDetailPage.Detail = new NavigationPage (new LinkPage(tapped.Title));}
					App.MasterDetailPage.IsPresented = false;
				};
				

		}
	}
}

