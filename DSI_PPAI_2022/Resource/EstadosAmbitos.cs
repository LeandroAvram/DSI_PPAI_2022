using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSI_PPAI_2022.Resource
{
    public class EstadosAmbitos
    {
        Estado estado;

        public EstadosAmbitos(Estado estado)
        {
            this.estado = estado;
        }

        public Estado Estado { get => estado; set => estado = value; }
    }
}
