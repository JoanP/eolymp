using System;
using Xamarin;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;


namespace eolymp
{
	public class ActivitatsViewModel : ViewModelBase
	{
		private ObservableCollection<running> marques;

		public ActivitatsViewModel ()
		{
			marques = new ObservableCollection<running> ();
			//marques.CollectionChanged += marcaCollectionChanged;
			/*var a = new running ();
			var b = new running ();
			var c = new running ();
			a.id = 1;
			b.id = 2;
			c.id = 3;
			marques.Add (a);
			marques.Add (b);
			marques.Add (c);*/
			DependencyService.Get<ICouchBase> ().recuperarDoc ("1");


		}

		public ObservableCollection<running> getMarques(){
			return marques;
		}

		public void getInfoMarcas(int id){
			//App.MasterDetailPage.Detail.Navigation.PushAsync (new MarcasView ("Running"+" "+(id.ToString())));
			((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MarcasView ("Running"+" "+(id.ToString())));

		}

	}
}

