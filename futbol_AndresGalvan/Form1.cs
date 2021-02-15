using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace futbol_AndresGalvan
{
    public partial class Form1 : Form
    {

        private MainController mainController;

        public Form1()
        {
            InitializeComponent();
            this.mainController = new MainController();

            List<Futbolista> futbolistas = this.mainController.GetFutbolistas();

            dataGridView1.DataSource = futbolistas;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
