using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Estado {

	private string nombre;
	private string descripcion;
	private string ambito;
	private int esReservable;
    private int esCancelable;

    public Estado(string nombre, string descripcion, string ambito, int esReservable, int esCancelable)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.Ambito = ambito;
        this.EsReservable = esReservable;
        this.EsCancelable = esCancelable;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Ambito { get => ambito; set => ambito = value; }
    public int EsReservable { get => esReservable; set => esReservable = value; }
    public int EsCancelable { get => esCancelable; set => esCancelable = value; }

    public Boolean esDisponible()
    {
        if(this.Nombre == "Disponible")
        {
            return true;
        }
        return false;
    }
}