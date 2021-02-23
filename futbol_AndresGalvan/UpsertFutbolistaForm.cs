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
    public partial class UpsertFutbolistaForm : Form
    {
        private MainController mainController;
        private MainForm mainForm;
        private Futbolista futbolista;

        public UpsertFutbolistaForm(MainController mainController, MainForm mainForm)
        {
            InitializeComponent();

            this.mainController = mainController;
            this.mainForm = mainForm;
        }

        public void LoadData(Futbolista futbolista)
        {
            this.futbolista = futbolista;
            codDNIoNIEtextBox.Enabled = false;
            codDNIoNIEtextBox.Text = this.futbolista.CodDNIoNIE;
            nombreTextBox.Text = this.futbolista.Nombre;
            nacionalidadTextBox.Text = this.futbolista.Nacionalidad;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (futbolista == null)
                {
                    futbolista = new Futbolista()
                    {
                        CodDNIoNIE = codDNIoNIEtextBox.Text,
                        Nombre = nombreTextBox.Text,
                        Nacionalidad = nacionalidadTextBox.Text
                    };
                }
                else
                {
                    futbolista.CodDNIoNIE = codDNIoNIEtextBox.Text;
                    futbolista.Nombre = nombreTextBox.Text;
                    futbolista.Nacionalidad = nacionalidadTextBox.Text;
                }

                this.mainController.UpsertFutbolista(futbolista);
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
