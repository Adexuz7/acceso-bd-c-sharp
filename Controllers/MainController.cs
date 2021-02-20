using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class MainController
    {

        private string connectionString;
        private DataSet dataSet;

        public MainController(string connectionString)
        {
            this.connectionString = connectionString;
            ConnectToData(this.connectionString);
        }

        private void ConnectToData(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.TableMappings.Add("Table", "Futbolistas");
                adapter.TableMappings.Add("Table1", "Equipos");
                adapter.TableMappings.Add("Table2", "Contratos");
                adapter.TableMappings.Add("Table3", "Ligas");

                connection.Open();

                this.dataSet = new DataSet("bdFutbol");

                SqlCommand command = new SqlCommand(
                    @"SELECT codDNIoNIE, nombre, nacionalidad FROM dbo.Futbolistas;
                    SELECT codEquipo, nomEquipo, codLiga, localidad, internacional FROM dbo.Equipos
                    SELECT codContrato, codDNIoNIE, codEquipo, fechaInicio, fechaFin, precioAnual, precioRecision FROM dbo.Contratos
                    SELECT codLiga, nomLiga FROM dbo.Ligas",
                    connection);
                command.CommandType = CommandType.Text;

                adapter.SelectCommand = command;

                adapter.Fill(dataSet);

                // Relación Ligas y Equipos
                CreateRelation("Ligas", "codLiga", "Equipos", "codLiga", "LigasEquipos");
                // Relación Equipos y Contratos
                CreateRelation("Equipos", "codEquipo", "Contratos", "codEquipo", "EquiposContratos");
                // Relación Futbolistas y Contratos
                CreateRelation("Futbolistas", "codDNIoNIE", "Contratos", "codDNIoNIE", "FutbolistasContratos");
            }
        }

        // Función para crear las relaciones de las tablas
        private void CreateRelation(string parentTableName, string parentColumnName, string childTableName, string childColumnName, string relationName) 
        {
            DataColumn parentColumn =
                    dataSet.Tables[parentTableName].Columns[parentColumnName];
            DataColumn childColumn =
                dataSet.Tables[childTableName].Columns[childColumnName];
            DataRelation relation =
                new System.Data.DataRelation(relationName,
                parentColumn, childColumn);
            dataSet.Relations.Add(relation);
        }

        public List<Futbolista> GetFutbolistas() 
        {
            return this.dataSet.Tables["Futbolistas"].AsEnumerable().Select(futbolista =>
                new Futbolista
                { 
                    CodDNIoNIE = futbolista.Field<string>("codDNIoNIE"),
                    Nombre = futbolista.Field<string>("nombre"),
                    Nacionalidad = futbolista.Field<string>("nacionalidad")
                }).ToList();
        }

        private void PersistChangesOnDatabaseTable(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT * FROM {0}", tableName);

                SqlDataAdapter adapter = new SqlDataAdapter(query, this.connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                DataTable tableToUpdate = this.dataSet.Tables[tableName];

                adapter.Update(tableToUpdate);
            }
        }

        public bool UpsertFutbolista(Futbolista futbolista)
        {
            string dniToUpsert = futbolista.CodDNIoNIE;

            if (string.IsNullOrEmpty(dniToUpsert))
            {
                return false;
            }

            DataRow futbolistaToUpsert = null;

            try
            {
                futbolistaToUpsert = this.dataSet.Tables["Futbolistas"]
                                            .AsEnumerable()
                                            .SingleOrDefault(row => row.Field<string>("codDNIoNIE") == dniToUpsert);

                // Create new row for insertion
                if (futbolistaToUpsert == null)
                {
                    futbolistaToUpsert = this.dataSet.Tables["Futbolistas"].NewRow();
                    futbolistaToUpsert["codDNIoNIE"] = futbolista.CodDNIoNIE;
                    this.dataSet.Tables["Futbolistas"].Rows.Add(futbolistaToUpsert);
                }
                else 
                {
                    // Football player already exists!!!
                }

                // Update remaning fields
                futbolistaToUpsert["Nombre"] = futbolista.Nombre;
                futbolistaToUpsert["Nacionalidad"] = futbolista.Nacionalidad;

                // Persist change on database
                PersistChangesOnDatabaseTable("Futbolistas");

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoveFutbolista(Futbolista futbolista)
        {
            string dniToRemove = futbolista.CodDNIoNIE;

            if (string.IsNullOrEmpty(dniToRemove))
            {
                return false;
            }

            DataRow futbolistaToRemove = null;

            try
            {
                futbolistaToRemove = this.dataSet.Tables["Futbolistas"]
                                            .AsEnumerable()
                                            .SingleOrDefault(row => row.Field<string>("codDNIoNIE") == dniToRemove);

                if (futbolistaToRemove == null)
                {
                    return false;
                }

                // Mark row to delete
                futbolistaToRemove.Delete();
                
                // Persist removal (also deletes from dataset)
                PersistChangesOnDatabaseTable("Futbolistas");

                return true;
            }
            catch (Exception e)
            {
                if (futbolistaToRemove != null)
                {
                    futbolistaToRemove.RejectChanges();
                }

                throw e;
            }
        }
    }
}
