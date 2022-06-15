using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class AsignacionResponsableTecnicoRT {

	private DateTime fechaDesde;
	private DateTime fechaHasta;
    private PersonalCientífico personalCientífico;
    private RecursoTecnologico recursoTecnologico;

    public AsignacionResponsableTecnicoRT(DateTime fechaDesde, DateTime fechaHasta, PersonalCientífico personalCientífico, RecursoTecnologico recursoTecnologico)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCientífico = personalCientífico;
        this.recursoTecnologico = recursoTecnologico;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCientífico PersonalCientífico { get => personalCientífico; set => personalCientífico = value; }
    public RecursoTecnologico RecursoTecnologico { get => recursoTecnologico; set => recursoTecnologico = value; }

}