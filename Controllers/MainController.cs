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
        private string connectionString =
            "Data Source=DESKTOP-3RR2FK1\\SQLEXPRESS;" +
            "Initial Catalog=bdFutbol;" +
            "User id=sa;" +
            "Password=sa;";

        private DataSet dataSet;

        public MainController()
        {
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

            }
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
    }
}
