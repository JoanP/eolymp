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
			marques = new ObservableCollection<running>();
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



		}

		public ObservableCollection<running> getMarques(){
			return marques;
		}

		public void getInfoMarcas(){
			//App.MasterDetailPage.Detail.Navigation.PushAsync (new MarcasView ("Running"+" "+(id.ToString())));
			((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MarcasView ("Running"));

		}
		public ObservableCollection<running> getRunningMarques(){
			var aux = new ObservableCollection<running> ();
			var _marques = DependencyService.Get<ICouchBase> ().recuperarDocs ("running","Didac");
			foreach(Dictionary<string,string> marca in _marques){
				var r = new running ();
				foreach (KeyValuePair<string, string> kv in marca) {
					switch (kv.Key) {
						case "id":
							r.id = kv.Value;
							break;
						case "nomCursa":
							r.nom = kv.Value;
							break;
						case "dorsal":
							r.dorsal = int.Parse(kv.Value);
							break;

						case "posicio":
							r.posicio = int.Parse(kv.Value);
							break;
						case "distancia":
							r.distancia = int.Parse(kv.Value);
							break;
						case "posicioCategoria":
							r.posicioCategoria = int.Parse (kv.Value);
							break;
						case "categoria":
							r.categoria = kv.Value;
							break;
						case "club":
							r.club = kv.Value;
							break;
						case "iniciCursa":
							r.iniciCursa = stringTimeSpanConverter(kv.Value);
							break;
						case "tempsReal":
							r.tempsReal = stringTimeSpanConverter (kv.Value);
							break;
						case "tempsOficial":
							r.tempsOficial = stringTimeSpanConverter (kv.Value);
							break;
						case "iniciReal":
							r.iniciReal = stringTimeSpanConverter (kv.Value);
							break;
						case "horaMeta":
							r.horaMeta = stringTimeSpanConverter (kv.Value);
							break;
						case "ritme":
							r.ritme = stringTimeSpanConverter (kv.Value);
							break;
						case "km5":
							r.k59 = stringTimeSpanConverter (kv.Value);
							break;
						case "km10":
							r.k10 = stringTimeSpanConverter (kv.Value);
							break;

					}
				}
				r.modalitat = "individual";
				aux.Add (r);
			}
			return aux;
		}
		private TimeSpan stringTimeSpanConverter(string time){
			char[] delimiters = { ':' };
			string[] times = time.Split (delimiters);
			var ts = new TimeSpan(int.Parse(times[0]),int.Parse(times[1]),int.Parse(times[2]));
			return ts;
		}
		public void deleteMarcaDB(string id){
			DependencyService.Get<ICouchBase> ().eliminarDoc(id);
		}
		/*public ObservableCollection<running> deleteMarca(string Id){
			foreach(running marca in marques)
			{
				if(marca.id == Id)marques.Remove(marca);
			}
			return marques;
		}*/

	}
}

