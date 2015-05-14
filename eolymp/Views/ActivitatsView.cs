using System;
using Xamarin.Forms;

namespace eolymp
{
	public class ActivitatsView : TabbedPage
	{
		private ActivitatsViewModel aVM;
		public ActivitatsView ()
		{
			aVM = new ActivitatsViewModel ();
			Title = "ACTIVIDAD";
			ListView l = new ListView ();
			StackLayout sL = new StackLayout();
			StackLayout sl2 = new StackLayout ();
			sl2.Orientation = StackOrientation.Horizontal;
			var picker = new Picker();
			picker.Title = "Modalitat Esportiva";
			picker.Items.Add ("Individual");
			picker.Items.Add ("Col·lectiva");
			picker.Items.Add ("Muntanya");
			picker.Items.Add ("Totes");
			Button button = new Button ();
			button.Text = "Buscar!";
			//l.ItemsSource = aVM.getMarques();
			l.ItemTemplate = new DataTemplate(typeof(marcaCell));
			sl2.Children.Add(picker);
			sl2.Children.Add(button);
			sL.Children.Add(sl2);
			sL.Children.Add(l);



			var a = new ContentPage {
				Title = "MARCAS",
				Content = sL
					
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
		private class marcaCell : ViewCell {
			public marcaCell(){
				var posicioL = new Label {HorizontalOptions = LayoutOptions.Fill};
				posicioL.SetBinding(Label.TextProperty,"posicio");

				var tOficialL = new Label {HorizontalOptions = LayoutOptions.Fill};
				tOficialL.SetBinding(Label.TextProperty,"tempsOficial");


				var ritmeL = new Label{HorizontalOptions = LayoutOptions.Fill};
				ritmeL.SetBinding(Label.TextProperty,"ritme");


				var k59L = new Label{HorizontalOptions = LayoutOptions.Fill};
				k59L.SetBinding(Label.TextProperty,"posicio");


				var k10L = new Label{HorizontalOptions = LayoutOptions.Fill};
				k10L.SetBinding(Label.TextProperty,"k1");
			

				var grid = new Grid();
				grid.RowDefinitions = new RowDefinitionCollection {
					new RowDefinition(),
					new RowDefinition()
				};
				grid.ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition(),
					new ColumnDefinition(),
					new ColumnDefinition()
				};
				grid.Children.Add(tOficialL,0,0);
				grid.Children.Add(ritmeL,1,0);
				grid.Children.Add(k59L,0,1);
				grid.Children.Add(k10L,1,1);
				grid.Children.Add(posicioL,0,2);
			}

		}
	}
}

