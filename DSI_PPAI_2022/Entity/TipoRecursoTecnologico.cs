using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class TipoRecursoTecnologico {

	private string nombre;
	private string descripción;
    private Característica característica;

    public TipoRecursoTecnologico(string nombre, string descripción, Característica característica)
    {
        this.nombre = nombre;
        this.descripción = descripción;
        this.característica = característica;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripción { get => descripción; set => descripción = value; }
    public Característica Característica { get => característica; set => característica = value; }
}