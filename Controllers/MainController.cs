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
                createRelation("Ligas", "codLiga", "Equipos", "codLiga", "LigasEquipos");
                // Relación Equipos y Contratos
                createRelation("Equipos", "codEquipo", "Contratos", "codEquipo", "EquiposContratos");
                // Relación Futbolistas y Contratos
                createRelation("Futbolistas", "codDNIoNIE", "Contratos", "codDNIoNIE", "FutbolistasContratos");

            }
        }

        // Función para crear las relaciones de las tablas
        private void createRelation(string parentTableName, string parentColumnName, string childTableName, string childColumnName, string relationName) 
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

        public DataTableCollection getTables()
        {
            return this.dataSet.Tables;
        }
    }
}
