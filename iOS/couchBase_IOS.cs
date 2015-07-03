using System;
using Xamarin.Forms;
using Couchbase.Lite;
using eolymp.iOS;
using System.Collections.Generic;

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
		public Dictionary<string,object> recuperarDoc (string docId){
			Document doc = db.GetDocument (docId);
			return new Dictionary<string, object> (doc.Properties);

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
