using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Mantenimiento {

	private DateTime fechaFin;
	private DateTime fechaInicio;
	private DateTime fechaInicioPrevista;
	private string motivoMantenimiento;
    private ExtensionMantenimiento? extensionMantenimiento;

    public Mantenimiento(DateTime fechaFin, DateTime fechaInicio, DateTime fechaInicioPrevista, string motivoMantenimiento, ExtensionMantenimiento? extensionMantenimiento)
    {
        this.fechaFin = fechaFin;
        this.fechaInicio = fechaInicio;
        this.fechaInicioPrevista = fechaInicioPrevista;
        this.motivoMantenimiento = motivoMantenimiento;
        this.extensionMantenimiento = extensionMantenimiento;
    }

    public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
    public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
    public DateTime FechaInicioPrevista { get => fechaInicioPrevista; set => fechaInicioPrevista = value; }
    public string MotivoMantenimiento { get => motivoMantenimiento; set => motivoMantenimiento = value; }
    public ExtensionMantenimiento? ExtensionMantenimiento { get => extensionMantenimiento; set => extensionMantenimiento = value; }
}