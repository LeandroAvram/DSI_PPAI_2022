﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaRegistroRTMantenimiento pantalla = new PantallaRegistroRTMantenimiento();
            pantalla.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
