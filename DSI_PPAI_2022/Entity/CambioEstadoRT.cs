using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CambioEstadoRT {

	private DateTime fechaHoraDesde;
	private DateTime? fechaHoraHasta;
    private Estado estado;
    public CambioEstadoRT(DateTime fechaHoraDesde, DateTime? fechaHoraHasta, Estado estado)
    {
        this.FechaHoraDesde = fechaHoraDesde;
        this.FechaHoraHasta = fechaHoraHasta;
        Estado = estado;
    }

    public DateTime FechaHoraDesde { get => fechaHoraDesde; set => fechaHoraDesde = value; }
    public DateTime? FechaHoraHasta { get => fechaHoraHasta; set => fechaHoraHasta = value; }
    public Estado Estado { get => estado; set => estado = value; }

    public Boolean esActual()
    {
        if (this.fechaHoraHasta == null)
        {
            return true;
        }
        return false;
    }

    public Boolean esDisponible()
    {
        if(this.Estado.esDisponible())
        {
            return true;
        }
        return false;
    }
}