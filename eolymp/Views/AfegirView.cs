using System;
using Xamarin.Forms;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Diagnostics;

namespace eolymp
{
	public class AfegirView : ContentPage
	{

		public AfegirView ()
		{
			
			inicialitzarComponents ();
			BindingContext = new AfegirViewModel ();

		}
		private void inicialitzarComponents(){

			var a = new EntryCell {Label="Nom cursa:",Placeholder = "ex: Eolymp Run"};
			var b = new EntryCell {Label ="Dorsal:",Placeholder = "ex: 1"};
			var c = new EntryCell {Label ="Posicio:",Placeholder = "ex: 1"};
			var d = new EntryCell {Label ="Distancia:",Placeholder = "en km"};
			var ee = new EntryCell {Label = "Posicio Categoria:",Placeholder = "ex: 1"};
			var	f = new EntryCell {Label = "Categoria:",Placeholder = "ex: Masculina"};
			var	g = new EntryCell {Label = "Club:",Placeholder = "ex: Eolymp club"};
			var	h = new EntryCell {Label = "Inici cursa:",Placeholder = "HH:MM:SS"};
			var	i = new EntryCell {Label = "Temps real:",Placeholder = "HH:MM:SS"};
			var	j = new EntryCell {Label = "Temps oficial:",Placeholder = "HH:MM:SS"};
			var	k = new EntryCell {Label = "Inici real:",Placeholder = "HH:MM:SS"};
			var	l = new EntryCell {Label = "Hora meta:",Placeholder = "HH:MM:SS"};
			var	m = new EntryCell {Label = "Ritme:",Placeholder = "HH:MM:SS"};
			var	n = new EntryCell {Label = "Temps Km5:",Placeholder = "HH:MM:SS"};
			var	o = new EntryCell {Label = "Hora km5:",Placeholder = "HH:MM:SS"};
			var	p = new EntryCell {Label = "Temps Km10:",Placeholder = "HH:MM:SS"};
			var	q = new EntryCell {Label = "Hora Km10:",Placeholder = "HH:MM:SS"};
			var afageix = new Button{Text = "Afageix"};


			a.SetBinding(EntryCell.TextProperty, "nomCursa");
			b.SetBinding(EntryCell.TextProperty, "dorsal");
			c.SetBinding(EntryCell.TextProperty, "posicio");
			d.SetBinding(EntryCell.TextProperty, "distancia");
			ee.SetBinding(EntryCell.TextProperty, "posicioCategoria");
			f.SetBinding(EntryCell.TextProperty, "categoria");
			g.SetBinding(EntryCell.TextProperty, "club");
			h.SetBinding(EntryCell.TextProperty, "iniciCursa");
			i.SetBinding(EntryCell.TextProperty, "tempsReal");
			j.SetBinding(EntryCell.TextProperty, "tempsOficial");
			k.SetBinding(EntryCell.TextProperty, "iniciReal");
			l.SetBinding(EntryCell.TextProperty, "horaMeta");
			m.SetBinding(EntryCell.TextProperty, "ritme");
			n.SetBinding(EntryCell.TextProperty, "km5");
			o.SetBinding(EntryCell.TextProperty, "horaKm5");
			p.SetBinding(EntryCell.TextProperty, "km10");
			q.SetBinding(EntryCell.TextProperty, "horaKm10");
			afageix.SetBinding (Button.CommandProperty, "Save");
			afageix.Clicked += (sender, e) => {
				DisplayAlert ("Guardada!", "La vostre marca ha estat guardada satisfactoriament", "D'acord");
				((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
			};


			
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

