using DSI_PPAI_2022.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSI_PPAI_2022
{
    public partial class PantallaRegistroRTMantenimiento : Form
    {
        private GestorDeRegistroRTMantenimiento gestor;
        private RecursoTecnologico RTseleccionado;
        public PantallaRegistroRTMantenimiento()
        {
            InitializeComponent();
            gestor = new GestorDeRegistroRTMantenimiento();
            var data = gestor.opcionRegistrarIngresoRTMantenimientoCorrectivo();
            foreach (var group in data)
            {
                var groupKey = group.Key;
                foreach (var d in group)
                {
                    DatosPantallaRT elemento = d;
                }
            }

        }

        private void PantallaRegistroRTMantenimiento_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoRT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        private void grillaRTDisponibles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            datagridviewcell
        }*/
    }
}
