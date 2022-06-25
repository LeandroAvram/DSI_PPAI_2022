using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class AsignacionCientificoDelCI {

	private DateTime fechaDesde;
	private DateTime? fechaHasta;
    private PersonalCient�fico personalCient�fico;
    private List<Turno> turno;

    public AsignacionCientificoDelCI(DateTime fechaDesde, DateTime? fechaHasta, PersonalCient�fico personalCient�fico, List<Turno> turno)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCient�fico = personalCient�fico;
        this.turno = turno;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime? FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCient�fico PersonalCient�fico { get => personalCient�fico; set => personalCient�fico = value; }
    public List<Turno> Turno { get => turno; set => turno = value; }


    public PersonalCient�fico getCientificoDelCI()
    {
        return PersonalCient�fico;
    }
}