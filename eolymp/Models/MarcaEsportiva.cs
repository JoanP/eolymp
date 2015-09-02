using System;
using Xamarin.Forms;


namespace eolymp
{
	public abstract class MarcaEsportiva : BindableObject
	{
		protected string _id;

		public string id {
			get { return _id; }
			set{ _id = value; }
		}
		//protected TimeSpan diaMesAny;
	

	}
}

