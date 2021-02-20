using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            dataGridView1.DataSource = new BindingList<Futbolista>(this.mainController.GetFutbolistas());

            // Evitar que se pueda modificar el dataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Actualizar el contador de número de registros
            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;

            // Rellenar los datos del comboBox para seleccionar la tabla a visualizar
            PopulateTableComboBox();

            // Actualizar la interfaz cuando se selecciona una tabla
            this.selectTableComboBox.SelectedIndexChanged += new System.EventHandler(RefreshDataGridView);

            

        }

        private void PopulateTableComboBox()
        {
            // Hacer lista de las tablas
            //List<DataTable> tables = new List<DataTable>(mainController.getTables().Cast<DataTable>());

            List<string> tableNames = new List<string>()
            {
                "Futbolistas",
                "Equipos",
                "Ligas",
                "Contratos"
            };

            // Rellenar comboBox con los nombres de las tablas
            this.selectTableComboBox.DataSource = tableNames;
            //this.selectTableComboBox.DisplayMember = "TableName";

            // Hacer que sea de solo lectura
            this.selectTableComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RefreshDataGridView(object sender, System.EventArgs e)
        {
            // Recoger el comboBox
            //ComboBox comboBox = (ComboBox) sender;

            // Recoger la opcion seleccionada del comboBox
            //string selectedTableName = (string) comboBox.SelectedItem;

            string selectedTableName = this.GetSelectedTableName();

            // Clear DataGridView content
            dataGridView1.DataSource = null;

            switch (selectedTableName)
            {
                case "Futbolistas":
                    dataGridView1.DataSource = this.mainController.GetFutbolistas();
                    break;
                case "Equipos":
                    //dataGridView1.DataSource = this.mainController.GetEquipos();
                    break;
                case "Contratos":
                    //dataGridView1.DataSource = this.mainController.GetContratos();
                    break;
                case "Ligas":
                    //dataGridView1.DataSource = this.mainController.GetLigas();
                    break;
            }

            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;

            // SHIT

            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.DisplayMember = "Nombre"; 

            //cmb.DataPropertyName = "Nombre"; // Aqui se ponen los datos (hace que el programa explote)
            //cmb.DataSource = mainController.getTables()["futbolistas"]; 
            //dataGridView1.Columns.Add(cmb);

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
                        this.mainController.RemoveFutbolista((Futbolista)objectToDelete);
                        dataGridView1.DataSource = this.mainController.GetFutbolistas();
                        break;
                    case "Equipos":
                        //this.mainController.RemoveEquipo((Equipo)objectToDelete);
                        //dataGridView1.DataSource = this.mainController.GetEquipos();
                        break;
                    case "Contratos":
                        //this.mainController.RemoveContrato((Contrato)objectToDelete);
                        //dataGridView1.DataSource = this.mainController.GetContratos();
                        break;
                    case "Ligas":
                        //this.mainController.RemoveLiga((Liga)objectToDelete);
                        //dataGridView1.DataSource = this.mainController.GetLigas();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Esto petó compadre!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.Remove(row);
            //}
        }

        private string GetSelectedTableName()
        {
            return (string)this.selectTableComboBox.SelectedItem;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            Futbolista newFutbolista = new Futbolista()
            {
                CodDNIoNIE = "32323232K",
                Nombre = "Ronaldinho",
                Nacionalidad = "Brasileña"
            };

            // TO DO add switch statement here as well

            try
            {
                this.mainController.UpsertFutbolista(newFutbolista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Esto petó compadre!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
