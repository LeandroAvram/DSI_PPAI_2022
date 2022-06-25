using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

public class AsignacionResponsableTecnicoRT {

	private DateTime fechaDesde;
	private DateTime? fechaHasta;
    private PersonalCientífico personalCientífico;
    private List<RecursoTecnologico> recursoTecnologico;

    public AsignacionResponsableTecnicoRT(DateTime fechaDesde, DateTime? fechaHasta, PersonalCientífico personalCientífico, List<RecursoTecnologico> recursoTecnologico)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCientífico = personalCientífico;
        this.recursoTecnologico = recursoTecnologico;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime? FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCientífico PersonalCientífico { get => personalCientífico; set => personalCientífico = value; }
    public List<RecursoTecnologico> RecursoTecnologico { get => recursoTecnologico; set => recursoTecnologico = value; }

    public Boolean esDeUsuarioLogueadoYVigente(PersonalCientífico personal, AsignacionResponsableTecnicoRT RespTecRT)
    {
        if (RespTecRT.personalCientífico == personal&& RespTecRT.fechaHasta == null)
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