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
				IconSource = "contracts.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "ACTIVIDAD",
				IconSource = "Lead.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "RETOS",
				IconSource = "Accounts.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "PREMIUM",
				IconSource = "Accounts.png",
				TargetType = typeof(ContentPage)
			});
			this.Add(new MenuItem () {
				Title = "CONFIGURACIÓN",
				IconSource = "Opportunity.png",
				TargetType = typeof(ContentPage)
			});
		}
	}
}

