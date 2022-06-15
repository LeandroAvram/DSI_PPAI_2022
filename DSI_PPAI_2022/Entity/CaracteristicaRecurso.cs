using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CaracteristicaRecurso {

	private int valor;
    private Característica característica;

    public CaracteristicaRecurso(int valor, Característica característica)
    {
        this.valor = valor;
        this.característica = característica;
    }

    public int Valor { get => valor; set => valor = value; }
    public Característica Característica { get => característica; set => característica = value; }
}