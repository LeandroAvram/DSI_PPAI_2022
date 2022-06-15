using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class TipoRecursoTecnologico {

	private string nombre;
	private string descripci�n;
    private Caracter�stica caracter�stica;

    public TipoRecursoTecnologico(string nombre, string descripci�n, Caracter�stica caracter�stica)
    {
        this.nombre = nombre;
        this.descripci�n = descripci�n;
        this.caracter�stica = caracter�stica;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripci�n { get => descripci�n; set => descripci�n = value; }
    public Caracter�stica Caracter�stica { get => caracter�stica; set => caracter�stica = value; }
}