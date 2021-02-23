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
    public partial class UpsertEquipoForm : Form
    {
        private MainController mainController;
        private MainForm mainForm;
        private Equipo equipo;

        public UpsertEquipoForm(MainController mainController, MainForm mainForm)
        {
            InitializeComponent();

            this.mainController = mainController;
            this.mainForm = mainForm;

            codEquipoTextBox.Enabled = false;
        }

        public void LoadData(Equipo equipo)
        {
            this.equipo = equipo;
            codEquipoTextBox.Text = this.equipo.CodEquipo.ToString();
            nomEquipoTextBox.Text = this.equipo.NomEquipo;
            codLigaTextBox.Text = this.equipo.CodLiga;
            localidadTextBox.Text = this.equipo.Localidad;
            internacionalCheckBox.Checked = this.equipo.Internacional;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (equipo == null)
                {
                    bool isInternacional;

                    if (internacionalCheckBox.Checked)
                    {
                        isInternacional = true;
                    }
                    else
                    {
                        isInternacional = false;
                    }

                    equipo = new Equipo()
                    {
                        NomEquipo = nomEquipoTextBox.Text,
                        CodLiga = codLigaTextBox.Text,
                        Localidad = localidadTextBox.Text,
                        Internacional = isInternacional
                    };
                }
                else
                {
                    equipo.NomEquipo = nomEquipoTextBox.Text;
                    equipo.CodLiga = codLigaTextBox.Text;
                    equipo.Localidad = localidadTextBox.Text;

                    if (internacionalCheckBox.Checked)
                    {
                        equipo.Internacional = true;
                    }
                    else
                    {
                        equipo.Internacional = false;
                    }
                }

                this.mainController.UpsertEquipo(equipo);
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
