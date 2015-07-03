using System;
using Xamarin.Forms;


namespace eolymp
{
	public abstract class MarcaEsportiva : BindableObject
	{
		protected int _id;

		public int id {
			get { return _id; }
			set{ _id = value; }
		}
		//protected TimeSpan diaMesAny;
	

	}
}

