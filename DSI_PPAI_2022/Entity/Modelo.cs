using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSI_PPAI_2022.Resource;

public class Modelo {

	private string nombre;

    public Modelo(string nombre)
    {
        this.nombre = nombre;
    }

    public string Nombre { get => nombre; set => nombre = value; }

    public ModeloYMarca getModeloYmarca()
    {

		ModeloYMarca dato = new ModeloYMarca();
        dato.Modelo = getNombre();
        Marca dato2 = new Marca();
        dato.Marca = dato2.getMarca(getNombre());
        return dato;
    }

    public string getNombre()
    {
        return this.nombre;
    }
}