namespace DSI_PPAI_2022
{
    partial class PantallaRegistroRTMantenimiento
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoRT = new System.Windows.Forms.ComboBox();
            this.grillaRTDisponibles = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMotivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grillaTurnos = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCientifico = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.grupoNotificacion = new System.Windows.Forms.GroupBox();
            this.checkBoxWhatsapp = new System.Windows.Forms.CheckBox();
            this.checkBoxMail = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnMotivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRTDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).BeginInit();
            this.grupoNotificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar Recurso Tecnologico";
            // 
            // cmbTipoRT
            // 
            this.cmbTipoRT.FormattingEnabled = true;
            this.cmbTipoRT.Location = new System.Drawing.Point(525, 25);
            this.cmbTipoRT.Name = "cmbTipoRT";
            this.cmbTipoRT.Size = new System.Drawing.Size(151, 28);
            this.cmbTipoRT.TabIndex = 2;
            this.cmbTipoRT.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRT_SelectedIndexChanged);
            // 
            // grillaRTDisponibles
            // 
            this.grillaRTDisponibles.AllowUserToAddRows = false;
            this.grillaRTDisponibles.AllowUserToDeleteRows = false;
            this.grillaRTDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRTDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.marca,
            this.modelo});
            this.grillaRTDisponibles.Location = new System.Drawing.Point(12, 59);
            this.grillaRTDisponibles.Name = "grillaRTDisponibles";
            this.grillaRTDisponibles.ReadOnly = true;
            this.grillaRTDisponibles.RowHeadersWidth = 51;
            this.grillaRTDisponibles.RowTemplate.Height = 29;
            this.grillaRTDisponibles.Size = new System.Drawing.Size(664, 238);
            this.grillaRTDisponibles.TabIndex = 3;
            this.grillaRTDisponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaRTDisponibles_CellClick);
            // 
            // numero
            // 
            this.numero.HeaderText = "N° Recurso";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 110;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 250;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.MinimumWidth = 6;
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            this.modelo.Width = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(688, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese fecha fin prevista del mantenimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(724, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingrese motivo de mantenimiento";
            // 
            // txtBoxMotivo
            // 
            this.txtBoxMotivo.Location = new System.Drawing.Point(724, 173);
            this.txtBoxMotivo.Multiline = true;
            this.txtBoxMotivo.Name = "txtBoxMotivo";
            this.txtBoxMotivo.Size = new System.Drawing.Size(236, 124);
            this.txtBoxMotivo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Turnos registrados del Recurso Tecnologico";
            // 
            // grillaTurnos
            // 
            this.grillaTurnos.AllowUserToAddRows = false;
            this.grillaTurnos.AllowUserToDeleteRows = false;
            this.grillaTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.horaInicio,
            this.horaFin});
            this.grillaTurnos.Location = new System.Drawing.Point(12, 368);
            this.grillaTurnos.Name = "grillaTurnos";
            this.grillaTurnos.ReadOnly = true;
            this.grillaTurnos.RowHeadersWidth = 51;
            this.grillaTurnos.RowTemplate.Height = 29;
            this.grillaTurnos.Size = new System.Drawing.Size(532, 193);
            this.grillaTurnos.TabIndex = 9;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 125;
            // 
            // horaInicio
            // 
            this.horaInicio.HeaderText = "Hora Inicio";
            this.horaInicio.MinimumWidth = 6;
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ReadOnly = true;
            this.horaInicio.Width = 125;
            // 
            // horaFin
            // 
            this.horaFin.HeaderText = "Hora Fin";
            this.horaFin.MinimumWidth = 6;
            this.horaFin.Name = "horaFin";
            this.horaFin.ReadOnly = true;
            this.horaFin.Width = 125;
            // 
            // cmbCientifico
            // 
            this.cmbCientifico.FormattingEnabled = true;
            this.cmbCientifico.Location = new System.Drawing.Point(393, 334);
            this.cmbCientifico.Name = "cmbCientifico";
            this.cmbCientifico.Size = new System.Drawing.Size(151, 28);
            this.cmbCientifico.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(599, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Confirmar mantenimiento correctivo del recurso";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(668, 400);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(94, 29);
            this.botonCancelar.TabIndex = 12;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(790, 400);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(94, 29);
            this.botonConfirmar.TabIndex = 13;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            // 
            // grupoNotificacion
            // 
            this.grupoNotificacion.Controls.Add(this.checkBoxWhatsapp);
            this.grupoNotificacion.Controls.Add(this.checkBoxMail);
            this.grupoNotificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grupoNotificacion.Location = new System.Drawing.Point(636, 474);
            this.grupoNotificacion.Name = "grupoNotificacion";
            this.grupoNotificacion.Size = new System.Drawing.Size(288, 93);
            this.grupoNotificacion.TabIndex = 14;
            this.grupoNotificacion.TabStop = false;
            this.grupoNotificacion.Text = "Seleccione medio de notificacion";
            // 
            // checkBoxWhatsapp
            // 
            this.checkBoxWhatsapp.AutoSize = true;
            this.checkBoxWhatsapp.Location = new System.Drawing.Point(6, 56);
            this.checkBoxWhatsapp.Name = "checkBoxWhatsapp";
            this.checkBoxWhatsapp.Size = new System.Drawing.Size(102, 24);
            this.checkBoxWhatsapp.TabIndex = 1;
            this.checkBoxWhatsapp.Text = "Whatsapp";
            this.checkBoxWhatsapp.UseVisualStyleBackColor = true;
            // 
            // checkBoxMail
            // 
            this.checkBoxMail.AutoSize = true;
            this.checkBoxMail.Checked = true;
            this.checkBoxMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMail.Location = new System.Drawing.Point(6, 26);
            this.checkBoxMail.Name = "checkBoxMail";
            this.checkBoxMail.Size = new System.Drawing.Size(61, 24);
            this.checkBoxMail.TabIndex = 0;
            this.checkBoxMail.Text = "Mail";
            this.checkBoxMail.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(710, 95);
            this.dateTimePicker1.MinDate = new System.DateTime(2022, 6, 25, 16, 0, 53, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.Value = new System.DateTime(2022, 6, 25, 16, 0, 53, 0);
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // btnMotivo
            // 
            this.btnMotivo.Location = new System.Drawing.Point(852, 303);
            this.btnMotivo.Name = "btnMotivo";
            this.btnMotivo.Size = new System.Drawing.Size(108, 38);
            this.btnMotivo.TabIndex = 16;
            this.btnMotivo.Text = "Enviar Motivo";
            this.btnMotivo.UseVisualStyleBackColor = true;
            this.btnMotivo.Click += new System.EventHandler(this.btnMotivo_Click);
            // 
            // PantallaRegistroRTMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 654);
            this.Controls.Add(this.btnMotivo);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.grupoNotificacion);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCientifico);
            this.Controls.Add(this.grillaTurnos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxMotivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grillaRTDisponibles);
            this.Controls.Add(this.cmbTipoRT);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "PantallaRegistroRTMantenimiento";
            this.Text = "Registrar Ingreso de Recurso Tecnologico en Mantenimiento Correctivo";
            this.Load += new System.EventHandler(this.PantallaRegistroRTMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaRTDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).EndInit();
            this.grupoNotificacion.ResumeLayout(false);
            this.grupoNotificacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private ComboBox cmbTipoRT;
        private DataGridView grillaRTDisponibles;
        private DataGridViewTextBoxColumn numero;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn modelo;
        private Label label2;
        private Label label3;
        private TextBox txtBoxMotivo;
        private Label label4;
        private DataGridView grillaTurnos;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn horaInicio;
        private DataGridViewTextBoxColumn horaFin;
        private ComboBox cmbCientifico;
        private Label label5;
        private Button botonCancelar;
        private Button botonConfirmar;
        private GroupBox grupoNotificacion;
        private CheckBox checkBoxWhatsapp;
        private CheckBox checkBoxMail;
        private DateTimePicker dateTimePicker1;
        private Button btnMotivo;
    }
}