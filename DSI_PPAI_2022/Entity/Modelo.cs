using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Modelo {

	private string nombre;

    public Modelo(string nombre)
    {
        this.nombre = nombre;
    }

    public string Nombre { get => nombre; set => nombre = value; }
}