using System;
using Xamarin.Forms;
using Couchbase.Lite;
using eolymp.iOS;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite.Util;

[assembly: Dependency (typeof (couchBase_IOS))]

namespace eolymp.iOS
{
	public class couchBase_IOS : ICouchBase
	{
		Database db;
		public couchBase_IOS ()
		{
		}
		public void crearDb(){
			try{
				db = Manager.SharedInstance.GetDatabase ("iosdb");
				/*var a = new Dictionary<string, object>{
					{"nomCursa", "Cursa Peiro"},
					{"dorsal", 9},
					{"posicio",9},
					{"distancia", 10},
					{"posicioCategoria",9},
					{"categoria", "Masculina"},
					{"club", "Cap gros"},
					{"iniciCursa","0000:0000"},
					{"tempsReal", "0000:0000"},
					{"tempsOficial", "0000:0000"},
					{"iniciReal", "0000:0000"},
					{"horaMeta", "0000:0000"},
					{"ritme","0000:0000"},
					{"km5","0000:0000"},
					{"horaKm5","0000:0000"},
					{"km10","0000:0000"},
					{"horaKm10", "0000:0000"},
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
		public void /*Dictionary<string,object>*/ recuperarDoc (string docId){
			/*Document doc = db.GetDocument (docId);
			return new Dictionary<string, object> (doc.Properties);*/
			Couchbase.Lite.View a = db.GetView ("running");
			//a.SetMap((document, emit) => emit ((string)document ["nomCursa"], document), "1");
			a.SetMap((document, emit) =>
			{
				if((string)document ["esportista"] == "Marta" && (string)document ["tipus"] == "running") {
					emit ((string)document ["nomCursa"], document);
				}
			}, "1");
			LogQueryResultsAsync (a);

			var b = a.TotalRows;

			/*var liveQuery = a.CreateQuery ().ToLiveQuery ();
			liveQuery.Run ();
			Console.WriteLine ("2");
			var b = a.TotalRows;
			Console.WriteLine (b);*/



		}
		async void LogQueryResultsAsync (Couchbase.Lite.View cbView)
		{
			var orderedQuery = cbView.CreateQuery ();
			orderedQuery.Descending = true;
			orderedQuery.Limit = 20;
			try {
				var results = await orderedQuery.RunAsync ();
				results.ToList ().ForEach (result => {
					Console.WriteLine ("2");
					var doc = result.Document;
					Console.WriteLine ("Found document with id: {0}, Esportista = {1}", 
						result.DocumentId, doc.GetProperty<string>("esportista"));
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
	}
}
