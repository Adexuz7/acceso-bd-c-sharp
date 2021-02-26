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
    public partial class MainForm : Form
    {

        private MainController mainController;

        public MainForm()
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
        
        private string readConnectionString()
        {
            // Los detalles de la connectionString se encuentran en el fichero App.config
            return System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
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

            // Actualizar label
            RowCountLabel.Text = "Nº de registros: " + dataGridView1.RowCount;

        }

        public void RefreshDataGridView()
        {
            RefreshDataGridView(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // invocar nueva ventana con los datos de la liga y sus equipos
            Object objectToLoad = dataGridView1.CurrentRow.DataBoundItem;

            switch (this.GetSelectedTableName())
            {
                case "Futbolistas":
                    
                    break;
                case "Equipos":
                    
                    break;
                case "Contratos":
                    
                    break;
                case "Ligas":
                    EquiposLigaForm equiposLigaForm = new EquiposLigaForm(mainController, this);
                    equiposLigaForm.LoadData((Liga)objectToLoad);
                    equiposLigaForm.Show();
                    break;
            }


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
                        UpsertFutbolistaForm upsertFutbolistaForm = new UpsertFutbolistaForm(mainController, this);
                        upsertFutbolistaForm.Show();
                        break;
                    case "Equipos":
                        UpsertEquipoForm upsertEquipoForm = new UpsertEquipoForm(mainController, this);
                        upsertEquipoForm.Show();
                        break;
                    case "Contratos":
                        UpsertContratoForm upsertContratoForm = new UpsertContratoForm(mainController, this);
                        upsertContratoForm.Show();
                        break;
                    case "Ligas":
                        UpsertLigaForm upsertLigaForm = new UpsertLigaForm(mainController, this);
                        upsertLigaForm.Show();
                        break;
                }
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

        private void modifyButton_Click(object sender, EventArgs e)
        {
            Object objectToModify = dataGridView1.CurrentRow.DataBoundItem;

            try
            {
                switch (this.GetSelectedTableName())
                {
                    case "Futbolistas":
                        UpsertFutbolistaForm upsertFutbolistaForm = new UpsertFutbolistaForm(mainController, this);
                        upsertFutbolistaForm.LoadData((Futbolista)objectToModify);
                        upsertFutbolistaForm.Show();
                        break;
                    case "Equipos":
                        UpsertEquipoForm upsertEquipoForm = new UpsertEquipoForm(mainController, this);
                        upsertEquipoForm.LoadData((Equipo)objectToModify);
                        upsertEquipoForm.Show();
                        break;
                    case "Contratos":
                        UpsertContratoForm upsertContratoForm = new UpsertContratoForm(mainController, this);
                        upsertContratoForm.LoadData((Contrato)objectToModify);
                        upsertContratoForm.Show();
                        break;
                    case "Ligas":
                        UpsertLigaForm upsertLigaForm = new UpsertLigaForm(mainController, this);
                        upsertLigaForm.LoadData((Liga)objectToModify);
                        upsertLigaForm.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
