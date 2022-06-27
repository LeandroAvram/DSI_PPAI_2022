using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

public class Turno {

	private DateTime fechaGeneracion;
	private string diaSemana;
	private DateTime fechaHoraInicio;
	private DateTime fechaHoraFin;
    private List<CambioEstadoTurno>  cambioEstadoTurno;

    public Turno(DateTime fechaGeneracion, string diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurno)
    {
        this.FechaGeneracion = fechaGeneracion;
        this.DiaSemana = diaSemana;
        this.FechaHoraInicio = fechaHoraInicio;
        this.FechaHoraFin = fechaHoraFin;
        CambioEstadoTurno = cambioEstadoTurno;
    }

    public DateTime FechaGeneracion { get => fechaGeneracion; set => fechaGeneracion = value; }
    public string DiaSemana { get => diaSemana; set => diaSemana = value; }
    public DateTime FechaHoraInicio { get => fechaHoraInicio; set => fechaHoraInicio = value; }
    public DateTime FechaHoraFin { get => fechaHoraFin; set => fechaHoraFin = value; }
    public List<CambioEstadoTurno> CambioEstadoTurno { get => cambioEstadoTurno; set => cambioEstadoTurno = value; }

    public Boolean esPlazoDeMantenimiento(DateTime fechaFin)
    {
        var result = DateTime.Compare(DateTime.Now, this.fechaHoraInicio);
        var result2 = DateTime.Compare(fechaFin, this.fechaHoraFin);
        if (result<=0&& result2>=0)
        {
            return true;
        }
        return false;
    }

    public Boolean estaReservadoOPendiente()
    {
        foreach (CambioEstadoTurno cambioEstadoTurno in CambioEstadoTurno)
        {
            if (cambioEstadoTurno.esVigente())
            {
                if (cambioEstadoTurno.esReservadoOPendiente())
                {
                    return true;
                }
            }

        }
        return false;
    }

    public DatosPantallaTurnos getTurnoCientifico(AsignacionCientificoDelCI asignacion)
    {
        DatosPantallaTurnos data = new DatosPantallaTurnos();
        data.FechaInicioTurno = this.fechaHoraInicio;
        data.FechaFinTurno = this.FechaHoraFin;
        data.PersonalCientifico = asignacion.getCientificoDelCI();
        return data;
    }

    public FechaHoraTurnos getFechatHora()
    {
        return new(FechaHoraInicio, FechaHoraFin);
    }
    
    public void cancelarTurno(Estado enCancelado)
    {
        foreach (CambioEstadoTurno cambioEstadoTurno in CambioEstadoTurno)
        {
            if (cambioEstadoTurno.esVigente())
            {
                cambioEstadoTurno.setFechaFin();
            }

        }
        this.cambioEstadoTurno.Add(new CambioEstadoTurno(DateTime.Now, null, enCancelado));
    }
}