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


    /* Retorna los atributos modelo y marca del RT en cuestion*/
    public ModeloYMarca getModeloYmarca()
    {
		ModeloYMarca dato = new ModeloYMarca();
        Marca dato2 = new Marca();
        dato.Modelo = getNombre();
        dato.Marca = dato2.getMarca(getNombre());
        return dato;
    }

    /* Retorna solo el nombre del Modelo del RT en cuestion */
    public string getNombre()
    {
        return this.nombre;
    }
}