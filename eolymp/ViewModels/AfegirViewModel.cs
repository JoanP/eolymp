using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.Generic;

namespace eolymp
{
	public class AfegirViewModel : ViewModelBase
	{
		private string _nomCursa;

		public string nomCursa {
			get {
				return _nomCursa;
			}
			set {
				_nomCursa = value;
			}
		}

		private string _dorsal;

		public string dorsal {
			get {
				return _dorsal;
			}
			set {
				_dorsal = value;
			}
		}

		private string _posicio;

		public string posicio {
			get {
				return _posicio;
			}
			set {
				_posicio = value;
			}
		}

		private string _distancia;

		public string distancia {
			get {
				return _distancia;
			}
			set {
				_distancia = value;
			}
		}

		private string _posicioCategoria;

		public string posicioCategoria {
			get {
				return _posicioCategoria;
			}
			set {
				_posicioCategoria = value;
			}
		}

		private string _categoria;

		public string categoria {
			get {
				return _categoria;
			}
			set {
				_categoria = value;
			}
		}

		private string _club;

		public string club {
			get {
				return _club;
			}
			set {
				_club = value;
			}
		}

		private string _iniciCursa;

		public string iniciCursa {
			get {
				return _iniciCursa;
			}
			set {
				_iniciCursa = value;
			}
		}

		private string _tempsReal;

		public string tempsReal {
			get {
				return _tempsReal;
			}
			set {
				_tempsReal = value;
			}
		}

		private string _tempsOficial;

		public string tempsOficial {
			get {
				return _tempsOficial;
			}
			set {
				_tempsOficial = value;
			}
		}

		private string _iniciReal;

		public string iniciReal {
			get {
				return _iniciReal;
			}
			set {
				_iniciReal = value;
			}
		}

		private string _horaMeta;

		public string horaMeta {
			get {
				return _horaMeta;
			}
			set {
				_horaMeta = value;
			}
		}

		private string _ritme;

		public string ritme {
			get {
				return _ritme;
			}
			set {
				_ritme = value;
			}
		}

		private string _km5;

		public string km5 {
			get {
				return _km5;
			}
			set {
				_km5 = value;
			}
		}

		private string _horaKm5;

		public string horaKm5 {
			get {
				return _horaKm5;
			}
			set {
				_horaKm5 = value;
			}
		}

		private string _km10;

		public string km10 {
			get {
				return _km10;
			}
			set {
				_km10 = value;
			}
		}

		private string _horaKm10;

		public string horaKm10 {
			get {
				return _horaKm10;
			}
			set {
				_horaKm10 = value;
			}
		}

		public AfegirViewModel ()
		{
		}
		public ICommand Save {
			get {
				return new Command (() => {
					var a = new Dictionary<string, object>{
						{"nomCursa", _nomCursa},
						{"dorsal", _dorsal},
						{"posicio",_posicio},
						{"distancia",_distancia},
						{"posicioCategoria",_posicioCategoria},
						{"categoria", _categoria},
						{"club", _club},
						{"iniciCursa",_iniciCursa},
						{"tempsReal", _tempsReal},
						{"tempsOficial", _tempsOficial},
						{"iniciReal", _iniciReal},
						{"horaMeta", _horaMeta},
						{"ritme",_ritme},
						{"km5",_km5},
						{"horaKm5",_horaKm5},
						{"km10",_km10},
						{"horaKm10", _horaKm10},
						{"tipus", "running"},
						{"esportista", "Didac"}
					};
					DependencyService.Get<ICouchBase>().crearDoc(a);
					Debug.WriteLine("saved");





				});
			}
		}
	}
}

