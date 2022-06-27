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

    /* Pregunta si el cambio de estado RT es el actual  */
    public Boolean esActual()
    {
        if (this.fechaHoraHasta == null)
        {
            return true;
        }
        return false;
    }

    /* Pregunta si el estado actual del RT es disponible */
    public Boolean esDisponible()
    {
        if(this.Estado.esDisponible())
        {
            return true;
        }
        return false;
    }
}