using System;

namespace eolymp
{
	public class Usuari
	{
		private int id;
		private string nom;
		private string primerCognom;
		private string segonCognom;
		private string token;
		private string correu;

		public Usuari ()
		{
			id = -1;
			nom = "";
			primerCognom = "";
			segonCognom = "";
			token = "";
			correu = "";
		}

		public int getID (){
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
		}
	}
}

