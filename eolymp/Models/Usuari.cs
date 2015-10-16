using System;

namespace eolymp
{
	public class Usuari
	{
		private int _id;
		private string _nom;
		private string _primerCognom;
		private string _segonCognom;
		private string _token;
		private string _correu;

		public int id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}

		public string nom {
			get {
				return _nom;
			}
			set {
				_nom = value;
			}
		}

		public string primerCognom {
			get {
				return _primerCognom;
			}
			set {
				_primerCognom = value;
			}
		}

		public string segonCognom {
			get {
				return _segonCognom;
			}
			set {
				_segonCognom = value;
			}
		}

		public string token {
			get {
				return _token;
			}
			set {
				_token = value;
			}
		}

		public string correu {
			get {
				return _correu;
			}
			set {
				_correu = value;
			}
		}

		public Usuari ()
		{
			id = -1;
			nom = "";
			primerCognom = "";
			segonCognom = "";
			token = "";
			correu = "";
		}

		/*public int getID (){
			return id;
		}
		public string getNom (){
			return nom;
		}
		public string getPrimerCognom (){
			return primerCognom;
		}
		public string getSegonCognom (){
			return segonCognom;
		}
		public string getToken (){
			return token;
		}
		public string getCorreu (){
			return correu;
		}

		public void setID (int i){
			id = i;
		}
		public void setNom (string n){
			nom = n;
		}
		public void setPrimerCognom (string pc){
			primerCognom = pc;
		}
		public void setSegonCognom (string sc){
			segonCognom = sc;
		}
		public void setToken (string t){
			token = t;
		}
		public void setCorreu (string c){
			correu = c;
		}*/
	}
}

