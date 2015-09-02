using System.Collections.Generic;


//Per tal de poder fer us d'una base de dades NoSQL, en aquest cas couchBase, 
//és necessari una interficie que sigui implementada per cada platadorma movil,
//ja que couchbase no esta integrat amb el PCL
using System.Collections.ObjectModel;

namespace eolymp
{
	public interface ICouchBase
	{
		void crearDb ();
		string crearDoc(Dictionary<string,object> d);
		ObservableCollection<Dictionary<string, string>> recuperarDocs (string esport, string user);
		void modificarDoc (string docId);
		void eliminarDoc(string docId);
	}
}

