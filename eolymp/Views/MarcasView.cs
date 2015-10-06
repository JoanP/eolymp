using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace eolymp
{
	public class MarcasView : ContentPage
	{
		private StackLayout mainStackL;


		public MarcasView (string name,Dictionary<string,object> info)
		{
			Title = name;
			mainStackL = new StackLayout ();
			mainStackL.Spacing = 0;
			ToolbarItems.Add(new ToolbarItem {
				Text = "Modifica",
				Command = new Command(async o => {
					((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ModificarView(info));
				}),
			});
			var picture = new Image () {
				Aspect = Aspect.AspectFill,
				Source = ImageSource.FromFile("marcasmainfoto.jpg")
			};
			Device.OnPlatform (iOS: () => {
				picture.HeightRequest = 150;
			});

			Grid structInfo = new Grid {
				//HeightRequest = 70,
				Padding = new Thickness(5,10,0,0),
				RowSpacing = 8,
				ColumnSpacing = 5,
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
					new RowDefinition (),
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					//new ColumnDefinition{ Width = new GridLength(70) },
					new ColumnDefinition (),
					new ColumnDefinition ()
					//new ColumnDefinition{ Width = new GridLength(50) },
				},
			};
			Label nom = new Label{ Text = info ["nom"].ToString(),
				BackgroundColor = Color.Black.WithLuminosity (0.2),
				TextColor = Color.White,
			HorizontalOptions = LayoutOptions.Fill};
			Label cat = new Label{ Text = "Categoria: "+ info ["categoria"].ToString()};
			Label dist = new Label{ Text ="Distancia: "+info ["distancia"].ToString()+" Km"};
			Label club = new Label{ Text = "Club: "+info ["club"].ToString()};
			Label dor = new Label{ Text = "Dorsal: "+info ["dorsal"].ToString()};
			Label hm = new Label{ Text = "Hora Meta: "+info ["horaMeta"].ToString()};
			Label iniciCursa = new Label{ Text ="Inici Cursa: "+ info ["iniciCursa"].ToString()};
			Label iniciReal = new Label{ Text = "IniciReal: "+info ["iniciReal"].ToString()};
			Label k10 = new Label{ Text = "kilometre 10: "+info ["k10"].ToString()};
			Label k59 = new Label{ Text = "kilometre 5: "+info ["k59"].ToString()};
			Label mod = new Label{ Text = "Modalitat: "+info ["modalitat"].ToString()};
			Label pos = new Label{ Text = "Posicio: "+info ["posicio"].ToString()};
			Label posc = new Label{ Text = "Posicio Categoria: "+info ["posicioCategoria"].ToString()};
			Label rit = new Label{ Text = "Ritme: "+info ["ritme"].ToString()};
			Label tO = new Label{ Text = "Temps Oficial: "+info ["tempsOficial"].ToString()};
			Label tR = new Label{ Text = "Temps Real: "+info ["tempsReal"].ToString()};
			Label h10 = new Label{ Text = "Hora km 10: "+info ["h10"].ToString()};
			Label h59 = new Label{ Text = "Hora km 5: "+info ["h59"].ToString()};

			nom.FontAttributes = FontAttributes.Bold;
			Device.OnPlatform (iOS: () => {
				nom.FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label));
				cat.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				dist.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				club.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				dor.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				hm.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				iniciCursa.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				iniciReal.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				k10.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				k59.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				mod.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				pos.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				posc.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				rit.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				tO.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				tR.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				h10.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				h59.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			});
			Device.OnPlatform (Android: () => {
				nom.FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label));
				cat.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				dist.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				club.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				dor.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				hm.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				iniciCursa.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				iniciReal.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				k10.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				k59.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				mod.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				pos.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				posc.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				rit.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				tO.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				tR.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				h10.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				h59.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
			});




			structInfo.Children.Add (dist, 0,0);
			structInfo.Children.Add (pos, 0,1);
			structInfo.Children.Add (tO, 0,2);
			structInfo.Children.Add (tR, 0,3);
			structInfo.Children.Add (rit, 0,4);
			structInfo.Children.Add (hm, 0,5);
			structInfo.Children.Add (posc, 0,6);
			structInfo.Children.Add (club, 0,7);
			structInfo.Children.Add (dor, 0,8);
			structInfo.Children.Add (iniciCursa, 1,0);
			structInfo.Children.Add (iniciReal, 1,1);
			structInfo.Children.Add (k10, 1,2);
			structInfo.Children.Add (k59, 1,3);
			structInfo.Children.Add (h10, 1,4);
			structInfo.Children.Add (h59, 1,5);
			structInfo.Children.Add (cat, 1,6);
			structInfo.Children.Add (mod, 1,7);


			mainStackL.Children.Add (picture);
			mainStackL.Children.Add (nom);
			mainStackL.Children.Add (structInfo);
			Content = mainStackL;
		}
	}
}

