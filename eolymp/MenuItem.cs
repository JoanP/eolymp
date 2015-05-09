using System;

namespace eolymp
{
	public class MenuItem
	{
		public string Title { get; set;}
		public string IconSource { get; set;}
		public Type TargetType { get; set;}

		public MenuItem ()
		{	
			Title = "";
			IconSource = "";
		}
	}
}

