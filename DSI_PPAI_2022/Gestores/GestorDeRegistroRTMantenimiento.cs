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
			estadosGet = new List<Estado>();
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
			/*
			Turno turno = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-27 10:30"), DateTime.Parse("2022-06-27 11:30"), listaCET1);
			Turno turno2 = new Turno(DateTime.Parse("2022-06-30"), "Martes", DateTime.Parse("2022-06-30 16:00"), DateTime.Parse("2022-06-30 16:30"), listaCET2);
			Turno turno3 = new Turno(DateTime.Parse("2022-07-22"), "Miercoles", DateTime.Parse("2022-06-28 08:00"), DateTime.Parse("2022-07-28 09:00"), listaCET3);
			Turno turno4 = new Turno(DateTime.Parse("2022-08-21"), "Jueves", DateTime.Parse("2022-06-29 15:00"), DateTime.Parse("2022-06-29 15:30"), listaCET4);
			Turno turno5 = new Turno(DateTime.Parse("2022-06-26"), "Viernes", DateTime.Parse("2022-06-26 10:30"), DateTime.Parse("2022-06-26 11:00"), listaCET5);
			Turno turno6 = new Turno(DateTime.Parse("2022-10-05"), "Lunes", DateTime.Parse("2022-06-25 10:30"), DateTime.Parse("2022-06-25 11:00"), listaCET6);
			Turno turno7 = new Turno(DateTime.Parse("2022-06-26"), "Martes", DateTime.Parse("2022-06-15 10:30"), DateTime.Parse("2022-06-15 11:00"), listaCET7);
			Turno turno8 = new Turno(DateTime.Parse("2022-06-29"), "jueves", DateTime.Parse("2022-07-16 10:30"), DateTime.Parse("2022-07-16 15:00"), listaCET1);
			Turno turno9 = new Turno(DateTime.Parse("2022-06-30"), "Lunes", DateTime.Parse("2022-07-15 10:30"), DateTime.Parse("2022-07-15 15:00"), listaCET1);
			Turno turno10 = new Turno(DateTime.Parse("2022-07-01"), "Lunes", DateTime.Parse("2022-07-01 11:30"), DateTime.Parse("2022-07-01 12:30"), listaCET1);
			Turno turno11 = new Turno(DateTime.Parse("2022-07-02"), "Martes", DateTime.Parse("2022-07-02 11:30"), DateTime.Parse("2022-07-02 12:30"), listaCET1);
			Turno turno12 = new Turno(DateTime.Parse("2022-07-03"), "Miercoles", DateTime.Parse("2022-07-03 11:30"), DateTime.Parse("2022-07-03 13:30"), listaCET1);
			Turno turno13 = new Turno(DateTime.Parse("2022-07-04"), "Jueves", DateTime.Parse("2022-07-04 11:30"), DateTime.Parse("2022-07-04 12:30"), listaCET1);
			Turno turno14 = new Turno(DateTime.Parse("2022-07-05"), "Viernes", DateTime.Parse("2022-07-05 11:30"), DateTime.Parse("2022-07-05 14:30"), listaCET1);
			Turno turno15 = new Turno(DateTime.Parse("2022-07-06"), "Lunes", DateTime.Parse("2022-07-06 11:30"), DateTime.Parse("2022-07-06 16:30"), listaCET1);
			Turno turno16 = new Turno(DateTime.Parse("2022-07-07"), "Martes", DateTime.Parse("2022-07-07 11:30"), DateTime.Parse("2022-07-07 12:30"), listaCET1);
			*/

			/* Turnos de RT 1 */
			Turno turnos11 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 10:30"), DateTime.Parse("2022-06-29 11:30"), listaCET1);
			Turno turnos12 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 11:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos13 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 9:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos14 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 14:00"), DateTime.Parse("2022-06-29 15:00"), listaCET1);
			Turno turnos15 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-01 14:00"), DateTime.Parse("2022-07-01 15:00"), listaCET1);
			Turno turnos16 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 10:00"), DateTime.Parse("2022-07-02 11:00"), listaCET1);
			Turno turnos17 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 12:00"), DateTime.Parse("2022-07-02 14:00"), listaCET1);
			Turno turnos18 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos19 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 12:00"), DateTime.Parse("2022-07-03 14:00"), listaCET1);
			Turno turnos20 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 09:00"), DateTime.Parse("2022-07-03 10:00"), listaCET1);
			Turno turnos21 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos22 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 11:00"), DateTime.Parse("2022-07-03 12:00"), listaCET1);
			var listaTurnosRT1 = new List<Turno>();
			listaTurnosRT1.Add(turnos11);
			listaTurnosRT1.Add(turnos12);
			listaTurnosRT1.Add(turnos13);
			listaTurnosRT1.Add(turnos14);
			listaTurnosRT1.Add(turnos15);
			listaTurnosRT1.Add(turnos16);
			listaTurnosRT1.Add(turnos17);
			listaTurnosRT1.Add(turnos18);
			listaTurnosRT1.Add(turnos19);
			listaTurnosRT1.Add(turnos20);
			listaTurnosRT1.Add(turnos21);
			listaTurnosRT1.Add(turnos22);
			/*************************************************/
			/* Turnos de RT 2 */
			Turno turnos221 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 10:30"), DateTime.Parse("2022-06-29 11:30"), listaCET1);
			Turno turnos222 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 11:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos223 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 9:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos224 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 14:00"), DateTime.Parse("2022-06-29 15:00"), listaCET1);
			Turno turnos225 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-01 14:00"), DateTime.Parse("2022-07-01 15:00"), listaCET1);
			Turno turnos226 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 10:00"), DateTime.Parse("2022-07-02 11:00"), listaCET1);
			Turno turnos227 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 12:00"), DateTime.Parse("2022-07-02 14:00"), listaCET1);
			Turno turnos228 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos229 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 12:00"), DateTime.Parse("2022-07-03 14:00"), listaCET1);
			Turno turnos220 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 09:00"), DateTime.Parse("2022-07-03 10:00"), listaCET1);
			Turno turnos2221 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos2222 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 11:00"), DateTime.Parse("2022-07-03 12:00"), listaCET1);
			var listaTurnosRT2 = new List<Turno>();
			listaTurnosRT2.Add(turnos221);
			listaTurnosRT2.Add(turnos222);
			listaTurnosRT2.Add(turnos223);
			listaTurnosRT2.Add(turnos224);
			listaTurnosRT2.Add(turnos225);
			listaTurnosRT2.Add(turnos226);
			listaTurnosRT2.Add(turnos227);
			listaTurnosRT2.Add(turnos228);
			listaTurnosRT2.Add(turnos229);
			listaTurnosRT2.Add(turnos220);
			listaTurnosRT2.Add(turnos2221);
			listaTurnosRT2.Add(turnos2222);
			/*************************************************/
			/* Turnos de RT 3 */
			Turno turnos331 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 10:30"), DateTime.Parse("2022-06-29 11:30"), listaCET1);
			Turno turnos332 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-29 11:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos333 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 9:30"), DateTime.Parse("2022-06-29 12:30"), listaCET1);
			Turno turnos334 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-30 14:00"), DateTime.Parse("2022-06-29 15:00"), listaCET1);
			Turno turnos335 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-01 14:00"), DateTime.Parse("2022-07-01 15:00"), listaCET1);
			Turno turnos336 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 10:00"), DateTime.Parse("2022-07-02 11:00"), listaCET1);
			Turno turnos337 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-02 12:00"), DateTime.Parse("2022-07-02 14:00"), listaCET1);
			Turno turnos338 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos339 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-03 12:00"), DateTime.Parse("2022-07-03 14:00"), listaCET1);
			Turno turnos330 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 09:00"), DateTime.Parse("2022-07-03 10:00"), listaCET1);
			Turno turnos3312 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 10:00"), DateTime.Parse("2022-07-03 11:00"), listaCET1);
			Turno turnos3321 = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-07-04 11:00"), DateTime.Parse("2022-07-03 12:00"), listaCET1);
			var listaTurnosRT3 = new List<Turno>();
			listaTurnosRT3.Add(turnos331);
			listaTurnosRT3.Add(turnos332);
			listaTurnosRT3.Add(turnos333);
			listaTurnosRT3.Add(turnos334);
			listaTurnosRT3.Add(turnos335);
			listaTurnosRT3.Add(turnos336);
			listaTurnosRT3.Add(turnos337);
			listaTurnosRT3.Add(turnos338);
			listaTurnosRT3.Add(turnos339);
			listaTurnosRT3.Add(turnos330);
			listaTurnosRT3.Add(turnos3312);
			listaTurnosRT3.Add(turnos3321);
			/*************************************************/
			/* Turnos de RT 4 */
			Turno turno = new Turno(DateTime.Parse("2022-06-27"), "Lunes", DateTime.Parse("2022-06-27 10:30"), DateTime.Parse("2022-06-27 11:30"), listaCET1);
			Turno turno2 = new Turno(DateTime.Parse("2022-06-30"), "Martes", DateTime.Parse("2022-06-30 16:00"), DateTime.Parse("2022-06-30 16:30"), listaCET2);
			Turno turno3 = new Turno(DateTime.Parse("2022-07-22"), "Miercoles", DateTime.Parse("2022-06-28 08:00"), DateTime.Parse("2022-07-28 09:00"), listaCET3);
			Turno turno4 = new Turno(DateTime.Parse("2022-08-21"), "Jueves", DateTime.Parse("2022-06-29 15:00"), DateTime.Parse("2022-06-29 15:30"), listaCET4);
			Turno turno5 = new Turno(DateTime.Parse("2022-06-26"), "Viernes", DateTime.Parse("2022-06-26 10:30"), DateTime.Parse("2022-06-26 11:00"), listaCET5);
			Turno turno6 = new Turno(DateTime.Parse("2022-10-05"), "Lunes", DateTime.Parse("2022-06-25 10:30"), DateTime.Parse("2022-06-25 11:00"), listaCET6);
			Turno turno7 = new Turno(DateTime.Parse("2022-06-26"), "Martes", DateTime.Parse("2022-06-15 10:30"), DateTime.Parse("2022-06-15 11:00"), listaCET7);
			Turno turno8 = new Turno(DateTime.Parse("2022-06-29"), "jueves", DateTime.Parse("2022-07-16 10:30"), DateTime.Parse("2022-07-16 15:00"), listaCET1);
			var listaTurnosRT4 = new List<Turno>();
			listaTurnosRT3.Add(turno);
			listaTurnosRT3.Add(turno2);
			listaTurnosRT3.Add(turno3);
			listaTurnosRT3.Add(turno4);
			listaTurnosRT3.Add(turno5);
			listaTurnosRT3.Add(turno6);
			listaTurnosRT3.Add(turno7);
			listaTurnosRT3.Add(turno8);
			/*************************************************/
			/* Turnos de RT 5 */
			Turno turno9 = new Turno(DateTime.Parse("2022-06-30"), "Lunes", DateTime.Parse("2022-07-15 10:30"), DateTime.Parse("2022-07-15 15:00"), listaCET1);
			Turno turno10 = new Turno(DateTime.Parse("2022-07-01"), "Lunes", DateTime.Parse("2022-07-01 11:30"), DateTime.Parse("2022-07-01 12:30"), listaCET1);
			Turno turno11 = new Turno(DateTime.Parse("2022-07-02"), "Martes", DateTime.Parse("2022-07-02 11:30"), DateTime.Parse("2022-07-02 12:30"), listaCET1);
			Turno turno12 = new Turno(DateTime.Parse("2022-07-03"), "Miercoles", DateTime.Parse("2022-07-03 11:30"), DateTime.Parse("2022-07-03 13:30"), listaCET1);
			Turno turno13 = new Turno(DateTime.Parse("2022-07-04"), "Jueves", DateTime.Parse("2022-07-04 11:30"), DateTime.Parse("2022-07-04 12:30"), listaCET1);
			Turno turno14 = new Turno(DateTime.Parse("2022-07-05"), "Viernes", DateTime.Parse("2022-07-05 11:30"), DateTime.Parse("2022-07-05 14:30"), listaCET1);
			Turno turno15 = new Turno(DateTime.Parse("2022-07-06"), "Lunes", DateTime.Parse("2022-07-06 11:30"), DateTime.Parse("2022-07-06 16:30"), listaCET1);
			Turno turno16 = new Turno(DateTime.Parse("2022-07-07"), "Martes", DateTime.Parse("2022-07-07 11:30"), DateTime.Parse("2022-07-07 12:30"), listaCET1);
			var listaTurnosRT5 = new List<Turno>();
			listaTurnosRT3.Add(turno9);
			listaTurnosRT3.Add(turno10);
			listaTurnosRT3.Add(turno11);
			listaTurnosRT3.Add(turno12);
			listaTurnosRT3.Add(turno13);
			listaTurnosRT3.Add(turno14);
			listaTurnosRT3.Add(turno15);
			listaTurnosRT3.Add(turno16);
			/*************************************************/

			/* Lista Turno asignacion */


			var TurnosCientifico1 = new List<Turno>();
			TurnosCientifico1.Add(turnos11);
			TurnosCientifico1.Add(turnos15);
			TurnosCientifico1.Add(turnos17);
			TurnosCientifico1.Add(turnos19);
			TurnosCientifico1.Add(turnos20);
			TurnosCientifico1.Add(turnos224);
			TurnosCientifico1.Add(turnos225);
			TurnosCientifico1.Add(turnos226);
			TurnosCientifico1.Add(turnos337);
			TurnosCientifico1.Add(turnos338);
			TurnosCientifico1.Add(turnos339);
			TurnosCientifico1.Add(turnos227);
			TurnosCientifico1.Add(turno);
			TurnosCientifico1.Add(turno2);
			TurnosCientifico1.Add(turno3);
			TurnosCientifico1.Add(turno4);
			TurnosCientifico1.Add(turno9);
			TurnosCientifico1.Add(turno10);
			TurnosCientifico1.Add(turno11);
			TurnosCientifico1.Add(turno12);
			var TurnosCientifico2 = new List<Turno>();
			TurnosCientifico2.Add(turnos12);
			TurnosCientifico2.Add(turnos13);
			TurnosCientifico2.Add(turnos16);
			TurnosCientifico2.Add(turnos21);
			TurnosCientifico2.Add(turnos229);
			TurnosCientifico2.Add(turnos220);
			TurnosCientifico2.Add(turnos2221);
			TurnosCientifico2.Add(turnos335);
			TurnosCientifico2.Add(turnos336);
			TurnosCientifico2.Add(turnos330);
			TurnosCientifico2.Add(turnos3312);
			TurnosCientifico2.Add(turnos3321);
			TurnosCientifico2.Add(turno5);
			TurnosCientifico2.Add(turno6);
			TurnosCientifico2.Add(turno14);
			TurnosCientifico2.Add(turno15);
			var TurnosCientifico3 = new List<Turno>();
			TurnosCientifico3.Add(turnos14);
			TurnosCientifico3.Add(turnos19);
			TurnosCientifico3.Add(turnos22);
			TurnosCientifico3.Add(turnos221);
			TurnosCientifico3.Add(turnos222);
			TurnosCientifico3.Add(turnos223);
			TurnosCientifico3.Add(turnos228);
			TurnosCientifico3.Add(turnos2222);
			TurnosCientifico3.Add(turnos331);
			TurnosCientifico3.Add(turnos332);
			TurnosCientifico3.Add(turnos333);
			TurnosCientifico3.Add(turnos334);
			TurnosCientifico3.Add(turno7);
			TurnosCientifico3.Add(turno8);
			TurnosCientifico3.Add(turno13);
			TurnosCientifico3.Add(turno16);


			// Mock Modelo y Marc
			var listaModelo1 = new List<Modelo>();
			Modelo modelo11 = new Modelo("AIO iMac MXWT2LE/A");
			Modelo modelo12 = new Modelo("MacBook Pro");
			Modelo modelo13 = new Modelo("*MacBook Super PRO");
			listaModelo1.Add(modelo11);
			listaModelo1.Add(modelo12);
			listaModelo1.Add(modelo13);
			var listaModelo2 = new List<Modelo>();
			Modelo modelo21 = new Modelo("Surface Laptop Studio");
			Modelo modelo22 = new Modelo("Surface Laptop Go");
			Modelo modelo23 = new Modelo("*Extra Max");
			listaModelo2.Add(modelo21);
			listaModelo2.Add(modelo22);
			listaModelo2.Add(modelo23);
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
			Modelo modelo53 = new Modelo("*Latitude 5560");
			listaModelo5.Add(modelo51);
			listaModelo5.Add(modelo52);
			listaModelo5.Add(modelo53);

			Marca marca1 = new Marca("Apple", listaModelo1);
			Marca marca2 = new Marca("Microsoft", listaModelo2);
			Marca marca3 = new Marca("Samsung", listaModelo3);
			Marca marca4 = new Marca("Hp", listaModelo4);
			Marca marca5 = new Marca("Dell", listaModelo5);

			// Mock Tipo Recurso Tecnologicos

			TipoRecursoTecnologico tipoRT1 = new TipoRecursoTecnologico("Notebook", "Recurso tecnologico notebook", null);
			TipoRecursoTecnologico tipoRT2 = new TipoRecursoTecnologico("PC", "Recurso tecnologico pc de escritorio", null);

			// Mock Recursos Tecnologicos
			RecursoTecnologico recursoTeconologico1 = new RecursoTecnologico(1, DateTime.Parse("2010-05-30"), "*", 30, 1, 30, modelo12, tipoRT2, null, null, null, listaCERT1, listaTurnosRT1);
			//RecursoTecnologico recursoTeconologico2 = new RecursoTecnologico(2, DateTime.Parse("2010-06-05"), "*", 30, 1, 30, modelo21, tipoRT1, null, null, null, listaCERT2, listaTurnosRT1);
			//RecursoTecnologico recursoTeconologico3 = new RecursoTecnologico(3, DateTime.Parse("2008-05-15"), "*", 30, 1, 30, modelo31, tipoRT1, null, null, null, listaCERT3, listaTurnosRT1);
			RecursoTecnologico recursoTeconologico4 = new RecursoTecnologico(4, DateTime.Parse("2005-06-05"), "*", 30, 1, 30, modelo41, tipoRT2, null, null, null, listaCERT4, listaTurnosRT2);
			//RecursoTecnologico recursoTeconologico5 = new RecursoTecnologico(5, DateTime.Parse("2015-05-04"), "*", 30, 1, 30, modelo51, tipoRT2, null, null, null, listaCERT5, listaTurnosRT1);
			//RecursoTecnologico recursoTeconologico6 = new RecursoTecnologico(6, DateTime.Parse("2020-01-05"), "*", 30, 1, 30, modelo52, tipoRT2, null, null, null, listaCERT6, listaTurnosRT1);
			RecursoTecnologico recursoTeconologico7 = new RecursoTecnologico(7, DateTime.Parse("2010-05-30"), "*", 30, 1, 30, modelo13, tipoRT1, null, null, null, listaCERT1, listaTurnosRT3);
			RecursoTecnologico recursoTeconologico8 = new RecursoTecnologico(8, DateTime.Parse("2010-05-30"), "*", 30, 1, 30, modelo23, tipoRT1, null, null, null, listaCERT1, listaTurnosRT4);
			RecursoTecnologico recursoTeconologico9 = new RecursoTecnologico(9, DateTime.Parse("2010-05-30"), "*", 30, 1, 30, modelo53, tipoRT2, null, null, null, listaCERT1, listaTurnosRT5);
			listaRT = new List<RecursoTecnologico>();
            listaRT.Add(recursoTeconologico1);
			//listaRT.Add(recursoTeconologico2);
			//listaRT.Add(recursoTeconologico3);
			listaRT.Add(recursoTeconologico4);
			//listaRT.Add(recursoTeconologico5);
			//listaRT.Add(recursoTeconologico6);
			listaRT.Add(recursoTeconologico7);
			listaRT.Add(recursoTeconologico8);
			listaRT.Add(recursoTeconologico9);

			// Mock AsignacionesResponsableTecnicoRT
			listaAsignaciones = new List<AsignacionResponsableTecnicoRT>();
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico1, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), null, personalCientifico1, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico2, listaRT));
			listaAsignaciones.Add(new AsignacionResponsableTecnicoRT(DateTime.Parse("2009-05-05"), null, personalCientifico3, listaRT));

			// Mock AsignacionesResponsableTecnicoRT
			listaAsignacionesCT = new List<AsignacionCientificoDelCI>();
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), DateTime.Parse("2009-05-05"), personalCientifico1, TurnosCientifico1));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico1, TurnosCientifico1));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico2, TurnosCientifico2));
			listaAsignacionesCT.Add(new AsignacionCientificoDelCI(DateTime.Parse("2009-05-05"), null, personalCientifico3, TurnosCientifico3));


			// Mock session
			Usuario user = new Usuario("admin", "root", 0, personalCientifico1);
			Sesion sesion = new Sesion();
			sesion.FechaInicio = DateTime.Parse("2009-05-05");
			sesion.HoraInicio = TimeSpan.Parse("09:00:00");
			sesion.Usuario = user;
			this.sesion = sesion;
		}

		/**************************************************************** Primera parte ***********************************************************************/

		/* El usuario ingresa a la opcion Registrar RT mantenimiento */
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
			List<DatosPantallaRT> rtInfo = RespTecRT.getMisRT();
			return rtInfo;
		}

		/* Agrupa los RT por tipo de Recurso */
		public IEnumerable<IGrouping<string, DatosPantallaRT>> agruparRTTipoRecurso(List<DatosPantallaRT> RTPantalla)
		{
			return from rt in RTPantalla group rt by rt.TipoRecursoTecnologico;
		}

		/*********************************************************** Segunda Parte ****************************************************************************/

		/* Toma la selleccion del rt definido por el usuario */
		public void tomarSeleccionRT(int numeroRtSelect)
		{
			foreach (RecursoTecnologico rt in this.listaRT)
			{
				if (rt.NumeroRT == numeroRtSelect)
				{
					this.rtSeleccionado = rt;
				}
			}
		}

		/* Toma la fecha de Fin prevista de mantenimiento*/
		public void tomarFechaFinPrevista(DateTime fecha)
		{
			this.fechaFinPrevista = fecha;
		}

		/* toma el motivo de mantenimiento */
		public IEnumerable<IGrouping<int, DatosPantallaTurnos>> tomarMotivo(string motivo)
		{
			this.motivo = motivo;
			this.now = obtenerFechaHoraActual();
			return buscarTurnosCancelablesEnPeriodo(this.rtSeleccionado, this.fechaFinPrevista);
		}

		/* Obtiene la fecha y hora actual */
		public DateTime obtenerFechaHoraActual()
        {
			return DateTime.Now;
        }

		/* Busca los turnos de dicho RT que esten comprendidos en la fecha prevista*/
		public IEnumerable<IGrouping<int, DatosPantallaTurnos>> buscarTurnosCancelablesEnPeriodo(RecursoTecnologico rt, DateTime fecha)
        {
			this.datosTurnosXcientificos = rt.obtenerTurnosCancelablesEnPeriodo(fecha,this.listaAsignacionesCT);
			return ordenarTurnosXCientifico(datosTurnosXcientificos);
		}

		/* Agrupa los turnos por cientificos*/
		public IEnumerable<IGrouping<int, DatosPantallaTurnos>> ordenarTurnosXCientifico(List<DatosPantallaTurnos> CTPantalla)
		{
			return from tur in CTPantalla group tur by tur.PersonalCientifico.Legajo;
		}


		/*********************************************************** Tercera parte ****************************************************************************/


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



		public List<RecursoTecnologico> obtenerRT()
        {
			return listaRT;
		}
	}
}