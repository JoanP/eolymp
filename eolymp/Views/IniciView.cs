using System;
using Xamarin.Forms;

namespace eolymp
{
	public class IniciView : ContentPage
	{
		public IniciView ()
		{
			Title = "Inici";
			var sL = new StackLayout();
			sL.BackgroundColor = Color.White;
			var eolymp = new Image () {
				Aspect = Aspect.AspectFill,
				Source = ImageSource.FromFile ("eolymp1.jpg"),
				HeightRequest = 100,
			};
			var wv = new WebView {
				Source = new UrlWebViewSource
				{
					Url = "https://www.youtube.com/watch?v=69Phpz8yXOg",
				},
				VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 215,
			};
			var linkweb = new Button {
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Transparent,
				Text = "Visita la nostra web!",
				TextColor = Color.Blue,

			};
			linkweb.Clicked += (sender, e) => {
				Device.OpenUri (new Uri ("http://www.championchip.cat/web/"));
			};
			var tutorial = new Button {
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Black,
				Text = "Perdut amb l'aplicació? Segueix el tutorial",
				TextColor = Color.Blue,
				WidthRequest = 100,
			};
			var footer = new StackLayout {
				BackgroundColor = Color.Black.AddLuminosity (0.2),
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Thickness(0,25,0,0),
				HeightRequest = 30,
			};
			var xxss = new Image () {
				//Aspect = Aspect.AspectFill,
				WidthRequest = 300,
				Source = ImageSource.FromFile ("footer.png")
			};
			Device.OnPlatform (iOS: () => {
				tutorial.HeightRequest = 30;
				linkweb.HeightRequest = 30;

			});
			Device.OnPlatform (Android: () => {
				tutorial.HeightRequest = 35;
				linkweb.HeightRequest = 35;

			});
			footer.Children.Add (xxss);
			footer.Children [0].HorizontalOptions = LayoutOptions.Center;
			sL.Children.Add (eolymp);
			sL.Children.Add (tutorial);
			sL.Children.Add (linkweb);
			sL.Children.Add (wv);
			sL.Children.Add(footer);

			Content = sL;
		
		}
	}
}

