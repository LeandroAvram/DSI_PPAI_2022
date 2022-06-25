namespace DSI_PPAI_2022
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recursoTecnologicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarMantenimientoCorrectivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recursoTecnologicoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(376, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recursoTecnologicoToolStripMenuItem
            // 
            this.recursoTecnologicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarMantenimientoCorrectivoToolStripMenuItem});
            this.recursoTecnologicoToolStripMenuItem.Name = "recursoTecnologicoToolStripMenuItem";
            this.recursoTecnologicoToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.recursoTecnologicoToolStripMenuItem.Text = "Recurso Tecnologico";
            // 
            // registrarMantenimientoCorrectivoToolStripMenuItem
            // 
            this.registrarMantenimientoCorrectivoToolStripMenuItem.Name = "registrarMantenimientoCorrectivoToolStripMenuItem";
            this.registrarMantenimientoCorrectivoToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.registrarMantenimientoCorrectivoToolStripMenuItem.Text = "Registrar Mantenimiento Correctivo";
            this.registrarMantenimientoCorrectivoToolStripMenuItem.Click += new System.EventHandler(this.registrarMantenimientoCorrectivoToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 220);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem recursoTecnologicoToolStripMenuItem;
        private ToolStripMenuItem registrarMantenimientoCorrectivoToolStripMenuItem;
    }
}