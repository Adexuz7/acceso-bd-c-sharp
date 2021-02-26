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
    public partial class EquiposLigaForm : Form
    {
        private MainController mainController;
        private MainForm mainForm;
        private Liga liga;

        public EquiposLigaForm(MainController mainController, MainForm mainForm)
        {
            InitializeComponent();

            this.mainController = mainController;
            this.mainForm = mainForm;
        }

        public void LoadData(Liga liga)
        {
            this.liga = liga;
            codLigaTextBox.Text = this.liga.CodLiga;
            nomLigaTextBox.Text = this.liga.NomLiga;

            equiposLigaDataGridView.DataSource = mainController.GetEquiposLiga(this.liga.CodLiga);
        }
    }
}
