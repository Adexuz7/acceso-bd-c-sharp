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
    public partial class UpsertContratoForm : Form
    {
        private MainController mainController;
        private MainForm mainForm;
        private Contrato contrato;

        public UpsertContratoForm(MainController mainController, MainForm mainForm)
        {
            InitializeComponent();

            this.mainController = mainController;
            this.mainForm = mainForm;

            codContratoTextBox.Enabled = false;
        }

        public void LoadData(Contrato contrato)
        {
            this.contrato = contrato;
            codContratoTextBox.Text = this.contrato.CodContrato.ToString();
            codDNIoNIETextBox.Text = this.contrato.CodDNIoNIE;
            codEquipoTextBox.Text = this.contrato.CodEquipo.ToString();
            fechaInicioTextBox.Text = this.contrato.FechaInicio.ToString();
            fechaFinTextBox.Text = this.contrato.FechaFin.ToString();
            precioRescisionTextBox.Text = this.contrato.PrecioRecision.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (contrato == null)
                {
                    int codEquipo = 0;
                    int precioRescision = 0;

                    Int32.TryParse(codEquipoTextBox.Text, out codEquipo);
                    Int32.TryParse(precioRescisionTextBox.Text, out precioRescision);

                    DateTime fechaInicio = DateTime.Parse(fechaInicioTextBox.Text);
                    DateTime fechaFin = DateTime.Parse(fechaFinTextBox.Text);

                    contrato = new Contrato()
                    {
                        CodDNIoNIE = codDNIoNIETextBox.Text,
                        CodEquipo = codEquipo,
                        FechaInicio = fechaInicio,
                        FechaFin = fechaFin,
                        PrecioRecision = precioRescision
                    };
                }
                else
                {
                    int codEquipo = 0;
                    int precioRescision = 0;

                    Int32.TryParse(codEquipoTextBox.Text, out codEquipo);
                    Int32.TryParse(precioRescisionTextBox.Text, out precioRescision);

                    DateTime fechaInicio = DateTime.Parse(fechaInicioTextBox.Text);
                    DateTime fechaFin = DateTime.Parse(fechaFinTextBox.Text);

                    contrato.CodDNIoNIE = codDNIoNIETextBox.Text;
                    contrato.CodEquipo = codEquipo;
                    contrato.FechaInicio = fechaInicio;
                    contrato.FechaFin = fechaFin;
                    contrato.PrecioRecision = precioRescision;
                }

                this.mainController.UpsertContrato(contrato);
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
