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

    /* Retorna true si esa asignacion es de ese usuario y esta vigente */
    public Boolean esDeUsuarioLogueadoYVigente(PersonalCientífico personal, AsignacionResponsableTecnicoRT RespTecRT)
    {
        if (RespTecRT.personalCientífico == personal && esVigente(RespTecRT))
        {
            return true;
        }
        return false;
    }

    /*Valida que dicha asignacion enviada por parametro este vigente*/
    public Boolean esVigente(AsignacionResponsableTecnicoRT RespTecRT)
    {
        if(RespTecRT.fechaHasta == null)
        {
            return true;
        }
        return false;
    }

    /* Busca todos los RT de dicha asignacion, que estan disponibles y que el cambio de estado sea el actual retornando los datos necesarios para motrar en pantalla  */
    public List<DatosPantallaRT> getMisRT()
    {
        List<DatosPantallaRT> lista = new List<DatosPantallaRT>();
        foreach (RecursoTecnologico RT in this.RecursoTecnologico)
        {
            if (RT.estaDisponible())
            {
                lista.Add(RT.mostrarRT());
            }
        }

        return lista;
    }
}