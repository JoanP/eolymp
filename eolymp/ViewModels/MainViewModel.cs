using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class MainViewModel : ViewModelBase
	{
		private MenuListData menuList;
		
		public MainViewModel ()
		{
			menuList = new MenuListData ();
		}

		public MenuListData getMenuList(){
			return menuList;
		}

		public class MenuListData : List<MenuPageItem>
		{
			public MenuListData ()
			{
				this.Add(new MenuPageItem () {
					Title = "Inici",
					IconSource = "home.png",
					TargetType = typeof(ContentPage)
				});
				this.Add(new MenuPageItem () {
					Title = "Entrena",
					IconSource = "stopwatch.png",
					TargetType = typeof(ContentPage)
				});
				this.Add(new MenuPageItem () {
					Title = "Competeix",
					IconSource = "podium.png",
					TargetType = typeof(TabbedPage)
				});
				this.Add(new MenuPageItem () {
					Title = "Socialitza",
					IconSource = "social.png",
					TargetType = typeof(ContentPage)
				});
				this.Add(new MenuPageItem () {
					Title = "Configuració",
					IconSource = "conf.png",
					TargetType = typeof(ContentPage)
				});
			}
		}
	}
}

