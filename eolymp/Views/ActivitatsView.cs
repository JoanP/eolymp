using System;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Generic;

namespace eolymp
{
	public class ActivitatsView : TabbedPage
	{
		private ActivitatsViewModel aVM;
		Picker picker;

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
			Children[0].ToolbarItems.Add(new ToolbarItem {
				Text = "Add",
				Command = new Command(async o => {
					var item = await this.DisplayActionSheet("Afegeix una marca", "Cancel", null, "Individual", "Col·lectiva", "Muntanya");
					if (item != "Cancel"){
						//list.Add(item);
						if(item == "Individual"){
							picker.SelectedIndex = -1;
							((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AfegirView());
						}
						/*else if(item == "Col·lectiva"){
							((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new addPage("Col·lectiva"));

						}
						else{
							((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new addPage("Muntanya"));

						}*/
					}
				}),
			});

		}
			
		private class marcaCell : ViewCell{
			public static event Action<object> Remove = delegate {};
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
				deleteAction.Clicked += (sender, e) => Remove(sender);
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
				
				return "Ritme: " + value.ToString();
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
				return "Temps: " +value.ToString ();
			}
		}
		private StackLayout estructuraResultats() {
			ListView l = new ListView (){ 
				RowHeight = 70,
				BackgroundColor = Color.Gray.WithLuminosity (0.8),
				IsPullToRefreshEnabled = true
			};
			StackLayout sL = new StackLayout (){ Spacing = 20 };
			StackLayout sl2 = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 40,
				BackgroundColor = Color.White
			};
			picker = new Picker () {
				Title = "Esport",
				Items = {"Running"},
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Gray.WithLuminosity (0.9),
				WidthRequest = 100,
			};
			Label infoL = new Label {
				Text = "Selecciona l'esport: ",
				VerticalOptions = LayoutOptions.Center,
			};
			sl2.Padding = new Thickness (10, 0, 0, 0);
			sl2.Children.Add (infoL);
			sl2.Children.Add(picker);
			sL.Children.Add(sl2);
			sL.Children.Add (l);
			sL.Spacing = 5;
			sL.BackgroundColor = Color.Gray.WithLuminosity (0.8);

			l.Refreshing += (sender, e) => {
				l.ItemsSource = aVM.getRunningMarques ();
				l.EndRefresh();
			};	
				
			l.ItemTapped += (sender, e) => {
				var id = (e.Item as running).id;
				Dictionary<string,object> aux = new Dictionary<string,object>();
				aux.Add("nom",(e.Item as running).nom);
				aux.Add("club",(e.Item as running).club);
				aux.Add("categoria",(e.Item as running).categoria);
				aux.Add("distancia",(e.Item as running).distancia);
				aux.Add("dorsal",(e.Item as running).dorsal);
				aux.Add("horaMeta",(e.Item as running).horaMeta);
				aux.Add("iniciCursa",(e.Item as running).iniciCursa);
				aux.Add("iniciReal",(e.Item as running).iniciReal);
				aux.Add("k10",(e.Item as running).k10);
				aux.Add("k59",(e.Item as running).k59);
				aux.Add("modalitat",(e.Item as running).modalitat);
				aux.Add("posicio",(e.Item as running).posicio);
				aux.Add("posicioCategoria",(e.Item as running).posicioCategoria);
				aux.Add("ritme",(e.Item as running).ritme);
				aux.Add("tempsOficial",(e.Item as running).tempsOficial);
				aux.Add("tempsReal",(e.Item as running).tempsReal);
				aux.Add("h10",(e.Item as running).h10);
				aux.Add("h59",(e.Item as running).h59);	
				aux.Add("id",(e.Item as running).id);
				l.SelectedItem = null;
				aVM.getInfoMarcas (aux);

			};
			picker.SelectedIndexChanged += (sender, e) => {
				if(picker.SelectedIndex == -1){
					l.ItemsSource = null;
				}
				if (picker.SelectedIndex == 0) {
					l.ItemsSource = aVM.getRunningMarques();
					l.ItemTemplate = new DataTemplate (typeof(marcaCell));
				}
			};
			marcaCell.Remove += item => {
				var id = (item as MenuItem).CommandParameter;
				string id2 = id.ToString();
				aVM.deleteMarcaDB(id2);
				l.ItemsSource = aVM.getRunningMarques();

			};
			return(sL);
		}
	
		/*public class addPage : ContentPage
		{
			public addPage (string type)
			{
				Title = "Afegeix una marca";
				BackgroundColor = Color.Black.WithLuminosity (0.5);
				var lab = new Label { Text = "Sel·leciona:"};
				var pick = new Picker () {
					Title = "L'Esport",
					Items = {"Running","Cycling"},
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.Start,
					BackgroundColor = Color.Gray.WithLuminosity (0.9),
					WidthRequest = 100			

				};
				var aux = new StackLayout{
					Orientation = StackOrientation.Horizontal,
				};
				aux.Children.Add(lab);
				aux.Children.Add(pick);
				var mainstack = new StackLayout();
				mainstack.VerticalOptions = LayoutOptions.FillAndExpand;
				mainstack.HorizontalOptions = LayoutOptions.CenterAndExpand;
				mainstack.Children.Add(aux);
				pick.SelectedIndexChanged += (sender, e) => {
					if (pick.SelectedIndex == 0) {
						setUpGrid("Running",mainstack);
					}
				};
				Content = mainstack;


			}
			private void setUpGrid(string type,StackLayout mS){
				var grid = new Grid ();
				switch (type) {
				case "Running":
					if (mS.Children.Count > 1) {
						mS.Children.RemoveAt (1);
						mS.Children.RemoveAt (2);
					}
					grid.Children.Add (new Entry {Placeholder = "Nom Cursa"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Dorsal"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Posicio"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Distancia"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "PosicioCategoria"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Categoria"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Club"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Inici cursa(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Temps real(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Temps oficial(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Inici real(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Hora meta(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Ritme(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Km 5(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Hora km 5(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Km 10 l(HH:MM:SS)"}, 0, 0);
					grid.Children.Add (new Entry {Placeholder = "Hora km 10(HH:MM:SS)"}, 0, 0);
					mS.Children.Add (grid);

					break;
				}
				var afageix = new Button{Text = "Afageix"};
				afageix.Clicked += (object sender, EventArgs e) => {
					grid.Children[0].ge
				};
				mS.Children.Add (afageix);
			}

		}*/
	}
}



