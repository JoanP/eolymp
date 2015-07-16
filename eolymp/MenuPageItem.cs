﻿using System;

namespace eolymp
{
	public class MenuPageItem
	{
		public string Title { get; set;}
		public string IconSource { get; set;}
		public Type TargetType { get; set;}

		public MenuPageItem ()
		{	
			Title = "";
			IconSource = "";
		}
	}
}

