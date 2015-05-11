using System;


namespace eolymp
{
	public abstract class MarcaEsportiva
	{
		protected int id;
		protected DateTime diaMesAny;
		public MarcaEsportiva ()
		{
			id = -1;
			diaMesAny = new DateTime (0,0,0,0,0,0);
		}
	}
}

