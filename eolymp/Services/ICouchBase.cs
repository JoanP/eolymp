using System.Collections.Generic;




namespace eolymp
{
	public interface ICouchBase
	{
		void crearDb ();
		string crearDoc(Dictionary<string,object> d);
		Dictionary<string,object> recuperarDoc (string docId);
		void modificarDoc (string docId);
		void eliminarDoc(string docId);

	}
}

