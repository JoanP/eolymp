using System;
using Xamarin.Forms;
using eolymp.Droid;
using Couchbase.Lite;
using Android.Util;
using System.Collections.Generic;

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

