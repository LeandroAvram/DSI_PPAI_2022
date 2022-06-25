using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSI_PPAI_2022.Resource
{
    public class DatosPantallaTurnos
    {
        DateTime fechaInicioTurno;
        DateTime fechaFinTurno;
        PersonalCientífico personalCientifico;

        public DateTime FechaInicioTurno { get => fechaInicioTurno; set => fechaInicioTurno = value; }
        public DateTime FechaFinTurno { get => fechaFinTurno; set => fechaFinTurno = value; }
        public PersonalCientífico PersonalCientifico { get => personalCientifico; set => personalCientifico = value; }
    }
}
