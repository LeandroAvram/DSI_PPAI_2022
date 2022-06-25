using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSI_PPAI_2022.Resource
{
    public class FechaHoraTurnos
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;

        public FechaHoraTurnos(DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            this.FechaHoraInicio = fechaHoraInicio;
            this.FechaHoraFin = fechaHoraFin;
        }

        public DateTime FechaHoraInicio { get => fechaHoraInicio; set => fechaHoraInicio = value; }
        public DateTime FechaHoraFin { get => fechaHoraFin; set => fechaHoraFin = value; }
    }
}
