using System;
using Xamarin.Forms;
using Couchbase.Lite;
using eolymp.iOS;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite.Util;
using System.Collections.ObjectModel;

[assembly: Dependency (typeof (couchBase_IOS))]

namespace eolymp.iOS
{
	public class couchBase_IOS : ICouchBase
	{
		Database db;
		ObservableCollection<Dictionary<string, string>> llista;
		public couchBase_IOS ()
		{
		}
		public void crearDb(){
			try{
				db = Manager.SharedInstance.GetDatabase ("iosdb");
				llista = new ObservableCollection<Dictionary<string, string>>();
				//db.Delete();
				/*var a = new Dictionary<string, object>{
					/*{"nomCursa", "Cursa Peiro"},
					{"dorsal", "9"},
					{"posicio","9"},
					{"distancia", "10"},
					{"posicioCategoria","9"},
					{"categoria", "Masculina"},
					{"club", "Cap gros"},
					{"iniciCursa","00:00:00"},
					{"tempsReal", "00:00:00"},
					{"tempsOficial", "00:00:00"},
					{"iniciReal", "00:00:00"},
					{"horaMeta", "00:00:00"},
					{"ritme","00:00:00"},
					{"km5","00:00:00"},
					{"horaKm5","00:00:00"},
					{"km10","00:00:00"},
					{"horaKm10", "00:00:00"},
					{"tipus", "running"},
					{"esportista", "Peiro"}
				};
				var b = crearDoc(a);*/
				var c = db.DocumentCount;
				Console.WriteLine ("num: " + c);
			}
			catch (Exception e){
				Console.WriteLine ("{0}: Error getting database: {1}","CouchbaseEventsApp", e.Message);
			}
		}

		public string crearDoc(Dictionary<string,object> d){
			Document doc = db.CreateDocument ();
			string docId = doc.Id;
			try{
				doc.PutProperties(d);
			}
			catch (Exception e) {
				Console.WriteLine ("Error putting properties to Couchbase Lite database", e.Message);
			}
			return docId;
		}

		public ObservableCollection<Dictionary<string, string>> recuperarDocs (string esport, string user){
			Couchbase.Lite.View a = db.GetView ("running");
			a.SetMap((document, emit) =>
			{
				if((string)document ["esportista"] == user && (string)document ["tipus"] == esport) {
					emit ((string)document ["tipus"], document);
				}
			}, "1");
			LogQueryResultsAsync (a);
			//getData(a);
			Console.WriteLine ("Num: "+llista.Count); 
			return llista;
		}

		private /*async*/ void LogQueryResultsAsync (Couchbase.Lite.View cbView)
		{
			var orderedQuery = cbView.CreateQuery ();
			orderedQuery.Descending = true;
			try {
				//var results = await orderedQuery.RunAsync ();
				var results = orderedQuery.Run();
				Console.WriteLine ("Found rows: {0}", 
					results.Count);
				results.ToList ().ForEach (result => {
					var doc = result.Document;
					Dictionary<string, string> aux = new Dictionary<string, string>{
						{"id", result.DocumentId},
						{"nomCursa", doc.GetProperty<string>("nomCursa")},
						{"dorsal", doc.GetProperty<string>("dorsal")},
						{"posicio", doc.GetProperty<string>("posicio")},
						{"distancia", doc.GetProperty<string>("distancia")},
						{"posicioCategoria",doc.GetProperty<string>("posicioCategoria")},
						{"categoria", doc.GetProperty<string>("categoria")},
						{"club", doc.GetProperty<string>("club")},
						{"iniciCursa",doc.GetProperty<string>("iniciCursa")},
						{"tempsReal", doc.GetProperty<string>("tempsReal")},
						{"tempsOficial", doc.GetProperty<string>("tempsOficial")},
						{"iniciReal", doc.GetProperty<string>("iniciReal")},
						{"horaMeta", doc.GetProperty<string>("horaMeta")},
						{"ritme",doc.GetProperty<string>("ritme")},
						{"km5",doc.GetProperty<string>("km5")},
						{"horaKm5",doc.GetProperty<string>("horaKm5")},
						{"km10",doc.GetProperty<string>("km10")},
						{"horaKm10", doc.GetProperty<string>("horaKm10")},
						{"tipus", doc.GetProperty<string>("tipus")},
						{"esportista", doc.GetProperty<string>("esportista")}

					};
					Console.WriteLine ("Found document with id: {0}", 
						result.DocumentId);
					llista.Add(aux);

				});
			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Error querying view", e.Message);
			}
		}

		public void modificarDoc (string docId){
			var doc = db.GetDocument (docId);
			try {
				// Update the document with more data
				var updatedProps = new Dictionary<string, object> (doc.Properties);
				updatedProps.Add ("eventDescription", "Everyone is invited!");
				updatedProps.Add ("address", "123 Elm St.");
				// Save to the Couchbase local Couchbase Lite DB
				doc.PutProperties (updatedProps);
				// display the updated document
				Console.WriteLine ("Updated Doc Properties:");
			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Error updating properties in Couchbase Lite database", e.Message);
			}

		}
		public void eliminarDoc(string docId){
			try {
				var doc = db.GetDocument (docId);
				doc.Delete ();
			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Cannot delete document", e.Message);
			}
		}

		/*async void getData (Couchbase.Lite.View cbView)
		{
			var orderedQuery = cbView.CreateQuery ();
			orderedQuery.Descending = true;
			orderedQuery.Limit = 20;

			try {
				var results = await orderedQuery.RunAsync ();
				results.ToList ().ForEach (result => {
					var doc = result.Document;
					Console.WriteLine ("Found document with id: {0}, Esportista = {1}", 
						result.DocumentId, doc.GetProperty<string>("esportista"));
				});
			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Error querying view", e.Message);
			}
		}*/
	}
}
