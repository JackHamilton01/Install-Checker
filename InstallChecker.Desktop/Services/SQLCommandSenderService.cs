using InstallChecker.Desktop.Models;
using NewToDoList.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace InstallChecker.Services
{
    public class SQLCommandSenderService : ISQLCommandSenderService
    {
        private string selectAllFromTableSQLCommand = "SELECT * FROM applications";
        private string insertIntoDatabaseValuesSQLCommand = "INSERT INTO applications VALUES(@name, @path)";

        public void SaveToDatabase(Product application)
        {
            CreateApplicationsTable();
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(DatabaseHelper.ConnectionString(DatabaseHelper.ConnectionStringName)))
            {
                List<Product> people = new List<Product>();

                people.Add(new Product(
                    application.Name,
                    application.Path));

                npgsqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand(insertIntoDatabaseValuesSQLCommand, npgsqlConnection);
                command.Parameters.AddWithValue("@name", application.Name);
                command.Parameters.AddWithValue("@path", application.Path);
                command.ExecuteNonQuery();
            }
        }

        public void CreateApplicationsTable()
        {
            if (!ApplicationsTableExists())
            {
                using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(DatabaseHelper.ConnectionString(DatabaseHelper.ConnectionStringName)))
                {
                    npgsqlConnection.Open();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("CREATE TABLE Applications ( " +
                        "Name VARCHAR(255)," +
                        "Path VARCHAR(255)" +
                        ");");
                    npgsqlCommand.Connection = npgsqlConnection;
                    npgsqlCommand.ExecuteNonQuery();
                }
            }
        }

        private bool ApplicationsTableExists()
        {
            string sql = "SELECT * FROM information_schema.tables WHERE table_name = 'applications'";
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(DatabaseHelper.ConnectionString(DatabaseHelper.ConnectionStringName)))
            {
                using (var npgSQLCommand = new NpgsqlCommand(sql))
                {
                    if (npgSQLCommand.Connection == null)
                    {
                        npgSQLCommand.Connection = npgsqlConnection;
                    }
                    if (npgSQLCommand.Connection.State != ConnectionState.Open)
                    {
                        npgSQLCommand.Connection.Open();
                    }

                    lock (npgSQLCommand)
                    {
                        using (NpgsqlDataReader rdr = npgSQLCommand.ExecuteReader())
                        {
                            try
                            {
                                if (rdr != null && rdr.HasRows)
                                {
                                    return true;
                                }
                                return false;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        public ObservableCollection<Product> GetApplications(NpgsqlConnection npgsqlConnection)
        {
            ObservableCollection<Product> applications = new ObservableCollection<Product>();

            npgsqlConnection.Open();
            NpgsqlCommand sqlCommand = new NpgsqlCommand();
            sqlCommand.Connection = npgsqlConnection;
            sqlCommand.CommandText = selectAllFromTableSQLCommand;
            sqlCommand.CommandType = CommandType.Text;

            NpgsqlDataReader npgsqlDataReader = sqlCommand.ExecuteReader();
            if (npgsqlDataReader.HasRows)
            {
                while (npgsqlDataReader.Read())
                {
                    applications.Add(new Product(npgsqlDataReader.GetString(0),
                                            npgsqlDataReader.GetString(1)));
                }
            }
            return applications;
        }
    }
}
