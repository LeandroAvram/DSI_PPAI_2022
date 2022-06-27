using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

public class RecursoTecnologico {

	private int numeroRT;
	private DateTime fechaAlta;
	private string imagenes;
	private int periodicidadMantenimientoPrev;
	private int duracionMantenimientoPrev;
	private int fraccionHorarioTurnos;
    private Modelo modelo;
    private TipoRecursoTecnologico tipoRecursoTecnologico;
    private CaracteristicaRecurso caracteristicaRecurso;
    private Mantenimiento mantenimiento;
    private HorarioRT horarioRT;
    private List<CambioEstadoRT> cambioEstadoRT;
    private List<Turno> turno;

    public RecursoTecnologico(int numeroRT, DateTime fechaAlta, string imagenes, int periodicidadMantenimientoPrev, int duracionMantenimientoPrev, int fraccionHorarioTurnos, Modelo modelo, TipoRecursoTecnologico tipoRecursoTecnologico, CaracteristicaRecurso caracteristicaRecurso, Mantenimiento mantenimiento, HorarioRT horarioRT, List<CambioEstadoRT> cambioEstadoRT, List<Turno> turno)
    {
        this.numeroRT = numeroRT;
        this.fechaAlta = fechaAlta;
        this.imagenes = imagenes;
        this.periodicidadMantenimientoPrev = periodicidadMantenimientoPrev;
        this.duracionMantenimientoPrev = duracionMantenimientoPrev;
        this.fraccionHorarioTurnos = fraccionHorarioTurnos;
        this.modelo = modelo;
        this.tipoRecursoTecnologico = tipoRecursoTecnologico;
        this.caracteristicaRecurso = caracteristicaRecurso;
        this.mantenimiento = mantenimiento;
        this.horarioRT = horarioRT;
        this.cambioEstadoRT = cambioEstadoRT;
        this.turno = turno;
    }

    public int NumeroRT { get => numeroRT; set => numeroRT = value; }
    public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    public string Imagenes { get => imagenes; set => imagenes = value; }
    public int PeriodicidadMantenimientoPrev { get => periodicidadMantenimientoPrev; set => periodicidadMantenimientoPrev = value; }
    public int DuracionMantenimientoPrev { get => duracionMantenimientoPrev; set => duracionMantenimientoPrev = value; }
    public int FraccionHorarioTurnos { get => fraccionHorarioTurnos; set => fraccionHorarioTurnos = value; }
    public Modelo Modelo { get => modelo; set => modelo = value; }
    public TipoRecursoTecnologico TipoRecursoTecnologico { get => tipoRecursoTecnologico; set => tipoRecursoTecnologico = value; }
    public CaracteristicaRecurso CaracteristicaRecurso { get => caracteristicaRecurso; set => caracteristicaRecurso = value; }
    public Mantenimiento Mantenimiento { get => mantenimiento; set => mantenimiento = value; }
    public HorarioRT HorarioRT { get => horarioRT; set => horarioRT = value; }
    public List<CambioEstadoRT> CambioEstadoRT { get => cambioEstadoRT; set => cambioEstadoRT = value; }
    public List<Turno> Turno { get => turno; set => turno = value; }


    /* Valida que el ultimo cambio de estado apunte a estado disponible */
    public Boolean estaDisponible()
    {
        foreach (CambioEstadoRT resp in this.cambioEstadoRT)
        {
            if (resp.esActual())
            {
                if (resp.esDisponible())
                {
                    return true;
                }
            }
            
        }
        return false;
    }


    /* Busca, Obtiene y arma los datos necesarios para devolver al gestor */
    public DatosPantallaRT mostrarRT()
    {
        DatosPantallaRT datos = new DatosPantallaRT();
        datos.TipoRecursoTecnologico = this.TipoRecursoTecnologico.mostrarTipoRecurso();
        datos.NumeroRT = getNumeroRT();
        ModeloYMarca datos2 = new ModeloYMarca();
        datos2 = this.Modelo.getModeloYmarca();
        datos.Modelo = datos2.Modelo;
        datos.Marca = datos2.Marca;
        return datos;
    }

    /* Obtiene el numero del RT */
    public int getNumeroRT()
    {
        return this.NumeroRT;
    }


    public List<DatosPantallaTurnos> obtenerTurnosCancelablesEnPeriodo(DateTime fechaMantenimiento, List<AsignacionCientificoDelCI> asignaciones)
    {
        List<DatosPantallaTurnos> datos = new List<DatosPantallaTurnos>();
        AsignacionCientificoDelCI asignacionDelTurno = null;
        foreach (Turno turno in this.turno)
        {
            if (turno.esPlazoDeMantenimiento(fechaMantenimiento))
            {
                if (turno.estaReservadoOPendiente())
                {
                    foreach (AsignacionCientificoDelCI asignacion in asignaciones)
                    {
                        foreach (var turnosASig in asignacion.Turno)
                        {
                                if (turno == turnosASig)
                                {
                                  asignacionDelTurno = asignacion;
                                }
                        }

                    }
                    datos.Add(turno.getTurnoCientifico(asignacionDelTurno));
                }
            }
        }
        return datos;
    }

    public AsignacionCientificoDelCI asignacionActaul(List<AsignacionCientificoDelCI> asignaciones)
    {
        foreach (AsignacionCientificoDelCI asignacion in asignaciones)
        {
            foreach(var turnosASig in asignacion.Turno)
            {
                foreach(var turnos in this.Turno)
                {
                    if (turnos == turnosASig)
                    {
                        return asignacion;
                    }
                }   
            }
            
        }
        return null;
    }

    public void ingresarAmantenimientoCorrectivo(Estado enMantenimiento, DateTime fechafinM, string motivoMatenim)
    {
        CambioEstadoRT actual;
        foreach(var ceRT in this.CambioEstadoRT)
        {
            if (ceRT.esActual())
            {
                ceRT.FechaHoraHasta = DateTime.Now;
            }
        }
        this.CambioEstadoRT.Add(new CambioEstadoRT(DateTime.Now,null, enMantenimiento));
        this.mantenimiento = new Mantenimiento(fechafinM,DateTime.Now,fechafinM,motivoMatenim,null);
    }


    public void cancelarTurnoConReserva(Estado enCancelado)
    {
       foreach(var tur in this.turno)
        {
            tur.cancelarTurno(enCancelado);
        }
    }
}