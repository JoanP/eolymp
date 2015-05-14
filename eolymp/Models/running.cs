using System;

namespace eolymp
{
	public class running : MarcaEsportiva
	{
		private int dorsal;
		private int posicio;
		private int posicioCategoria;
		private string nom;
		private string primerCognom;
		private string segonCognom;
		private string sexe;
		private string categoria;
		private string club;
		private TimeSpan iniciCursa;
		private TimeSpan tempsReal;
		private TimeSpan tempsOficial;
		private TimeSpan iniciReal;
		private TimeSpan horaMeta;
		private TimeSpan ritme;
		private TimeSpan k59;
		private TimeSpan hk59;
		private TimeSpan k10;
		private TimeSpan hk10;



		public running ()
		{
			id = -1;
			//diaMesAny = new DateTime (2000,0,0);
			dorsal = -1;
			posicio = -1;
			nom = "";
			primerCognom = "";
			segonCognom = "";
			sexe ="";
			categoria = "";
			posicioCategoria = -1;
			club = "";
			iniciCursa = new TimeSpan(0,0,0);
			tempsReal = new TimeSpan(0,0,0); 
			tempsOficial = new TimeSpan(0,0,0);
			iniciReal = new TimeSpan(0,0,0);
			horaMeta = new TimeSpan(0,0,0);
			ritme = new TimeSpan(0,0,0);
			k59 = new TimeSpan(0,0,0);
			hk59 = new TimeSpan(0,0,0);
			k10 = new TimeSpan(0,0,0);
			hk10 = new TimeSpan(0,0,0);

		}

		public int getDorsal(){
			return this.dorsal;
		}
		public int getPosicio(){
			return this.posicio;
		}
		public int getPosicioCategoria(){
			return this.posicioCategoria;
		}
		public string getNom(){
			return this.nom;
		}
		public string getPrimerCognom(){
			return this.primerCognom;
		}
		public string getSegonCognom(){
			return this.segonCognom;
		}
		public string getSexe(){
			return this.sexe;
		}
		public string getCategoria(){
			return this.categoria;
		}
		public string getClub(){
			return this.club;
		}
		public TimeSpan getIniciCursa(){
			return this.iniciCursa;
		}
		public TimeSpan getTempsReal(){
			return this.tempsReal;
		}
		public TimeSpan getTempsOficial(){
			return this.tempsOficial;
		}
		public TimeSpan getIniciReal(){
			return this.iniciReal;
		}
		public TimeSpan getHoraMeta(){
			return this.horaMeta;
		}
		public TimeSpan getRitme(){
			return this.ritme;
		}
		public TimeSpan getK59(){
			return this.k59;
		}
		public TimeSpan getHK59(){
			return this.hk59;
		}
		public TimeSpan getK10(){
			return this.k10;
		}
		public TimeSpan getHK10(){
			return this.hk10;
		}

		public void setDorsal(int d){
			this.dorsal = d;
		}
		public void setPosicio(int p){
			this.posicio = p;
		}
		public void setPosicioCategoria(int pc){
			this.posicioCategoria = pc;
		}
		public void setNom(string n){
			this.nom = n;
		}
		public void setPrimerCognom(string pc){
			this.primerCognom = pc;
		}
		public void setSegonCognom(string sc){
			this.segonCognom = sc;
		}
		public void setSexe(string s){
			this.sexe = s;
		}
		public void setCategoria(string c){
			this.categoria = c;
		}
		public void setClub(string c){
			this.club = c;
		}
		public void setIniciCursa(TimeSpan ic){
			this.iniciCursa = ic;
		}
		public void setTempsReal(TimeSpan tr){
			this.tempsReal = tr;
		}
		public void setTempsOficial(TimeSpan to){
			this.tempsOficial = to;
		}
		public void setIniciReal(TimeSpan ir){
			this.iniciReal = ir;
		}
		public void setHoraMeta(TimeSpan hm){
			this.horaMeta = hm;
		}
		public void setRitme(TimeSpan r){
			this.ritme = r;
		}
		public void setK59(TimeSpan k){
			this.k59 = k;
		}
		public void setHK59(TimeSpan k){
			this.hk59 = k;
		}
		public void setK10(TimeSpan k){
			this.k10 = k;
		}
		public void setHK10(TimeSpan k){
			this.hk10 = k;
		}
	}
}

