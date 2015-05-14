using System;

namespace eolymp
{
	public class running : MarcaEsportiva
	{
		private int _dorsal;
		private int _posicio;
		private int _posicioCategoria;
		private string _nom;
		private string _primerCognom;
		private string _segonCognom;
		private string _sexe;
		private string _categoria;
		private string _club;
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

		public int posicio {
			get{return _posicio; }
			set{ _posicio = value; }
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

		public running ()
		{
			id = -1000;
			//diaMesAny = new TimeSpan (2000,0,0);
			_dorsal = -1;
			_posicio = -1;
			_nom = "";
			_primerCognom = "";
			_segonCognom = "";
			_sexe ="";
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


	}
}

