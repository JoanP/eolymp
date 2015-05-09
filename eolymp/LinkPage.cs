using System;
using Xamarin.Forms;

namespace eolymp
{
	public class LinkPage : ContentPage
	{
		public LinkPage (string name)
		{
			Title = name;
			Content = new StackLayout {
				Children = {
					new SubLink (name + ".1"),
					new SubLink (name + ".2"),
					new SubLink (name + ".3"),
				},
			};
		}
	}
}

