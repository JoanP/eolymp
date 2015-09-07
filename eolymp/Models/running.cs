using System;

namespace eolymp
{
	public class running : MarcaEsportiva
	{
		private int _dorsal;
		private int _posicio;
		private int _distancia;
		private int _posicioCategoria;
		private string _nom;
		private string _categoria;
		private string _club;
		private string _modalitat;
		private TimeSpan _iniciCursa;
		private TimeSpan _tempsReal;
		private TimeSpan _tempsOficial;
		private TimeSpan _iniciReal;
		private TimeSpan _horaMeta;
		private TimeSpan _ritme;
		private TimeSpan _k59;
		private TimeSpan _hk59;
		private TimeSpan _k10;
		private TimeSpan _hk10;

		public int dorsal {
			get {return _dorsal;}
			set {_dorsal = value;}
		}

		public int posicio {
			get{return _posicio; }
			set{ _posicio = value; }
		}
		public int distancia {
			get{return _distancia; }
			set { _distancia = value; }
		}

		public int posicioCategoria {
			get {return _posicioCategoria;}
			set {_posicioCategoria = value;}
		}

		public string categoria {
			get {return _categoria;}
			set {_categoria = value;}
		}

		public TimeSpan tempsOficial {
			get{return _tempsOficial; }
			set { _tempsOficial = value; }
		}
		public TimeSpan ritme {
			get{return _ritme; }
			set{ _ritme = value; }
		}
		public TimeSpan k59 {
			get {return _k59; }
			set{ _k59 = value; }
		}
		public TimeSpan k10 {
			get{return _k10; }
			set{ _k10 = value; }
		}
		public TimeSpan h59 {
			get {return _hk59; }
			set{ _hk59 = value; }
		}
		public TimeSpan h10 {
			get{return _hk10; }
			set{ _hk10 = value; }
		}
		public string nom {
			get {return _nom; }
			set { _nom = value; }
		}

		public string club {
			get {return _club;}
			set {_club = value;}
		}

		public TimeSpan iniciCursa {
			get {return _iniciCursa;}
			set {_iniciCursa = value;}
		}

		public TimeSpan tempsReal {
			get {return _tempsReal;}
			set {_tempsReal = value;}
		}

		public TimeSpan iniciReal {
			get {return _iniciReal;}
			set {_iniciReal = value;}
		}

		public TimeSpan horaMeta {
			get {return _horaMeta;}
			set {_horaMeta = value;}
		}

		public string modalitat {
			get {return _modalitat;}
			set {_modalitat = value;}
		}

		public running ()
		{
			id = "";
			_nom = "Cursa del corte ingles";
			//diaMesAny = new TimeSpan (2000,0,0);
			_dorsal = -1;
			_posicio = -1;
			_distancia = -11;
			_modalitat = "";
			_categoria = "";
			_posicioCategoria = -1;
			_club = "";
			_iniciCursa = new TimeSpan(0,0,0);
			_tempsReal = new TimeSpan(0,0,0); 
			_tempsOficial = new TimeSpan(0,0,0);
			_iniciReal = new TimeSpan(0,0,0);
			_horaMeta = new TimeSpan(0,0,0);
			_ritme = new TimeSpan(0,0,0);
			_k59 = new TimeSpan(0,0,0);
			_hk59 = new TimeSpan(0,0,0);
			_k10 = new TimeSpan(0,0,0);
			_hk10 = new TimeSpan(0,0,0);
		}
		public running (string ID){
			id = ID;
		}


	}
}

