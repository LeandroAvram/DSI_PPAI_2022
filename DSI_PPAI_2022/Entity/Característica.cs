using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Característica {

	private string nombre;
	private string descripcion;

    public Característica(string nombre, string descripcion)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}