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
    public partial class UpsertLigaForm : Form
    {
        private MainController mainController;
        private MainForm mainForm;
        private Liga liga;

        public UpsertLigaForm(MainController mainController, MainForm mainForm)
        {
            InitializeComponent();

            this.mainController = mainController;
            this.mainForm = mainForm;
        }

        public void LoadData(Liga liga)
        {
            this.liga = liga;
            codLigaTextBox.Enabled = false;
            codLigaTextBox.Text = this.liga.CodLiga;
            nomLigaTextBox.Text = this.liga.NomLiga;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (liga == null)
                {
                    liga = new Liga()
                    {
                        CodLiga = codLigaTextBox.Text,
                        NomLiga = nomLigaTextBox.Text
                    };
                }
                else 
                {
                    liga.CodLiga = codLigaTextBox.Text;
                    liga.NomLiga = nomLigaTextBox.Text;
                }

                this.mainController.UpsertLiga(liga);
                this.mainForm.RefreshDataGridView();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
