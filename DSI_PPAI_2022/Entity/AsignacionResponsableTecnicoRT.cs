using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

public class AsignacionResponsableTecnicoRT {

	private DateTime fechaDesde;
	private DateTime? fechaHasta;
    private PersonalCient�fico personalCient�fico;
    private List<RecursoTecnologico> recursoTecnologico;

    public AsignacionResponsableTecnicoRT(DateTime fechaDesde, DateTime? fechaHasta, PersonalCient�fico personalCient�fico, List<RecursoTecnologico> recursoTecnologico)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCient�fico = personalCient�fico;
        this.recursoTecnologico = recursoTecnologico;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime? FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCient�fico PersonalCient�fico { get => personalCient�fico; set => personalCient�fico = value; }
    public List<RecursoTecnologico> RecursoTecnologico { get => recursoTecnologico; set => recursoTecnologico = value; }

    public Boolean esDeUsuarioLogueadoYVigente(PersonalCient�fico personal, AsignacionResponsableTecnicoRT RespTecRT)
    {
        if (RespTecRT.personalCient�fico == personal&& RespTecRT.fechaHasta == null)
        {
            return true;
        }
        return false;
    }

    public List<DatosPantallaRT> getMisRT()
    {
        List<DatosPantallaRT> lista3 = new List<DatosPantallaRT>();
        foreach (RecursoTecnologico RT in this.RecursoTecnologico)
        {
            if (RT.estaDisponible())
            {
                lista3.Add(RT.mostrarRT());
            }
        }

        return lista3;
    }
}