using System;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace eolymp
{
	public class ActivitatsView : TabbedPage
	{
		private ActivitatsViewModel aVM;


		public ActivitatsView ()
		{
			aVM = new ActivitatsViewModel ();
			Title = "Competeix";
			var resultats = new ContentPage {
				Title = "Resultats",
				Icon = "resultats.png",
				Content = estructuraResultats()
					
			};
			var reptes = new ContentPage {
					Title = "Reptes",
					Icon = "target21.png"
			};
			var premium = new ContentPage {
				Title = "Premium",
				Icon = "premium.png"
			};
			Children.Add (resultats);
			Children.Add (reptes);
			Children.Add (premium);

		}
		
		private class marcaCell : ViewCell{
			public static event Action<int> Remove = delegate {};

			public marcaCell(){
				var i = new Image {
					Aspect = Aspect.AspectFit,
					HorizontalOptions = LayoutOptions.Center
				};
				i.Source = ImageSource.FromFile("running.png");
				var nomL = new Label {
					HorizontalOptions = LayoutOptions.Fill,
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					FontAttributes = FontAttributes.Bold
				};
				nomL.SetBinding(Label.TextProperty, "nom");

				var tOficialL = new Label {
					HorizontalOptions = LayoutOptions.Fill,
					FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
				};
				tOficialL.SetBinding(Label.TextProperty,new Binding("tempsOficial", BindingMode.Default,new tOficialConverter(), null));

				var ritmeL = new Label{
					HorizontalOptions = LayoutOptions.Fill,
					FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
				};
				ritmeL.SetBinding(Label.TextProperty,new Binding("ritme", BindingMode.Default,new ritmeConverter(), null));

				var distanciaL = new Label{
					HorizontalOptions = LayoutOptions.Fill,
					FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
				};
				distanciaL.SetBinding(Label.TextProperty,new Binding("distancia", BindingMode.Default,new distanciaConverter(), null));

				var sl = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Spacing = 20,
				};
				var sl2 = new StackLayout {
					Spacing = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};
				/*var delete = new Button {
					Image = "delete.png",
					HorizontalOptions = LayoutOptions.FillAndExpand
				};
				delete.SetBinding(Button.ClassIdProperty,"id");*/

				sl2.Children.Add(nomL);
				sl2.Children.Add(distanciaL);
				sl2.Children.Add(tOficialL);
				sl2.Children.Add(ritmeL);

				sl.Children.Add(i);
				sl.Children.Add(sl2);
				//sl.Children.Add(delete);

				var deleteAction = new MenuItem{Text = "Delete",IsDestructive = true};
				deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("id"));
				deleteAction.Clicked += (sender, e) => Remove((int)(sender as MenuItem).CommandParameter);
				ContextActions.Add(deleteAction);




				View = sl;
				View.BackgroundColor = Color.White;

			}
		}
		public class ritmeConverter : IValueConverter
		{
			object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException ();
			}

			public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
			{
				TimeSpan span = (TimeSpan)value;
				return "Ritme: " + span.ToString ();
			}
		}
		public class distanciaConverter : IValueConverter
		{
			object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException ();
			}

			public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
			{
				var dis = (int) value;
				return "Distancia: " + dis.ToString();
			}
		}

		public class tOficialConverter : IValueConverter
		{
			object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException ();
			}

			public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
			{
				TimeSpan span = (TimeSpan)value;
				return "Temps: " + span.ToString ();
			}
		}
		private StackLayout estructuraResultats() {

			var lO = aVM.getMarques ();
			ListView l = new ListView (){ 
				RowHeight = 70,
				BackgroundColor = Color.Gray.WithLuminosity (0.8)
			};
			StackLayout sL = new StackLayout (){ Spacing = 20 };
			StackLayout sl2 = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 20,
			};
			var picker = new Picker () {
				Title = "Esport",
				Items = {"Running"},
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Gray.WithLuminosity (0.9),
				WidthRequest = 100,
			};
			Button button = new Button () {
				Image = "add.png",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.EndAndExpand,
			};
			sl2.Children.Add(picker);
			sl2.Children.Add(button);
			sL.Children.Add(sl2);
			sL.Children.Add (l);

			l.ItemTapped += (sender, e) => {
				var id = (e.Item as running).id;
				l.SelectedItem = null;
				aVM.getInfoMarcas (id);

			};
			picker.SelectedIndexChanged += (sender, e) => {
				if (picker.SelectedIndex == 0) {
					l.ItemsSource = lO;
					l.ItemTemplate = new DataTemplate (typeof(marcaCell));
				}
			};
			marcaCell.Remove += item => {
				//lO.Remove (new running (item));
				//foreach(running r in lO){
				lO.RemoveAt(0);
				//}
			};

			return(sL);
		}
	}
}



