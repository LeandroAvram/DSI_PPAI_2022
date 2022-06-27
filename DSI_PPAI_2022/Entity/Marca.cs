using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Marca {

	private string nombre;
	private List<Modelo> m_Modelo;

    public Marca(string nombre, List<Modelo> modelo)
    {
        this.Nombre = nombre;
        Modelo = modelo;
    }
    public Marca()
    {
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public List<Modelo> Modelo { get => m_Modelo; set => m_Modelo = value; }

	/* Retorna el nombre de la marca del modelo enviado por parametro */
    public string getMarca(string modelo)
    {
		/***Mock*/
		var listaModelo1 = new List<Modelo>();
		Modelo modelo11 = new Modelo("AIO iMac MXWT2LE/A");
		Modelo modelo12 = new Modelo("MacBook Pro");
		Modelo modelo13 = new Modelo("*MacBook Super PRO");
		listaModelo1.Add(modelo11);
		listaModelo1.Add(modelo12);
		listaModelo1.Add(modelo13);
		var listaModelo2 = new List<Modelo>();
		Modelo modelo21 = new Modelo("Surface Laptop Studio");
		Modelo modelo22 = new Modelo("Surface Laptop Go");
		Modelo modelo23 = new Modelo("*Extra Max");
		listaModelo2.Add(modelo21);
		listaModelo2.Add(modelo22);
		listaModelo2.Add(modelo23);
		var listaModelo3 = new List<Modelo>();
		Modelo modelo31 = new Modelo("Notebook 9 Pro");
		Modelo modelo32 = new Modelo("Notebook 9 Flash");
		listaModelo3.Add(modelo31);
		listaModelo3.Add(modelo32);
		var listaModelo4 = new List<Modelo>();
		Modelo modelo41 = new Modelo("Pavilion");
		Modelo modelo42 = new Modelo("OMEN 16-b0507la");
		listaModelo4.Add(modelo41);
		listaModelo4.Add(modelo42);
		var listaModelo5 = new List<Modelo>();
		Modelo modelo51 = new Modelo("Latitude 5410");
		Modelo modelo52 = new Modelo("Vostro Business Flagship");
		Modelo modelo53 = new Modelo("*Latitude 5560");
		listaModelo5.Add(modelo51);
		listaModelo5.Add(modelo52);
		listaModelo5.Add(modelo53);

		Marca marca1 = new Marca("Apple", listaModelo1);
		Marca marca2 = new Marca("Microsoft", listaModelo2);
		Marca marca3 = new Marca("Samsung", listaModelo3);
		Marca marca4 = new Marca("Hp", listaModelo4);
		Marca marca5 = new Marca("Dell", listaModelo5);

		var marcas = new List<Marca>();
		marcas.Add(marca1);
		marcas.Add(marca2);
		marcas.Add(marca3);
		marcas.Add(marca4);
		marcas.Add(marca5);
		/****/

		foreach (Marca marca in marcas)
        {
			foreach (Modelo modeloName in marca.Modelo)
            {
				if(modeloName.Nombre == modelo)
                {
				return marca.Nombre;
                }
            }
        }
		return "";
	}
}