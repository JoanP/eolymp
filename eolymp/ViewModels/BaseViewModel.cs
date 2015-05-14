using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace eolymp
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool SetProperty<T>(ref T storage, T value, 
			[CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;

			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	/*public class ViewModelBase : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
			RaisedPropertyChangedExplicit (propertyName);
		}
			
		void RaisedPropertyChangedExplicit(string propertyName){
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}
	}*/
}

