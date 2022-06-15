using DSI_PPAI_2022;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace DSI_PPAI_2022
{
	public class GestorDeRegistroRTMantenimiento 
	{

		private int fechaFinPrevista;
		private int sesionUsuarioLogueado;
		private int RTSeleccionado;
		private int recursosTecnologicos;
		private int motivoMantenimiento;
		private Sesion sesion;

		public GestorDeRegistroRTMantenimiento() {
			/**********************************************************DATA MOCK************************************************************************/
			PersonalCientífico personalCientifico1 = new PersonalCientífico(69099, "leandro", "avram", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);
			PersonalCientífico personalCientifico2 = new PersonalCientífico(45664, "vivi", "sofi", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);
			PersonalCientífico personalCientifico3 = new PersonalCientífico(78512, "Dante", "carlo", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);
			RecursoTecnologico recursoTeconologico1 = new RecursoTecnologico();
			var listaAsignaciones = new List<AsignacionResponsableTecnicoRT>();
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico1,));
			Usuario user = new Usuario("admin", "root", 0, personalCientifico1);
			Sesion sesion = new Sesion();
			sesion.FechaInicio = DateTime.Parse("2009-05-05");
			sesion.HoraInicio = TimeSpan.Parse("09:00:00");
			sesion.Usuario = user;
			this.sesion = sesion;
		}

		~GestorDeRegistroRTMantenimiento() {

		}

		public void registarIngresoRTEnMantenimientoCorrectivo() {

		}

		public void opcionRegistrarIngresoRTMantenimientoCorrectivo() {
			PersonalCientífico personal = ObtenerUsuarioLogueado();
		}

		public void agruparRTCategoria() {

		}

		public PersonalCientífico ObtenerUsuarioLogueado() {
			return this.sesion.GetPersonalCientificoEnSesion();
		}

		public AsignacionResponsableTecnicoRT esDeUsuarioLogeadoYVigente()
        {

        }

		public void tomarSeleccionRT() {

		}

		public void tomarFechaFinPrevista() {

		}

		public void tomarMotivo() {

		}

		public void buscarTurnosDeRT() {

		}

		public void ordenarTurnosXCientifico() {

		}

		public void tomarNotificacionIngresada() {

		}

		public void generarMantenimiento() {

		}

	}//end GestorDeRegistroRTMantenimiento
}