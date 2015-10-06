using System;
using Xamarin.Forms;
using eolymp.Droid;
using Couchbase.Lite;
using Android.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

[assembly: Dependency (typeof(couchBase_Android))]

namespace eolymp.Droid
{
	public class couchBase_Android : Java.Lang.Object, ICouchBase
	{
		Database db;
		public couchBase_Android ()
		{
		}
		public void crearDb ()
		{
			try {
				
				db = Manager.SharedInstance.GetDatabase("iosdb");
				//db.Delete();
				var a = new Dictionary<string, object>{
					{"nomCursa", "Cursa Peiro"},
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
					{"esportista", "Didac"}
				};
				var b = crearDoc(a);
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
			Couchbase.Lite.View a = db.GetView ("running2");
			a.SetMap((document, emit) =>
				{
					if((string)document ["esportista"] == user && (string)document ["tipus"] == esport) {
						emit ((string)document ["tipus"], document);
					}
				}, "1");
			LogQueryResultsAsync (a);
			return LogQueryResultsAsync (a);

		}

		private /*async*/ ObservableCollection<Dictionary<string, string>> LogQueryResultsAsync (Couchbase.Lite.View cbView)
		{
			var orderedQuery = cbView.CreateQuery ();
			orderedQuery.Descending = true;
			var llista = new ObservableCollection<Dictionary<string, string>>();
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
					var c = db.DocumentCount;
					Console.WriteLine ("num DESPUES DE QUERY: " + c);
					llista.Add(aux);


				});
				cbView.DeleteIndex ();
				Console.WriteLine ("Num en la query: "+llista.Count);

			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Error querying view", e.Message);
			}
			return llista;
		}

		public void modificarDoc (string docId,Dictionary<string, object> info){
			var doc = db.GetDocument (docId);
			try {
				// Update the document with more data
				var updatedProps = doc.Properties;
				updatedProps["nomCursa"] = info["nomCursa"].ToString();
				updatedProps["dorsal"] = info["dorsal"].ToString();
				updatedProps["posicio"] = info ["posicio"].ToString();
				updatedProps["distancia"] = info["distancia"].ToString();
				updatedProps["posicioCategoria"] = info["posicioCategoria"].ToString();
				updatedProps["categoria"] = info["categoria"].ToString();
				updatedProps["club"] = info["club"].ToString();
				updatedProps["iniciCursa"] = info["iniciCursa"].ToString();
				updatedProps["tempsReal"] = info["tempsReal"].ToString();
				updatedProps["tempsOficial"] = info["tempsOficial"].ToString();
				updatedProps["iniciReal"] = info["iniciReal"].ToString();
				updatedProps["horaMeta"] = info["horaMeta"].ToString();
				updatedProps["ritme"] = info["ritme"].ToString();
				updatedProps["km5"] = info["km5"].ToString();
				updatedProps["horaKm5"] = info["horaKm5"].ToString();
				updatedProps["km10"] = info["km10"].ToString();
				updatedProps["horaKm10"] = info["horaKm10"].ToString();
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
				var c = db.DocumentCount;
				Console.WriteLine ("num: " + c);
			} catch (CouchbaseLiteException e) {
				Console.WriteLine ("Cannot delete document", e.Message);
			}
		}


	}
}

