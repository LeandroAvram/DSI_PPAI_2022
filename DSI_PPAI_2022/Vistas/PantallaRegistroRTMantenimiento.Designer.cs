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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(2057, 601);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(500, 47);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // PantallaRegistroRTMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3016, 1366);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "PantallaRegistroRTMantenimiento";
            this.Text = "PantallaRegistroRTMantenimiento";
            this.Load += new System.EventHandler(this.PantallaRegistroRTMantenimiento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker dateTimePicker1;
    }
}