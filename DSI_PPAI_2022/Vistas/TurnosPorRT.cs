using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSI_PPAI_2022.Vistas
{
    public partial class TurnosPorRT : Form
    {
        GestorDeRegistroRTMantenimiento gestor;
        List<RecursoTecnologico> listaRt;
        public TurnosPorRT(GestorDeRegistroRTMantenimiento gestor)
        {
            InitializeComponent();
            this.gestor = gestor;
            listaRt = gestor.obtenerRT();
        }

        private void TurnosPorRT_Load(object sender, EventArgs e)
        {
            cargarCombRT(listaRt);
        }

        private void cargarCombRT(List<RecursoTecnologico> RTS)
        {
            foreach (RecursoTecnologico t in RTS)
            {
                cmbNumeroRT.Items.Add(t.NumeroRT);
            }
        }

        private void cmbNumeroRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tipoRT = (cmbNumeroRT.GetItemText(cmbNumeroRT.SelectedItem));
            grillaRTinfo.Rows.Clear();
            foreach (var rt in this.listaRt)
            {
                foreach(Turno t in rt.Turno)
                {
                    if (tipoRT == rt.NumeroRT.ToString())
                    {
                        Estado estadodelRT = null;
                        foreach (CambioEstadoRT rd in rt.CambioEstadoRT)
                        {
                            if(rd.esActual())
                            {
                                estadodelRT = rd.Estado;
                            }
                        }
                        Estado estadodelTurnoRT = null;
                        foreach (CambioEstadoTurno rd in t.CambioEstadoTurno)
                        {
                            if (rd.esVigente())
                            {
                                estadodelTurnoRT = rd.Estado;
                            }
                        }
                        DataGridViewRow fila = new DataGridViewRow();
                        DataGridViewTextBoxCell estadoRt = new DataGridViewTextBoxCell();
                        estadoRt.Value = estadodelRT.Nombre;
                        fila.Cells.Add(estadoRt);

                        DataGridViewRow celdaFechadesde = new DataGridViewRow();
                        DataGridViewTextBoxCell fechadesde = new DataGridViewTextBoxCell();
                        fechadesde.Value = t.FechaHoraInicio;
                        fila.Cells.Add(fechadesde);

                        DataGridViewRow celdafechahasta = new DataGridViewRow();
                        DataGridViewTextBoxCell fechaHasta = new DataGridViewTextBoxCell();
                        fechaHasta.Value = t.FechaHoraFin;
                        fila.Cells.Add(fechaHasta);

                        DataGridViewRow celdaestadoturno = new DataGridViewRow();
                        DataGridViewTextBoxCell estadoTurnoRT = new DataGridViewTextBoxCell();
                        estadoTurnoRT.Value = estadodelTurnoRT.Nombre;
                        fila.Cells.Add(estadoTurnoRT);


                        grillaRTinfo.Rows.Add(fila);
                    }
                }
            }
        }

        private void grillaRTinfo_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
