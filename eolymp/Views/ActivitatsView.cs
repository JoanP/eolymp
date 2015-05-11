using System;
using Xamarin.Forms;

namespace eolymp
{
	public class ActivitatsView : TabbedPage
	{
		public ActivitatsView ()
		{
			Title = "ACTIVIDAD";
			var a = new ContentPage {
				Title = "MARCAS",
				Content = new Label {
						Text = " HOLA MARCAS",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
					},
			};
			var b = new ContentPage {
					Title = "ESTADÍSTICAS",
					Content = new Label {
						Text = " HOLA Estadisticas",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
					},
			};
			Children.Add (a);
			Children.Add (b);
		}
	}
}

