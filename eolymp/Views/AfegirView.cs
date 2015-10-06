using System;
using Xamarin.Forms;
//using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace eolymp
{
	public class AfegirView : ContentPage
	{

		public AfegirView ()
		{
			
			inicialitzarComponents ();
			BindingContext = new AfegirViewModel ();

		}
		public class CustomCell : ViewCell
		{
			private Entry e;
			private Label n;
			private Label lError;
			bool primer;
			public CustomCell (int type, string ph, string nn,string db){
				primer = true;
				e = new Entry{
					HorizontalOptions = LayoutOptions.Fill,
					WidthRequest = 125,
					Placeholder = ph,
				};
				e.TextChanged += (sender, e) => {
					if(primer) primer = false;
					else lError.TextColor = Color.Red;
					int restrictCount;
					if(type == 2) restrictCount = 8;
					else restrictCount = 20;
					Entry ent = sender as Entry;
					String val = ent.Text; //Get Current Text
					if(val != null){
						if(val.Length > restrictCount)//If it is more than your character restriction
						{
							val = val.Remove(val.Length - 1);// Remove Last character 
							ent.Text = val; //Set the Old value
						}
					}
				};
				lError = new Label{
					Text ="                    ",
					HorizontalOptions = LayoutOptions.End,
					TextColor = Color.Transparent,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					WidthRequest=60,
				};

				n = new Label{
					Text = nn,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					WidthRequest=100,
				};
				e.SetBinding(Entry.TextProperty, db);
				lError.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				var mainSL = new StackLayout();
				mainSL.Orientation = StackOrientation.Horizontal;
				mainSL.HorizontalOptions = LayoutOptions.FillAndExpand;
				mainSL.Children.Add(n);
				mainSL.Children.Add(e);
				mainSL.Children.Add(lError);
				mainSL.Padding = new Thickness(10,0,10,0);
				var noCharacters = new Setter {
					Property = Label.TextProperty,
					Value = "Introdueix un caràcter"
				};
				var noNumber = new Setter{
					Property = Label.TextProperty,
					Value = "Caracter invalid introduit"
				};
				var incorrectFormat = new Setter{
					Property = Label.TextProperty,
					Value = "Format incorrecte"
				};
				var clear = new Setter{
					Property = Label.TextProperty,
					Value = "                    "
				};
				var textIsEmpty = new DataTrigger(typeof(Label)){
					Binding = new Xamarin.Forms.Binding("Text.Length", source: e),
					Value = 0,
					Setters = {noCharacters},
				};
				var noIsNumber = new DataTrigger(typeof(Label)){
					Binding = new Xamarin.Forms.Binding("Text",BindingMode.Default,new comprovaSiEsNumero(), source: e),
					Value = false,
					Setters = {noNumber},
				};
				var isNumber = new DataTrigger(typeof(Label)){
					Binding = new Xamarin.Forms.Binding("Text",BindingMode.Default,new comprovaSiEsNumero(), source: e),
					Value = true,
					Setters = {clear},
				};
				var noFormatCrono = new DataTrigger(typeof(Label)){
					Binding = new Xamarin.Forms.Binding("Text",BindingMode.Default,new comprovaSiEsFormatCrono(), source: e),
					Value = false,
					Setters = {incorrectFormat},
				};
				var noFormatHora = new DataTrigger(typeof(Label)){
					Binding = new Xamarin.Forms.Binding("Text",BindingMode.Default,new comprovaSiEsCorrecte(), source: e),
					Value = false,
					Setters = {incorrectFormat},
				};
				lError.Triggers.Add(textIsEmpty);
				switch(type){
				case 1:
					lError.Triggers.Add(noIsNumber);
					lError.Triggers.Add(isNumber);
					break;
				case 2:
					lError.Triggers.Add(noFormatCrono);
					break;
				case 3:
					lError.Triggers.Add(noFormatHora);
					break;

				}



				View = mainSL;





			}
			/*public Entry getEntry(){
				return e;
			}*/
			public class comprovaSiEsNumero : IValueConverter
			{
				object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
				{
					throw new NotImplementedException ();
				}
				public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
				{
					var strng = value as string;
					if (strng != null) {
						char[] chars = strng.ToCharArray ();
						for (int i = 0; i < chars.Length; ++i) {
							if (chars [i] != '0' && chars [i] != '1' && chars [i] != '2' && chars [i] != '3' && chars [i] != '4' && chars [i] != '5' && chars [i] != '6' && chars [i] != '7' && chars [i] != '8' && chars [i] != '9') {
								return false;
							}
						}
						return true;
					}return true;
				}
			}

			public class comprovaSiEsCorrecte : IValueConverter
			{
				object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
				{
					throw new NotImplementedException ();
				}
				public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
				{
					var strng = value as string;
					if (strng != null) {
						char[] chars = strng.ToCharArray ();
						if (chars.Length == 0)
							return true;
						else if (chars.Length == 8) {
							if (chars [0] != '0' && chars [0] != '1' && chars [0] != '2' && chars [0] != '3' && chars [0] != '4' && chars [0] != '5' && chars [0] != '6' && chars [0] != '7' && chars [0] != '8' && chars [0] != '9')
								return false;
							if (chars [1] != '0' && chars [1] != '1' && chars [1] != '2' && chars [1] != '3' && chars [1] != '4' && chars [1] != '5' && chars [1] != '6' && chars [1] != '7' && chars [1] != '8' && chars [1] != '9')
								return false;
							if (chars [2] != ':')
								return false;
							if (chars [3] != '0' && chars [3] != '1' && chars [3] != '2' && chars [3] != '3' && chars [3] != '4' && chars [3] != '5' && chars [3] != '6' && chars [3] != '7' && chars [3] != '8' && chars [3] != '9')
								return false;
							if (chars [4] != '0' && chars [4] != '1' && chars [4] != '2' && chars [4] != '3' && chars [4] != '4' && chars [4] != '5' && chars [4] != '6' && chars [4] != '7' && chars [4] != '8' && chars [4] != '9')
								return false;
							if (chars [5] != ':')
								return false;
							if (chars [6] != '0' && chars [6] != '1' && chars [6] != '2' && chars [6] != '3' && chars [6] != '4' && chars [6] != '5' && chars [6] != '6' && chars [6] != '7' && chars [6] != '8' && chars [6] != '9')
								return false;
							if (chars [7] != '0' && chars [7] != '1' && chars [7] != '2' && chars [7] != '3' && chars [7] != '4' && chars [7] != '5' && chars [7] != '6' && chars [7] != '7' && chars [7] != '8' && chars [7] != '9')
								return false;
							else {
								string hores = chars [0].ToString () + chars [1].ToString ();
								string minuts = chars [3].ToString () + chars [4].ToString ();
								string segons = chars [6].ToString () + chars [7].ToString ();
								if (int.Parse (hores) > 23)
									return false;
								else if (int.Parse (minuts) > 59)
									return false;
								else if (int.Parse (segons) > 59)
									return false;
							}
						} else
							return false;
						}return true;
					}
			}

			public class comprovaSiEsFormatCrono : IValueConverter
			{
				object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
				{
					throw new NotImplementedException ();
				}
				public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
				{
					var strng = value as string;
					if (strng != null) {
						char[] chars = strng.ToCharArray ();
						if (chars.Length == 0)
							return true;
						else if (chars.Length == 8) {
							if (chars [0] != '0' && chars [0] != '1' && chars [0] != '2' && chars [0] != '3' && chars [0] != '4' && chars [0] != '5' && chars [0] != '6' && chars [0] != '7' && chars [0] != '8' && chars [0] != '9')
								return false;
							if (chars [1] != '0' && chars [1] != '1' && chars [1] != '2' && chars [1] != '3' && chars [1] != '4' && chars [1] != '5' && chars [1] != '6' && chars [1] != '7' && chars [1] != '8' && chars [1] != '9')
								return false;
							if (chars [2] != ':')
								return false;
							if (chars [3] != '0' && chars [3] != '1' && chars [3] != '2' && chars [3] != '3' && chars [3] != '4' && chars [3] != '5' && chars [3] != '6' && chars [3] != '7' && chars [3] != '8' && chars [3] != '9')
								return false;
							if (chars [4] != '0' && chars [4] != '1' && chars [4] != '2' && chars [4] != '3' && chars [4] != '4' && chars [4] != '5' && chars [4] != '6' && chars [4] != '7' && chars [4] != '8' && chars [4] != '9')
								return false;
							if (chars [5] != ':')
								return false;
							if (chars [6] != '0' && chars [6] != '1' && chars [6] != '2' && chars [6] != '3' && chars [6] != '4' && chars [6] != '5' && chars [6] != '6' && chars [6] != '7' && chars [6] != '8' && chars [6] != '9')
								return false;
							if (chars [7] != '0' && chars [7] != '1' && chars [7] != '2' && chars [7] != '3' && chars [7] != '4' && chars [7] != '5' && chars [7] != '6' && chars [7] != '7' && chars [7] != '8' && chars [7] != '9')
								return false;
						}
						else return false;
					}return true;
						
				}
			}
			public bool esValid2(){
				return lError.Text == "                    " ? true : false;
			}
			/*public bool esPrimerCop(){
				return (count == 0) ? true : false; 
			}*/
			public Label esCorrecte(){
				return lError;
			}
		}
		/*public class esCorrecte : IValueConverter
		{
			object IValueConverter.ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException ();
			}
			public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
			{
				var aux = value as CustomCell;
				var a = aux.esPrimerCop ();
				var b = aux.esValid2 ();
				if (aux.esPrimerCop ())return false;
				else {
					return aux.esValid2() ? true : false;
				}


			}
		}*/

		private void inicialitzarComponents(){

			var a = new CustomCell(0,"ex: Eolymp Run","Nom: ","nomCursa");
			var b = new CustomCell(1,"ex: 1","Dorsal: ","dorsal");
			var c = new CustomCell(1,"ex: 1","Posicio: ","posicio");
			var d = new CustomCell(1,"en km","Distancia: ","distancia");
			var ee = new CustomCell(1,"ex: 1","Posicio Categoria: ","posicioCategoria");
			var f = new CustomCell(0,"ex: Masculina","Categoria: ","categoria");
			var g = new CustomCell(0,"ex: Eolymp club","Club: ","club");
			var h = new CustomCell(2,"HH:MM:SS","Inici cursa: ","iniciCursa");
			var i = new CustomCell(3,"HH:MM:SS","Temps real: ","tempsReal");
			var j = new CustomCell(3,"HH:MM:SS","Temps oficial: ","tempsOficial");
			var k = new CustomCell(2,"HH:MM:SS","Inici real: ","iniciReal");
			var l = new CustomCell(2,"HH:MM:SS","Hora meta: ","horaMeta");
			var m = new CustomCell(3,"HH:MM:SS","Ritme: ","ritme");
			var n = new CustomCell(2,"HH:MM:SS","Temps Km5: ","km5");
			var o = new CustomCell(3,"HH:MM:SS","Hora Km 5: ","horaKm5");
			var p = new CustomCell(2,"HH:MM:SS","Temps Km 10: ","km10");
			var q = new CustomCell(3,"HH:MM:SS","Hora Km 10: ","horaKm10");
	
			var afageix = new Button{Text = "Afageix", IsEnabled = false};
			afageix.SetBinding (Button.CommandProperty, "Save");
			afageix.Clicked += (sender, e) => {
				DisplayAlert ("Guardada!", "La vostre marca ha estat guardada satisfactoriament", "D'acord");
				((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
			};
			/*var correcte = new Setter {
				Property = VisualElement.IsEnabledProperty,
				Value = true,
			};
			var incorrecte = new Setter {
				Property = Button.IsEnabledProperty,
				Value = false,
			};
	
			var totCorrecte = new MultiTrigger(typeof(Button)) {
				Conditions = {
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: a),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: b),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: c),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: d),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: ee),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: f),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: g),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: h),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: i),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: j),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: k),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: l),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: m),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: n),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: o),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: p),
						Value = true
					},
					new BindingCondition {
						Binding = new Binding(".",BindingMode.Default,new esCorrecte(), source: q),
						Value = true
					},
				},
				Setters = { correcte },
			};
*/
			var correcte = new Setter {
				Property = VisualElement.IsEnabledProperty,
				Value = true,
			};
			var totCorrecte = new MultiTrigger(typeof(Button)) {
				Conditions = {
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: a.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: b.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: c.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: d.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: ee.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: f.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: g.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: h.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: i.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: j.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: k.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: l.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: m.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: n.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: o.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: p.esCorrecte()),
						Value = "                    ",
					},
					new BindingCondition {
						Binding = new Binding(Label.TextProperty.PropertyName, source: q.esCorrecte()),
						Value = "                    ",
					},
				},
				Setters = { correcte },
			};
			afageix.Triggers.Add (totCorrecte);
			//afageix.Triggers.Add (totbuit);
			//afageix.Triggers.Add(multiFormatInvalid);
			//afageix.Triggers.Add (multiCaracterInvalid);

				var tabView = new TableView { 
				BackgroundColor = Color.Transparent,
				Intent = TableIntent.Form,
				Root = new TableRoot () {}
			};
			var aux = new TableSection ();
			aux.Add (a);
			aux.Add (f);
			aux.Add (g);
			aux.Add (b);
			aux.Add (c);
			aux.Add	(d);
			aux.Add (ee);
			aux.Add (m);
			aux.Add (h);
			aux.Add (i);
			aux.Add (j);
			aux.Add (k);
			aux.Add (l);
			aux.Add (n);
			aux.Add (o);
			aux.Add (p);
			aux.Add (q);
			tabView.Root.Add (aux);
			var sl = new StackLayout ();
			sl.Children.Add (tabView);
			sl.Children.Add (afageix);
			Content = sl;
		}
	}
}

