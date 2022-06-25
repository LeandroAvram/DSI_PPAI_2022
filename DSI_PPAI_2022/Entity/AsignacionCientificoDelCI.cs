using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class AsignacionCientificoDelCI {

	private DateTime fechaDesde;
	private DateTime? fechaHasta;
    private PersonalCientífico personalCientífico;
    private List<Turno> turno;

    public AsignacionCientificoDelCI(DateTime fechaDesde, DateTime? fechaHasta, PersonalCientífico personalCientífico, List<Turno> turno)
    {
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.personalCientífico = personalCientífico;
        this.turno = turno;
    }

    public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    public DateTime? FechaHasta { get => fechaHasta; set => fechaHasta = value; }
    public PersonalCientífico PersonalCientífico { get => personalCientífico; set => personalCientífico = value; }
    public List<Turno> Turno { get => turno; set => turno = value; }


    public PersonalCientífico getCientificoDelCI()
    {
        return PersonalCientífico;
    }
}