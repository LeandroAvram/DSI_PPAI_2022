using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



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
    private CambioEstadoRT cambioEstadoRT;
    private Turno turno;

    public RecursoTecnologico(int numeroRT, DateTime fechaAlta, string imagenes, int periodicidadMantenimientoPrev, int duracionMantenimientoPrev, int fraccionHorarioTurnos, Modelo modelo, TipoRecursoTecnologico tipoRecursoTecnologico, CaracteristicaRecurso caracteristicaRecurso, Mantenimiento mantenimiento, HorarioRT horarioRT, CambioEstadoRT cambioEstadoRT, Turno turno)
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
    public CambioEstadoRT CambioEstadoRT { get => cambioEstadoRT; set => cambioEstadoRT = value; }
    public Turno Turno { get => turno; set => turno = value; }
}