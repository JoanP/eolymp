using System;
using Xamarin;
using System.Collections.Generic;

namespace eolymp
{
	public class ActivitatsViewModel : ViewModelBase
	{
		private List<running> marques;

		public ActivitatsViewModel ()
		{
			marques = new List<running> ();
			var a = new running ();
			var b = new running ();
			var c = new running ();
			a.id=1;
			b.id = 2;
			c.id = 3;
			marques.Add (a);
			marques.Add (b);
			marques.Add (c);
		}

		public List<running> getMarques(){
			return marques;
		}
	}
}

