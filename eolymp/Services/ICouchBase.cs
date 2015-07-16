using System.Collections.Generic;


//Per tal de poder fer us d'una base de dades NoSQL, en aquest cas couchBase, 
//és necessari una interficie que sigui implementada per cada platadorma movil,
//ja que couchbase no esta integrat amb el PCL

namespace eolymp
{
	public interface ICouchBase
	{
		void crearDb ();
		string crearDoc(Dictionary<string,object> d);
		void /*Dictionary<string,object>*/ recuperarDoc (string docId);
		void modificarDoc (string docId);
		void eliminarDoc(string docId);

	}
}

