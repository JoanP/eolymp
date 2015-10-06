using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace eolymp
{
	public class ModificarViewModel : ViewModelBase
	{
		public ModificarViewModel (Dictionary<string,object> info)
		{
			_nomCursa = info ["nom"].ToString();
			_dorsal = info ["dorsal"].ToString ();
			_posicio = info["posicio"].ToString();
			_distancia = info ["distancia"].ToString ();
			_posicioCategoria = info ["posicioCategoria"].ToString ();
			_categoria = info ["categoria"].ToString ();
			_club = info ["club"].ToString ();
			_iniciCursa = info ["iniciCursa"].ToString ();
			_tempsReal = info ["tempsReal"].ToString ();
			_tempsOficial = info ["tempsOficial"].ToString ();
			_iniciReal = info ["iniciReal"].ToString ();
			_horaMeta = info ["horaMeta"].ToString ();
			_ritme = info ["ritme"].ToString ();
			_km5 = info ["k59"].ToString ();
			_horaKm5 = info ["h59"].ToString ();
			_km10 = info ["k10"].ToString ();
			_horaKm10 = info ["h10"].ToString ();
			_id = info ["id"].ToString ();
		}

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
		
		private string _id;

		public string id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}


		

		public ICommand Modificada {
			get {
					return new Command (() => {
						var info = new Dictionary<string, object> {
							{ "nomCursa", _nomCursa },
							{ "dorsal", _dorsal },
							{ "posicio",_posicio },
							{ "distancia",_distancia },
							{ "posicioCategoria",_posicioCategoria },
							{ "categoria", _categoria },
							{ "club", _club },
							{ "iniciCursa",_iniciCursa },
							{ "tempsReal", _tempsReal },
							{ "tempsOficial", _tempsOficial },
							{ "iniciReal", _iniciReal },
							{ "horaMeta", _horaMeta },
							{ "ritme",_ritme },
							{ "km5",_km5 },
							{ "horaKm5",_horaKm5 },
							{ "km10",_km10 },
							{ "horaKm10", _horaKm10 },
							{ "tipus", "running" },
							{ "esportista", "Didac" }
						};
						DependencyService.Get<ICouchBase> ().modificarDoc (_id, info);
						Debug.WriteLine ("modificada");
					}
					); 
			}
		}

	}
}
