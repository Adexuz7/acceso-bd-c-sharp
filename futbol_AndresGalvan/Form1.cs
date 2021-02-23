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

            // Construir el mainController y rellenar el dataSet con la información de la base de datos
            this.mainController = new MainController(readConnectionString());

            // Inicializar dataGridView con los datos de la tabla Futbolistas
            dataGridView1.DataSource = (List <Futbolista>) this.mainController.GetFutbolistas();

            // Evitar que se pueda modificar el dataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Actualizar el contador de número de registros
            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;

            // Rellenar los datos del comboBox para seleccionar la tabla a visualizar
            populateTableComboBox();

            // Actualizar la interfaz cuando se selecciona una tabla
            this.selectTableComboBox.SelectedIndexChanged += new System.EventHandler(RefreshDataGridView);

            

        }

        private void populateTableComboBox()
        {
            // Rellenar comboBox con los nombres de las tablas
            this.selectTableComboBox.DataSource = this.mainController.getTableNames();

            // Hacer que sea de solo lectura
            this.selectTableComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private string GetSelectedTableName()
        {
            return (string)this.selectTableComboBox.SelectedItem;
        }

        private void RefreshDataGridView(object sender, System.EventArgs e)
        {
            // Recoger el comboBox
            //ComboBox comboBox = (ComboBox) sender;

            // Recoger la opcion seleccionada del comboBox
            //DataTable selectedTable = (DataTable) comboBox.SelectedItem;

            string selectedTable = this.GetSelectedTableName();

            // Actualizar dataGridView

            this.dataGridView1.DataSource = null;

            switch (selectedTable)
            {
                case "Futbolistas":
                    dataGridView1.DataSource = this.mainController.GetFutbolistas();
                    break;
                case "Equipos":
                    dataGridView1.DataSource = this.mainController.GetEquipos();
                    break;
                case "Contratos":
                    dataGridView1.DataSource = this.mainController.GetContratos();
                    break;
                case "Ligas":
                    dataGridView1.DataSource = this.mainController.GetLigas();
                    break;
            }

            //dataGridView1.DataSource = selectedTable;

            // Actualizar label
            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;


            // SHIT

            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.DisplayMember = "Nombre"; 

            //cmb.DataPropertyName = "Nombre"; // Aqui se ponen los datos (hace que el programa explote)
            //cmb.DataSource = mainController.getTables()["futbolistas"]; 
            //dataGridView1.Columns.Add(cmb);




        }

        private void RefreshDataGridView()
        {
            RefreshDataGridView(null, null);
        }

        private string readConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Object objectToDelete = dataGridView1.CurrentRow.DataBoundItem;

            try
            {
                switch (this.GetSelectedTableName())
                {
                    case "Futbolistas":
                        this.mainController.DeleteFutbolista((Futbolista)objectToDelete);
                        break;
                    case "Equipos":
                        this.mainController.DeleteEquipo((Equipo)objectToDelete);
                        break;
                    case "Contratos":
                        this.mainController.DeleteContrato((Contrato)objectToDelete);
                        break;
                    case "Ligas":
                        this.mainController.DeleteLiga((Liga)objectToDelete);
                        break;
                }

                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void insertButton_Click(object sender, EventArgs e)
        {

            try
            {

                switch (this.GetSelectedTableName())
                {
                    case "Futbolistas":

                        Futbolista newFutbolista = new Futbolista()
                        {
                            CodDNIoNIE = "12345678A",
                            Nombre = "Futbolista de ejemplo",
                            Nacionalidad = "Alienígena"
                        };

                        this.mainController.UpsertFutbolista(newFutbolista);
                        break;
                    case "Equipos":

                        Equipo newEquipo = new Equipo()
                        {
                            // CodEquipo AUTONUMÉRICO
                            NomEquipo = "Equipo Intergaláctico Alienígena",
                            CodLiga = "LFP01",
                            Localidad = "Una Galaxia Muy Lejana",
                            Internacional = true
                        };

                        this.mainController.UpsertEquipo(newEquipo);
                        break;
                    case "Contratos":

                        Contrato newContrato = new Contrato()
                        {
                            // CodContrato AUTONUMÉRICO
                            CodDNIoNIE = "11111111M",
                            CodEquipo = 5,
                            FechaInicio = new DateTime(2008, 01, 01),
                            FechaFin = new DateTime(2009, 06, 06),
                            PrecioRecision = 999
                        };

                        this.mainController.UpsertContrato(newContrato);
                        break;
                    case "Ligas":

                        Liga newLiga = new Liga()
                        {
                            CodLiga = "LFP07",
                            NomLiga = "Liga Intergaláctica"
                        };

                        this.mainController.UpsertLiga(newLiga);
                        break;
                }

                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            string codDNIoNIE = codDNIoNIETextBox.Text;

            if (string.IsNullOrEmpty(codDNIoNIE)) 
            {
                return;
            }

            DataTable result = this.mainController.ExecProcedureObtenerContratoFutbolista(codDNIoNIE);

            sPdataGridView.DataSource = result;
        }
    }
}
