using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace eolymp
{
	public class BaseViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
			RaisedPropertyChangedExplicit (propertyName);
		}
			
		void RaisePropertyChangedExplicit(string propertyName){
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}
	}
}

