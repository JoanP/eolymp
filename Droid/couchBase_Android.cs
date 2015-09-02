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
				db = Manager.SharedInstance.GetDatabase ("AndroidBD");

			} catch (Exception e) {
				Log.Error ("AndroidBD", "Error getting database", e);
				return;
			}

		}
		public string crearDoc(Dictionary<string,object> d){
			Document doc = db.CreateDocument ();
			string docId = doc.Id;
			try{
				doc.PutProperties(d);
			}
			catch (Exception e) {
				Log.Error ("Error putting properties to Couchbase Lite database", e.Message);
			}
			return docId;
		}
		public ObservableCollection<Dictionary<string, object>> recuperarDocs (string esport, string user){
			Couchbase.Lite.View a = db.GetView ("running");
			a.SetMap((document, emit) =>
				{
					if((string)document ["esportista"] == user && (string)document ["tipus"] == esport) {
						emit ((string)document ["tipus"], document);
					}
				}, "1");
			return LogQueryResultsAsync (a);
		}

		private async ObservableCollection<Dictionary<string, object>> LogQueryResultsAsync (Couchbase.Lite.View cbView)
		{
			var orderedQuery = cbView.CreateQuery ();
			orderedQuery.Descending = true;
			var llista = new ObservableCollection<Dictionary<string, object>> ();
			try {
				var results = await orderedQuery.RunAsync ();
				results.ToList ().ForEach (result => {
					var doc = result.Document;
					var aux = new Dictionary<string, object>{
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
					llista.Add(aux);

				});
				return llista;
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
				//Log.Debug ("Updated Doc Properties:");
			} catch (CouchbaseLiteException e) {
				Log.Error ("Error updating properties in Couchbase Lite database", e.Message);
			}
		
		}
		public void eliminarDoc(string docId){
			try {
				var doc = db.GetDocument (docId);
				doc.Delete ();
			} catch (CouchbaseLiteException e) {
				Log.Error ("Cannot delete document", e.Message);
			}
		}



	}
}

