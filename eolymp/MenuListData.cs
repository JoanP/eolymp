using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eolymp
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add(new MenuItem () {
				Title = "INICIO",
				IconSource = "home24.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "ACTIVIDAD",
				IconSource = "bar24.png",
				TargetType = typeof(TabbedPage)
			});
			this.Add(new MenuItem () {
				Title = "RETOS",
				IconSource = "target21.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "PREMIUM",
				IconSource = "refresh24.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "CONFIGURACIÓN",
				IconSource = "settings24.png",
				TargetType = typeof(ContentPage)
			});
		}
	}
}

