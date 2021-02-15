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
            this.selectTableComboBox.SelectedIndexChanged += new System.EventHandler(updateUI);

            

        }

        private void populateTableComboBox()
        {
            // Hacer lista de las tablas
            List<DataTable> tables = new List<DataTable>(mainController.getTables().Cast<DataTable>());

            // Rellenar comboBox con los nombres de las tablas
            this.selectTableComboBox.DataSource = tables;
            this.selectTableComboBox.DisplayMember = "TableName";

            // Hacer que sea de solo lectura
            this.selectTableComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void updateUI(object sender, System.EventArgs e)
        {
            // Recoger el comboBox
            ComboBox comboBox = (ComboBox) sender;

            // Recoger la opcion seleccionada del comboBox
            DataTable selectedTable = (DataTable) comboBox.SelectedItem;

            // Actualizar dataGridView
            dataGridView1.DataSource = selectedTable;
            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;







            // SHIT

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.DisplayMember = "Nombre"; 

            cmb.DataPropertyName = "Nombre"; // Aqui se ponen los datos (hace que el programa explote)
            cmb.DataSource = mainController.getTables()["futbolistas"]; 
            dataGridView1.Columns.Add(cmb);




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
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.Remove(row);
            //}
        }
    }
}
