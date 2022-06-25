using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CambioEstadoTurno {

	private DateTime fechaHoraDesde;
	private DateTime? fechaHoraHasta;
    private Estado estado;

    public CambioEstadoTurno(DateTime fechaHoraDesde, DateTime? fechaHoraHasta, Estado estado)
    {
        this.fechaHoraDesde = fechaHoraDesde;
        this.fechaHoraHasta = fechaHoraHasta;
        this.estado = estado;
    }

    public DateTime FechaHoraDesde { get => fechaHoraDesde; set => fechaHoraDesde = value; }
    public DateTime? FechaHoraHasta { get => fechaHoraHasta; set => fechaHoraHasta = value; }
    public Estado Estado { get => estado; set => estado = value; }

    public Boolean esVigente()
    {
        if (this.fechaHoraHasta == null)
        {
            return true;
        }
        return false;
    }

    public Boolean esReservadoOPendiente()
    {
        if (this.Estado.esReservadoOPendiente())
        {
            return true;
        }
        return false;
    }

    public void setFechaFin()
    {
        this.fechaHoraHasta = DateTime.Now;
    }
}