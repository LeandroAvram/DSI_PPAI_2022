namespace DSI_PPAI_2022.Vistas
{
    partial class TurnosPorRT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillaRTinfo = new System.Windows.Forms.DataGridView();
            this.EstadoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurnoFechaHoraDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurnoFechaHoraHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbNumeroRT = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRTinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaRTinfo
            // 
            this.grillaRTinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRTinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EstadoRT,
            this.TurnoFechaHoraDesde,
            this.TurnoFechaHoraHasta,
            this.EstadoTurno});
            this.grillaRTinfo.Location = new System.Drawing.Point(155, 221);
            this.grillaRTinfo.Name = "grillaRTinfo";
            this.grillaRTinfo.RowHeadersWidth = 102;
            this.grillaRTinfo.RowTemplate.Height = 49;
            this.grillaRTinfo.Size = new System.Drawing.Size(1977, 585);
            this.grillaRTinfo.TabIndex = 0;
            this.grillaRTinfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaRTinfo_CellContentClick_1);
            // 
            // EstadoRT
            // 
            this.EstadoRT.HeaderText = "EstadoRT";
            this.EstadoRT.MinimumWidth = 12;
            this.EstadoRT.Name = "EstadoRT";
            this.EstadoRT.Width = 250;
            // 
            // TurnoFechaHoraDesde
            // 
            this.TurnoFechaHoraDesde.HeaderText = "TurnoFechaHoraDesde";
            this.TurnoFechaHoraDesde.MinimumWidth = 12;
            this.TurnoFechaHoraDesde.Name = "TurnoFechaHoraDesde";
            this.TurnoFechaHoraDesde.Width = 250;
            // 
            // TurnoFechaHoraHasta
            // 
            this.TurnoFechaHoraHasta.HeaderText = "TurnoFechaHoraHasta";
            this.TurnoFechaHoraHasta.MinimumWidth = 12;
            this.TurnoFechaHoraHasta.Name = "TurnoFechaHoraHasta";
            this.TurnoFechaHoraHasta.Width = 250;
            // 
            // EstadoTurno
            // 
            this.EstadoTurno.HeaderText = "EstadoTurno";
            this.EstadoTurno.MinimumWidth = 12;
            this.EstadoTurno.Name = "EstadoTurno";
            this.EstadoTurno.Width = 250;
            // 
            // cmbNumeroRT
            // 
            this.cmbNumeroRT.FormattingEnabled = true;
            this.cmbNumeroRT.Location = new System.Drawing.Point(1759, 97);
            this.cmbNumeroRT.Name = "cmbNumeroRT";
            this.cmbNumeroRT.Size = new System.Drawing.Size(302, 49);
            this.cmbNumeroRT.TabIndex = 1;
            this.cmbNumeroRT.SelectedIndexChanged += new System.EventHandler(this.cmbNumeroRT_SelectedIndexChanged);
            // 
            // TurnosPorRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2229, 888);
            this.Controls.Add(this.cmbNumeroRT);
            this.Controls.Add(this.grillaRTinfo);
            this.Name = "TurnosPorRT";
            this.Text = "TurnosPorRT";
            this.Load += new System.EventHandler(this.TurnosPorRT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaRTinfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grillaRTinfo;
        private DataGridViewTextBoxColumn NumeroRT;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn TurnoFechaHoraDesde;
        private DataGridViewTextBoxColumn TurnoFechaHoraHasta;
        private DataGridViewTextBoxColumn EstadoTurno;
        private ComboBox cmbNumeroRT;
        private DataGridViewTextBoxColumn EstadoRT;
    }
}