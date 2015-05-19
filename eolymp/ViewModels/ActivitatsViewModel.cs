using System;
using Xamarin;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace eolymp
{
	public class ActivitatsViewModel : ViewModelBase
	{
		private BindingList<running> marques;

		public ActivitatsViewModel ()
		{
			marques = new ObservableCollection<running> ();
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

		public ObservableCollection<running> getMarques(){
			return marques;
		}
	}
}

