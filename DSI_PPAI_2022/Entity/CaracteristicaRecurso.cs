using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CaracteristicaRecurso {

	private int valor;
    private Caracter�stica caracter�stica;

    public CaracteristicaRecurso(int valor, Caracter�stica caracter�stica)
    {
        this.valor = valor;
        this.caracter�stica = caracter�stica;
    }

    public int Valor { get => valor; set => valor = value; }
    public Caracter�stica Caracter�stica { get => caracter�stica; set => caracter�stica = value; }
}