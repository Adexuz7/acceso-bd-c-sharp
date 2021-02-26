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

                connection.Close();

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

        public List<Equipo> GetEquipos()
        {
            return this.dataSet.Tables["Equipos"].AsEnumerable().Select(equipo =>
                new Equipo
                {
                    CodEquipo = equipo.Field<int>("codEquipo"),
                    NomEquipo = equipo.Field<string>("nomEquipo"),
                    CodLiga = equipo.Field<string>("codLiga"),
                    Localidad = equipo.Field<string>("localidad"),
                    Internacional = equipo.Field<bool>("internacional")
                }).ToList();
        }

        public List<Contrato> GetContratos()
        {
            return this.dataSet.Tables["Contratos"].AsEnumerable().Select(contrato =>
                new Contrato
                {
                    CodContrato = contrato.Field<int>("codContrato"),
                    CodDNIoNIE = contrato.Field<string>("codDNIoNIE"),
                    CodEquipo = contrato.Field<int>("codEquipo"),
                    FechaInicio = contrato.Field<DateTime>("fechaInicio"),
                    FechaFin = contrato.Field<DateTime>("fechaFin"),
                    PrecioRecision = contrato.Field<int>("precioRecision")
                }).ToList();
        }

        public List<Liga> GetLigas()
        {
            return this.dataSet.Tables["Ligas"].AsEnumerable().Select(liga =>
                new Liga
                {
                    CodLiga = liga.Field<string>("codLiga"),
                    NomLiga = liga.Field<string>("nomLiga")
                }).ToList();
        }

        public DataTableCollection getTables()
        {
            return this.dataSet.Tables;
        }

        public List<string> getTableNames()
        {
            List<string> tableNames = new List<string>();

            foreach (DataTable dt in this.dataSet.Tables) 
            {
                tableNames.Add(dt.TableName);
            }

            return tableNames;
        }

        private void PersistChangesOnDatabaseTable(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM " + tableName;

                SqlDataAdapter adapter = new SqlDataAdapter(query, this.connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                DataTable tableToUpdate = this.dataSet.Tables[tableName];

                adapter.Update(tableToUpdate);

                ConnectToData(connectionString);

                connection.Close();
            }
        }

        public List<Equipo> GetEquiposLiga(string codLiga)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.TableMappings.Add("Table", "EquiposLiga");

                connection.Open();

                DataSet equiposLigaDataSet = new DataSet("EquiposLiga");

                SqlCommand command = new SqlCommand(
                    @"SELECT codEquipo, nomEquipo, codLiga, localidad, internacional 
                      FROM dbo.Equipos
                      WHERE codLiga LIKE '" + codLiga + "';",
                    connection);
                command.CommandType = CommandType.Text;

                adapter.SelectCommand = command;

                adapter.Fill(equiposLigaDataSet);

                connection.Close();

                return equiposLigaDataSet.Tables["EquiposLiga"].AsEnumerable().Select(equipo =>
                new Equipo
                {
                    CodEquipo = equipo.Field<int>("codEquipo"),
                    NomEquipo = equipo.Field<string>("nomEquipo"),
                    CodLiga = equipo.Field<string>("codLiga"),
                    Localidad = equipo.Field<string>("localidad"),
                    Internacional = equipo.Field<bool>("internacional")
                }).ToList();
            }
        }

        // Funciones para insertar o actualizar
        public void UpsertFutbolista(Futbolista futbolista)
        {
            string DNIoNIE = futbolista.CodDNIoNIE;

            if (string.IsNullOrEmpty(DNIoNIE))
            {
                return;
            }

            DataRow futbolistaToUpsert = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                futbolistaToUpsert = this.dataSet.Tables["Futbolistas"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<string>("codDNIoNIE") == DNIoNIE);

                // Crear una nueva fila para insertar y Si no existe lo inserta
                if (futbolistaToUpsert == null)
                {
                    futbolistaToUpsert = this.dataSet.Tables["Futbolistas"].NewRow();
                    futbolistaToUpsert["codDNIoNIE"] = futbolista.CodDNIoNIE;
                    this.dataSet.Tables["Futbolistas"].Rows.Add(futbolistaToUpsert);
                }

                // Actualizar campos restantes
                futbolistaToUpsert["Nombre"] = futbolista.Nombre;
                futbolistaToUpsert["Nacionalidad"] = futbolista.Nacionalidad;

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Futbolistas");
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpsertEquipo(Equipo equipo)
        {
            int CodEquipo = equipo.CodEquipo;

            DataRow equipoToUpsert = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                equipoToUpsert = this.dataSet.Tables["Equipos"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<int>("codEquipo") == CodEquipo);

                // Crear una nueva fila para insertar y Si no existe lo inserta
                if (equipoToUpsert == null)
                {
                    equipoToUpsert = this.dataSet.Tables["Equipos"].NewRow();
                    equipoToUpsert["codEquipo"] = equipo.CodEquipo;
                    this.dataSet.Tables["Equipos"].Rows.Add(equipoToUpsert);
                }

                // Actualizar campos restantes
                equipoToUpsert["nomEquipo"] = equipo.NomEquipo;
                equipoToUpsert["codLiga"] = equipo.CodLiga;
                equipoToUpsert["localidad"] = equipo.Localidad;
                equipoToUpsert["internacional"] = equipo.Internacional;

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Equipos");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpsertContrato(Contrato contrato)
        {
            int CodContrato = contrato.CodContrato;

            DataRow contratoToUpsert = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                contratoToUpsert = this.dataSet.Tables["Contratos"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<int>("codContrato") == CodContrato);

                // Crear una nueva fila para insertar y Si no existe lo inserta
                if (contratoToUpsert == null)
                {
                    contratoToUpsert = this.dataSet.Tables["Contratos"].NewRow();
                    contratoToUpsert["codContrato"] = contrato.CodContrato;
                    this.dataSet.Tables["Contratos"].Rows.Add(contratoToUpsert);
                }

                // Actualizar campos restantes
                contratoToUpsert["codDNIoNIE"] = contrato.CodDNIoNIE;
                contratoToUpsert["codEquipo"] = contrato.CodEquipo;
                contratoToUpsert["fechaInicio"] = contrato.FechaInicio;
                contratoToUpsert["fechaFin"] = contrato.FechaFin;
                contratoToUpsert["precioRecision"] = contrato.PrecioRecision;

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Contratos");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpsertLiga(Liga liga)
        {
            string codLiga = liga.CodLiga;

            if (string.IsNullOrEmpty(codLiga))
            {
                return;
            }

            DataRow ligaToUpsert = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                ligaToUpsert = this.dataSet.Tables["Ligas"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<string>("codLiga") == codLiga);

                // Crear una nueva fila para insertar y Si no existe lo inserta
                if (ligaToUpsert == null)
                {
                    ligaToUpsert = this.dataSet.Tables["Ligas"].NewRow();
                    ligaToUpsert["codLiga"] = liga.CodLiga;
                    this.dataSet.Tables["Ligas"].Rows.Add(ligaToUpsert);
                }

                // Actualizar campos restantes
                ligaToUpsert["nomLiga"] = liga.NomLiga;

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Ligas");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFutbolista(Futbolista futbolista)
        {
            string DNIoNIE = futbolista.CodDNIoNIE;

            if (string.IsNullOrEmpty(DNIoNIE))
            {
                return;
            }

            DataRow futbolistaToDelete = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                futbolistaToDelete = this.dataSet.Tables["Futbolistas"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<string>("codDNIoNIE") == DNIoNIE);

                
                if (futbolistaToDelete == null)
                {
                    return;
                }

                // Marcar fila para eliminar
                futbolistaToDelete.Delete();

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Futbolistas");

            }
            catch (Exception)
            {
                if (futbolistaToDelete != null)
                {
                    futbolistaToDelete.RejectChanges();
                }

                throw;
            }
        }

        public void DeleteEquipo(Equipo equipo)
        {
            int CodEquipo = equipo.CodEquipo;

            DataRow equipoToDelete = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                equipoToDelete = this.dataSet.Tables["Equipos"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<int>("codEquipo") == CodEquipo);


                if (equipoToDelete == null)
                {
                    return;
                }

                // Marcar fila para eliminar
                equipoToDelete.Delete();

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Equipos");

            }
            catch (Exception)
            {
                if (equipoToDelete != null)
                {
                    equipoToDelete.RejectChanges();
                }

                throw;
            }
        }

        public void DeleteContrato(Contrato contrato)
        {
            int CodContrato = contrato.CodContrato;

            DataRow contratoToDelete = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                contratoToDelete = this.dataSet.Tables["Contratos"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<int>("codContrato") == CodContrato);

                if (contratoToDelete == null)
                {
                    return;
                }

                // Marcar fila para eliminar
                contratoToDelete.Delete();

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Contratos");

            }
            catch (Exception)
            {
                if (contratoToDelete != null)
                {
                    contratoToDelete.RejectChanges();
                }

                throw;
            }
        }

        public void DeleteLiga(Liga liga)
        {
            string codLiga = liga.CodLiga;

            if (string.IsNullOrEmpty(codLiga))
            {
                return;
            }

            DataRow ligaToDelete = null;

            try
            {
                // SingleOrDefault devuelve el registro o nada si no existe
                ligaToDelete = this.dataSet.Tables["Ligas"]
                                        .AsEnumerable()
                                        .SingleOrDefault(row => row.Field<string>("codLiga") == codLiga);


                if (ligaToDelete == null)
                {
                    return;
                }

                // Marcar fila para eliminar
                ligaToDelete.Delete();

                // Persistir cambios en la base de datos
                PersistChangesOnDatabaseTable("Ligas");

            }
            catch (Exception)
            {
                if (ligaToDelete != null)
                {
                    ligaToDelete.RejectChanges();
                }

                throw;
            }
        }

        public DataTable ExecProcedureObtenerContratoFutbolista(string codDNIoNIE)
        {
            return SQLRepository.ObtenerContratoFutbolista(this.connectionString, codDNIoNIE);
        }
    }
}
