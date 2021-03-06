using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CaracteristicaRecurso {

	private int valor;
    private CaracterÝstica caracterÝstica;

    public CaracteristicaRecurso(int valor, CaracterÝstica caracterÝstica)
    {
        this.valor = valor;
        this.caracterÝstica = caracterÝstica;
    }

    public int Valor { get => valor; set => valor = value; }
    public CaracterÝstica CaracterÝstica { get => caracterÝstica; set => caracterÝstica = value; }
}