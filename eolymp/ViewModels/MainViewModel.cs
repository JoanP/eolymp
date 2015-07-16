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
	}
}

