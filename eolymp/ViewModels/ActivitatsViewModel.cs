using System;
using Xamarin;
using System.Collections.Generic;

namespace eolymp
{
	public class ActivitatsViewModel : ViewModelBase
	{
		private listRunning marques;
		public ActivitatsViewModel ()
		{
			this.marques = new listRunning();


		}
		/*public List<running> getMarques(){
			return marques;
		}*/
		private class listRunning : List<string>{

			public listRunning() {
				var a = new running ();
				var b = new running ();
				var c = new running ();
				a.setId (1);
				b.setId (2);
				c.setId (3);
				/*this.Add (a);
				this.Add (b);
				this.Add (c);*/
			}
		}
	}
}

