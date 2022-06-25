using DSI_PPAI_2022;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

namespace DSI_PPAI_2022
{
	public class GestorDeRegistroRTMantenimiento
	{
		/*********************************************************/
		private PersonalCientífico personal;
		private AsignacionResponsableTecnicoRT AsignacionRT;
		private Sesion sesion;
		private List<DatosPantallaRT> recursoTec;
		private DateTime now;
		private Estado cancelado;
		private Estado mantenimiento;
		private RecursoTecnologico rtSeleccionado;
		private DateTime fechaFinPrevista;
		private string motivo;
		/*********************************************************/


		private List<AsignacionResponsableTecnicoRT> listaAsignaciones;
		private List<AsignacionCientificoDelCI> listaAsignacionesCT;
		private List<Estado> estadosGet;
		private List<RecursoTecnologico> listaRT;
		private List<DatosPantallaTurnos> datosTurnosXcientificos;



		public GestorDeRegistroRTMantenimiento() {
			/**********************************************************DATA MOCK************************************************************************/

			// Mock personal cientifico
			PersonalCientífico personalCientifico1 = new PersonalCientífico(69099, "leandro", "avram", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);
			PersonalCientífico personalCientifico2 = new PersonalCientífico(45664, "vivi", "sofi", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);
			PersonalCientífico personalCientifico3 = new PersonalCientífico(78512, "Dante", "carlo", 634678, "ldavram@teco.com.ar", "leoavram7@gmail.com", 351706475);

			// Mock Estados
			// Estados ambito RT
			Estado estadoConIngresoEnMC = new Estado("Con ingreso en Mantenimiento correctivo.", "CI disulelto , dado de baja.", "RT", 1, 1);
			Estado estadoIngresado = new Estado("Ingresado", "RT dado de alta con sus respectivos datos", "RT", 1, 1);
			Estado estadoDisponible = new Estado("Disponible", "RT disponible para ser reservado", "RT", 1, 1);
			Estado estadoEnMantenimiento = new Estado("En Mantenimiento", "RT en Mantenimiento", "RT", 1, 1);

			// Estados ambito Turno
			Estado estadoConfirmado = new Estado("Confirmado", "Turno que se encuentra con fecha confirmada.", "Turno", 1, 1);
			Estado estadoPendienteDeConfirmacion = new Estado("Pendiente de confirmacion", "Turno que se encuentra pendiente de confirmacion.", "Turno", 1, 1);
			Estado estadoCanceladoMantenimientoCorrectivo = new Estado("Cancelado por mantenimiento correctivo", "Turno que se encuentra entre un periodo donde se lleva acabo un mantenimiento.", "Turno", 1, 1);
			estadosGet.Add(estadoConIngresoEnMC);
			estadosGet.Add(estadoIngresado);
			estadosGet.Add(estadoDisponible);
			estadosGet.Add(estadoEnMantenimiento);
			estadosGet.Add(estadoConfirmado);
			estadosGet.Add(estadoPendienteDeConfirmacion);
			estadosGet.Add(estadoCanceladoMantenimientoCorrectivo);


			// Mock Cambio Estado RT1
			CambioEstadoRT cambioEstadoRT11 = new CambioEstadoRT(DateTime.Parse("2020-03-10"), DateTime.Parse("2020-11-10"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT12 = new CambioEstadoRT(DateTime.Parse("2020-01-10"), DateTime.Parse("2022-06-10"), estadoDisponible);
			CambioEstadoRT cambioEstadoRT13 = new CambioEstadoRT(DateTime.Parse("2020-01-10"), DateTime.Parse("2022-06-10"), estadoConIngresoEnMC);
			CambioEstadoRT cambioEstadoRT14 = new CambioEstadoRT(DateTime.Parse("2022-06-10"), null, estadoDisponible);
			var listaCERT1 = new List<CambioEstadoRT>();
			listaCERT1.Add(cambioEstadoRT11);
			listaCERT1.Add(cambioEstadoRT12);
			listaCERT1.Add(cambioEstadoRT13);
			listaCERT1.Add(cambioEstadoRT14);


			// Mock Cambio Estado RT2
			CambioEstadoRT cambioEstadoRT21 = new CambioEstadoRT(DateTime.Parse("2022-06-10"), DateTime.Parse("2022-06-10"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT23 = new CambioEstadoRT(DateTime.Parse("2022-06-10"), null, estadoDisponible);
			var listaCERT2 = new List<CambioEstadoRT>();
			listaCERT2.Add(cambioEstadoRT21);
			listaCERT2.Add(cambioEstadoRT23);

			// Mock Cambio Estado RT3
			CambioEstadoRT cambioEstadoRT31 = new CambioEstadoRT(DateTime.Parse("2021-04-15"), DateTime.Parse("2022-01-10"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT32 = new CambioEstadoRT(DateTime.Parse("2022-01-10"), DateTime.Parse("2022-03-10"), estadoDisponible);
			CambioEstadoRT cambioEstadoRT33 = new CambioEstadoRT(DateTime.Parse("2022-03-10"), null, estadoEnMantenimiento);
			var listaCERT3 = new List<CambioEstadoRT>();
			listaCERT3.Add(cambioEstadoRT31);
			listaCERT3.Add(cambioEstadoRT32);
			listaCERT3.Add(cambioEstadoRT33);


			// Mock Cambio Estado RT4
			CambioEstadoRT cambioEstadoRT41 = new CambioEstadoRT(DateTime.Parse("2015-06-10"), DateTime.Parse("2018-06-06"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT42 = new CambioEstadoRT(DateTime.Parse("2018-06-06"), DateTime.Parse("2021-12-24"), estadoDisponible);
			CambioEstadoRT cambioEstadoRT43 = new CambioEstadoRT(DateTime.Parse("2019-10-20"), DateTime.Parse("2021-12-24"), estadoConIngresoEnMC);
			CambioEstadoRT cambioEstadoRT44 = new CambioEstadoRT(DateTime.Parse("2021-12-24"), null, estadoDisponible);
			var listaCERT4 = new List<CambioEstadoRT>();
			listaCERT4.Add(cambioEstadoRT41);
			listaCERT4.Add(cambioEstadoRT42);
			listaCERT4.Add(cambioEstadoRT43);
			listaCERT4.Add(cambioEstadoRT44);

			// Mock Cambio Estado RT5
			CambioEstadoRT cambioEstadoRT51 = new CambioEstadoRT(DateTime.Parse("2014-05-20"), DateTime.Parse("2021-12-24"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT52 = new CambioEstadoRT(DateTime.Parse("2021-12-24"), null, estadoDisponible);
			var listaCERT5 = new List<CambioEstadoRT>();
			listaCERT5.Add(cambioEstadoRT51);
			listaCERT5.Add(cambioEstadoRT52);

			// Mock Cambio Estado RT6
			CambioEstadoRT cambioEstadoRT61 = new CambioEstadoRT(DateTime.Parse("2014-05-20"), DateTime.Parse("2021-12-24"), estadoIngresado);
			CambioEstadoRT cambioEstadoRT62 = new CambioEstadoRT(DateTime.Parse("2021-12-24"), null, estadoDisponible);
			var listaCERT6 = new List<CambioEstadoRT>();
			listaCERT6.Add(cambioEstadoRT61);
			listaCERT6.Add(cambioEstadoRT62);


			//Cambio estado turno
			CambioEstadoTurno cambioEstadoTurno = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoConfirmado);
			CambioEstadoTurno cambioEstadoTurno2 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoPendienteDeConfirmacion);
			CambioEstadoTurno cambioEstadoTurno8 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), DateTime.Parse("2022-05-07 09:00"), estadoConfirmado);
			CambioEstadoTurno cambioEstadoTurno9 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), DateTime.Parse("2022-05-07 09:00"), estadoConfirmado);
			CambioEstadoTurno cambioEstadoTurno3 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoConfirmado);
			CambioEstadoTurno cambioEstadoTurno4 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoPendienteDeConfirmacion);
			CambioEstadoTurno cambioEstadoTurno5 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoConfirmado);
			CambioEstadoTurno cambioEstadoTurno6 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoPendienteDeConfirmacion);
			CambioEstadoTurno cambioEstadoTurno7 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), null, estadoPendienteDeConfirmacion);
			CambioEstadoTurno cambioEstadoTurno11 = new CambioEstadoTurno(DateTime.Parse("2022-05-05 08:00"), DateTime.Parse("2022-05-07 09:00"), estadoCanceladoMantenimientoCorrectivo);
			var listaCET1 = new List<CambioEstadoTurno>();
			listaCET1.Add(cambioEstadoTurno8);
			listaCET1.Add(cambioEstadoTurno);
			var listaCET2 = new List<CambioEstadoTurno>();
			listaCET2.Add(cambioEstadoTurno9);
			listaCET2.Add(cambioEstadoTurno2);
			var listaCET3 = new List<CambioEstadoTurno>();
			listaCET3.Add(cambioEstadoTurno11);
			listaCET3.Add(cambioEstadoTurno3);
			var listaCET4 = new List<CambioEstadoTurno>();
			listaCET4.Add(cambioEstadoTurno4);
			var listaCET5 = new List<CambioEstadoTurno>();
			listaCET5.Add(cambioEstadoTurno5);
			var listaCET6 = new List<CambioEstadoTurno>();
			listaCET6.Add(cambioEstadoTurno6);
			var listaCET7 = new List<CambioEstadoTurno>();
			listaCET7.Add(cambioEstadoTurno7);


			//Turno Mock
			Turno turno = new Turno(DateTime.Parse("2022-04-05"), "Lunes", DateTime.Parse("2022-05-15 10:30"), DateTime.Parse("2022-05-05 11:30"), listaCET1);
			Turno turno2 = new Turno(DateTime.Parse("2022-03-10"), "Lunes", DateTime.Parse("2022-03-12 16:00"), DateTime.Parse("2022-03-12 17:00"), listaCET2);
			Turno turno3 = new Turno(DateTime.Parse("2022-06-22"), "Lunes", DateTime.Parse("2022-07-15 08:00"), DateTime.Parse("2022-07-15 09:00"), listaCET3);
			Turno turno4 = new Turno(DateTime.Parse("2022-06-21"), "Lunes", DateTime.Parse("2022-07-20 15:00"), DateTime.Parse("2022-07-20 16:00"), listaCET4);
			Turno turno5 = new Turno(DateTime.Parse("2022-03-03"), "Lunes", DateTime.Parse("2022-05-15 10:30"), DateTime.Parse("2022-05-05 11:30"), listaCET5);
			Turno turno6 = new Turno(DateTime.Parse("2022-04-05"), "Lunes", DateTime.Parse("2022-05-15 10:30"), DateTime.Parse("2022-05-05 11:30"), listaCET6);
			Turno turno7 = new Turno(DateTime.Parse("2022-04-05"), "Lunes", DateTime.Parse("2022-05-15 10:30"), DateTime.Parse("2022-05-05 11:30"), listaCET7);
			var listaTurno1 = new List<Turno>();
			listaTurno1.Add(turno);
			var listaTurno2 = new List<Turno>();
			listaTurno2.Add(turno2);
			var listaTurno3 = new List<Turno>();
			listaTurno3.Add(turno3);
			var listaTurno4 = new List<Turno>();
			listaTurno4.Add(turno4);
			var listaTurno5 = new List<Turno>();
			listaTurno5.Add(turno5);
			var listaTurno6 = new List<Turno>();
			listaTurno6.Add(turno6);


			// Mock Modelo y Marc
			var listaModelo1 = new List<Modelo>();
			Modelo modelo11 = new Modelo("AIO iMac MXWT2LE/A");
			Modelo modelo12 = new Modelo("MacBook Pro");
			listaModelo1.Add(modelo11);
			listaModelo1.Add(modelo12);
			var listaModelo2 = new List<Modelo>();
			Modelo modelo21 = new Modelo("Surface Laptop Studio");
			Modelo modelo22 = new Modelo("Surface Laptop Go");
			listaModelo2.Add(modelo21);
			listaModelo2.Add(modelo22);
			var listaModelo3 = new List<Modelo>();
			Modelo modelo31 = new Modelo("Notebook 9 Pro");
			Modelo modelo32 = new Modelo("Notebook 9 Flash");
			listaModelo3.Add(modelo31);
			listaModelo3.Add(modelo32);
			var listaModelo4 = new List<Modelo>();
			Modelo modelo41 = new Modelo("Pavilion");
			Modelo modelo42 = new Modelo("OMEN 16-b0507la");
			listaModelo4.Add(modelo41);
			listaModelo4.Add(modelo42);
			var listaModelo5 = new List<Modelo>();
			Modelo modelo51 = new Modelo("Latitude 5410");
			Modelo modelo52 = new Modelo("Vostro Business Flagship");
			listaModelo5.Add(modelo51);
			listaModelo5.Add(modelo52);


			Marca marca1 = new Marca("Apple", listaModelo1);
			Marca marca2 = new Marca("Microsoft", listaModelo2);
			Marca marca3 = new Marca("Samsung", listaModelo3);
			Marca marca4 = new Marca("Hp", listaModelo4);
			Marca marca5 = new Marca("Dell", listaModelo5);

			// Mock Tipo Recurso Tecnologicos

			TipoRecursoTecnologico tipoRT1 = new TipoRecursoTecnologico("Notebook", "Recurso tecnologico notebook", null);
			TipoRecursoTecnologico tipoRT2 = new TipoRecursoTecnologico("PC", "Recurso tecnologico pc de escritorio", null);

			// Mock Recursos Tecnologicos
			RecursoTecnologico recursoTeconologico1 = new RecursoTecnologico(10, DateTime.Parse("2010-05-30"), "*", 30, 1, 30, modelo12, tipoRT2, null, null, null, listaCERT1, listaTurno1);
			RecursoTecnologico recursoTeconologico2 = new RecursoTecnologico(11, DateTime.Parse("2010-06-05"), "*", 30, 1, 30, modelo21, tipoRT1, null, null, null, listaCERT2, listaTurno2);
			RecursoTecnologico recursoTeconologico3 = new RecursoTecnologico(12, DateTime.Parse("2008-05-15"), "*", 30, 1, 30, modelo31, tipoRT1, null, null, null, listaCERT3, listaTurno3);
			RecursoTecnologico recursoTeconologico4 = new RecursoTecnologico(13, DateTime.Parse("2005-06-05"), "*", 30, 1, 30, modelo41, tipoRT2, null, null, null, listaCERT4, listaTurno4);
			RecursoTecnologico recursoTeconologico5 = new RecursoTecnologico(14, DateTime.Parse("2015-05-04"), "*", 30, 1, 30, modelo51, tipoRT2, null, null, null, listaCERT5, listaTurno5);
			RecursoTecnologico recursoTeconologico6 = new RecursoTecnologico(15, DateTime.Parse("2020-01-05"), "*", 30, 1, 30, modelo52, tipoRT2, null, null, null, listaCERT6, listaTurno6);
            var listaRT = new List<RecursoTecnologico>();
            listaRT.Add(recursoTeconologico1);
			listaRT.Add(recursoTeconologico2);
			listaRT.Add(recursoTeconologico3);
			listaRT.Add(recursoTeconologico4);
			listaRT.Add(recursoTeconologico5);
			listaRT.Add(recursoTeconologico6);

			// Mock AsignacionesResponsableTecnicoRT
			listaAsignaciones = new List<AsignacionResponsableTecnicoRT>();
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico1, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), null, personalCientifico1, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico2, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), null, personalCientifico3, listaRT));

			// Mock AsignacionesResponsableTecnicoRT
			listaAsignacionesCT = new List<AsignacionCientificoDelCI>();
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico1, listaTurno1));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico1, listaTurno2));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico2, listaTurno3));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico3, listaTurno4));


			// Mock session
			Usuario user = new Usuario("admin", "root", 0, personalCientifico1);
			Sesion sesion = new Sesion();
			sesion.FechaInicio = DateTime.Parse("2009-05-05");
			sesion.HoraInicio = TimeSpan.Parse("09:00:00");
			sesion.Usuario = user;
			this.sesion = sesion;
		}

		~GestorDeRegistroRTMantenimiento() {

		}

		public IEnumerable<IGrouping<string, DatosPantallaRT>> opcionRegistrarIngresoRTMantenimientoCorrectivo() {
			this.personal = ObtenerUsuarioLogueado();
			this.AsignacionRT = esDeUsuarioLogeadoYVigente(personal, this.listaAsignaciones);
			this.recursoTec = obtenerRTdisponible(this.AsignacionRT);
			return agruparRTTipoRecurso(this.recursoTec);
		}

		/* Obtiene el cientifico que esta logeado en la session */
		public PersonalCientífico ObtenerUsuarioLogueado() {
			return this.sesion.GetPersonalCientificoEnSesion();
		}

		/* Buscar para todas las asignaciones que sea del usuario logeado y que sea la vigente (la ultima que no tiene fecha fin) */
		public AsignacionResponsableTecnicoRT esDeUsuarioLogeadoYVigente(PersonalCientífico personal, List<AsignacionResponsableTecnicoRT> RespTecRT)
		{
			foreach (AsignacionResponsableTecnicoRT resp in RespTecRT)
			{
				if (resp.esDeUsuarioLogueadoYVigente(personal, resp))
				{
					return resp;
				}
			}
			return null;
		}

		/* Busca los recursos tecnologicos vigentes del responsable tecnico y trae los datos necesarios para mostrar en pantalla */
		public List<DatosPantallaRT> obtenerRTdisponible(AsignacionResponsableTecnicoRT RespTecRT)
		{
			List<DatosPantallaRT> test = RespTecRT.getMisRT();
			return test;
		}
		public void prueba(List<DatosPantallaRT> RT)
        {
			foreach(DatosPantallaRT resp in RT)
            {
				string[] info = new string[4];
				info[0] = resp.NumeroRT.ToString();

            }
        }
		public IEnumerable<IGrouping<string, DatosPantallaRT>> agruparRTTipoRecurso(List<DatosPantallaRT> RTPantalla)
		{
			return from rt in RTPantalla group rt by rt.TipoRecursoTecnologico;
		}

		public void tomarMotivo(string motivo)
		{
			this.motivo = motivo;
			this.now = obtenerFechaHoraActual();
			buscarTurnosCancelablesEnPeriodo(this.rtSeleccionado,this.fechaFinPrevista);
		}

		public DateTime obtenerFechaHoraActual()
        {
			return DateTime.Now;
        }

		public void tomarSeleccionRT(int numeroRtSelect)
        {
			foreach (RecursoTecnologico rt in listaRT)
            {
				if(rt.NumeroRT== numeroRtSelect)
                {
					this.rtSeleccionado = rt;
				}
            }
		}

		public void tomarFechaFinPrevista(DateTime fecha)
        {
			this.fechaFinPrevista = fecha;

		}

		public IEnumerable<IGrouping<int, DatosPantallaTurnos>> buscarTurnosCancelablesEnPeriodo(RecursoTecnologico rt, DateTime fecha)
        {
			this.datosTurnosXcientificos = rt.obtenerTurnosCancelablesEnPeriodo(fecha,this.listaAsignacionesCT);
			return ordenarTurnosXCientifico(datosTurnosXcientificos);
		}

		public IEnumerable<IGrouping<int, DatosPantallaTurnos>> ordenarTurnosXCientifico(List<DatosPantallaTurnos> CTPantalla)
		{
			return from tur in CTPantalla group tur by tur.PersonalCientifico.Legajo;
		}

		public void tomarNotificacionIngresada()
        {
			obtenerEstados(this.estadosGet);
			generarMantenimiento();
		}

		

		public void obtenerEstados(List<Estado> estados)
        {
			foreach (Estado estado in estados)
            {
                if (estado.esAmbitoTurno())
                {
					if (estado.esCancelado())
                    {
						this.cancelado = estado;
					}
				}
				if (estado.esAmbitoTurno())
				{
					if (estado.esCancelado())
					{
						this.mantenimiento = estado;
					}
				}

			}
        }

		public Boolean generarMantenimiento()
        {
			this.rtSeleccionado.ingresarAmantenimientoCorrectivo(this.mantenimiento, this.fechaFinPrevista,this.motivo);
			this.rtSeleccionado.cancelarTurnoConReserva(this.cancelado);
			var email = generarMail();
            foreach (var cintf in this.datosTurnosXcientificos)
            {
				enviarEmail(cintf.PersonalCientifico.CorreoElectronicoPersonal);
			}
			return true;
		}

		public string generarMail()
        {
			return "mail";
        }

		public Boolean enviarEmail(string correo)
		{
			return true;
		}
	}
}