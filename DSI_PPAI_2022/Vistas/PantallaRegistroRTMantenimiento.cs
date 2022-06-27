using DSI_PPAI_2022.Resource;
using DSI_PPAI_2022.Vistas;
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
        IEnumerable<IGrouping<string, DatosPantallaRT>> dataRT;
        IEnumerable<IGrouping<string, DatosPantallaRT>> dataTurnos;
        private int nroRTseleccionado;
        
        public PantallaRegistroRTMantenimiento()
        {
            InitializeComponent();
            this.gestor = new GestorDeRegistroRTMantenimiento();
            this.dataRT = gestor.opcionRegistrarIngresoRTMantenimientoCorrectivo();
            
            cargarComboTipoRT(this.dataRT);

        }

        private void PantallaRegistroRTMantenimiento_Load(object sender, EventArgs e)
        {
            
        }

       // private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{

      //  }

        private void cmbTipoRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tipoRT = ( cmbTipoRT.GetItemText(cmbTipoRT.SelectedItem));
            grillaRTDisponibles.Rows.Clear();
            foreach (var group in this.dataRT)
            {
                var groupKey = group.Key;
                //cmbTipoRT.Items.Add(groupKey);
                foreach (var d in group)
                {
                    DatosPantallaRT elemento = d;
                    if (elemento.TipoRecursoTecnologico == tipoRT)
                    {
                        DataGridViewRow fila = new DataGridViewRow();
                        DataGridViewTextBoxCell celdaNroRT = new DataGridViewTextBoxCell();
                        celdaNroRT.Value = d.NumeroRT;
                        fila.Cells.Add(celdaNroRT);

                        DataGridViewTextBoxCell celdaMarcaRT = new DataGridViewTextBoxCell();
                        celdaMarcaRT.Value = d.Marca;
                        fila.Cells.Add(celdaMarcaRT);

                        DataGridViewTextBoxCell celdaModeloRT = new DataGridViewTextBoxCell();
                        celdaModeloRT.Value = d.Modelo
                         ;
                        fila.Cells.Add(celdaModeloRT);

                        grillaRTDisponibles.Rows.Add(fila);
                    }


                }
            }
        }
        private void limpiarGrilla()
        {
            
        }
        private void cargarComboTipoRT(IEnumerable<IGrouping<string, DatosPantallaRT>>  dataRT)
        {
            foreach (var group in dataRT)
            {
                var groupKey = group.Key;
                cmbTipoRT.Items.Add(groupKey);
                foreach (var d in group)
                {
                    DatosPantallaRT elemento = d;
                    
                }
            }
        }
        private void cargarGrillaRT(IEnumerable<IGrouping<string, DatosPantallaRT>> dataRT,string tipoRT)
        {
            foreach (var group in dataRT)
            {
                var groupKey = group.Key;
                //cmbTipoRT.Items.Add(groupKey);
                foreach (var d in group)
                {
                        DatosPantallaRT elemento = d;
                    if (elemento.TipoRecursoTecnologico == tipoRT)
                    {
                        DataGridViewRow fila = new DataGridViewRow();
                        DataGridViewTextBoxCell celdaNroRT = new DataGridViewTextBoxCell();
                        celdaNroRT.Value = d.NumeroRT;
                        fila.Cells.Add(celdaNroRT);

                        DataGridViewTextBoxCell celdaMarcaRT = new DataGridViewTextBoxCell();
                        celdaMarcaRT.Value = d.Marca;
                        fila.Cells.Add(celdaMarcaRT);

                        DataGridViewTextBoxCell celdaModeloRT = new DataGridViewTextBoxCell();
                        celdaModeloRT.Value = d.Modelo
                         ;
                        fila.Cells.Add(celdaModeloRT);

                        grillaRTDisponibles.Rows.Add(fila);
                    }
                    

                }
            }
        }

        private void grillaRTDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DataGridViewRow filaSeleccionada = grillaRTDisponibles.Rows[indice];
            int numeroRT = int.Parse(filaSeleccionada.Cells["numero"].Value.ToString());
            this.gestor.tomarSeleccionRT(numeroRT);
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DateTime fechaselect = dateTimePicker1.Value;
            this.gestor.tomarFechaFinPrevista(fechaselect);
        }

        private void btnMotivo_Click(object sender, EventArgs e)
        {
            string motivo = txtBoxMotivo.ToString();
            this.gestor.tomarMotivo(motivo);
        }

        private void cargarComboCientifico(IEnumerable<IGrouping<string, DatosPantallaRT>> dataTurnos)
        {
            foreach (var group in dataTurnos)
            {
                var groupKey = group.Key;
                cmbCientifico.Items.Add(groupKey);
                foreach (var d in group)
                {
                    DatosPantallaRT elemento = d;

                }
            }
        }
        private void cargarGrillaTurnos(IEnumerable<IGrouping<string, DatosPantallaRT>> dataTurnos, string turnos)
        {
            foreach (var group in dataTurnos)
            {
                var groupKey = group.Key;
                //cmbTipoRT.Items.Add(groupKey);
                foreach (var d in group)
                {
                    DatosPantallaRT elemento = d;
                    if (elemento.TipoRecursoTecnologico == turnos)
                    {
                        DataGridViewRow fila = new DataGridViewRow();
                        DataGridViewTextBoxCell celdaNroRT = new DataGridViewTextBoxCell();
                        celdaNroRT.Value = d.NumeroRT;
                        fila.Cells.Add(celdaNroRT);

                        DataGridViewTextBoxCell celdaMarcaRT = new DataGridViewTextBoxCell();
                        celdaMarcaRT.Value = d.Marca;
                        fila.Cells.Add(celdaMarcaRT);

                        DataGridViewTextBoxCell celdaModeloRT = new DataGridViewTextBoxCell();
                        celdaModeloRT.Value = d.Modelo
                         ;
                        fila.Cells.Add(celdaModeloRT);

                        grillaRTDisponibles.Rows.Add(fila);
                    }


                }
            }
        }

        private void verTurnos_Click(object sender, EventArgs e)
        {
            TurnosPorRT pantallaTurnosXRt = new TurnosPorRT(this.gestor);
            pantallaTurnosXRt.Show();
        }

        private void grillaRTDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
