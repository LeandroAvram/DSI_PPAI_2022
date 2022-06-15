using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class AsignacionResponsableTecnicoRT {

	private DateTime fechaDesde;
	private DateTime fechaHasta;
    private PersonalCient�fico personalCient�fico;
    private RecursoTecnologico recursoTecnologico;

    public AsignacionResponsableTecnicoRT(DateTime fechaDesde, DateTime fechaHasta, PersonalCient�fico personalCient�fico, RecursoTecnologico recursoTecnologico)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCient�fico = personalCient�fico;
        this.recursoTecnologico = recursoTecnologico;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCient�fico PersonalCient�fico { get => personalCient�fico; set => personalCient�fico = value; }
    public RecursoTecnologico RecursoTecnologico { get => recursoTecnologico; set => recursoTecnologico = value; }

}