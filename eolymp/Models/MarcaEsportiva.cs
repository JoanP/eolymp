using System;


namespace eolymp
{
	public abstract class MarcaEsportiva
	{
		protected int id;
		//protected DateTime diaMesAny;
	
		public void setId(int i){
			id = i;
		}
		public int getId(){
			return id;
		}
	}
}

