using InstallChecker.Desktop.Models;
using NewToDoList.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InstallChecker.Services
{
    public class DatabaseConnection : IDatabaseConnection
    {
        ISQLCommandSenderService SQLCommandSenderService;

        public DatabaseConnection(ISQLCommandSenderService SQLCommandSenderService)
        {
            this.SQLCommandSenderService = SQLCommandSenderService;
        }

        public static NpgsqlConnection ConnectToDatabase()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DatabaseHelper.ConnectionString(DatabaseHelper.ConnectionStringName)))
            {
                return connection;
            }
        }

        public void SaveApplicationToDatabase(Application application)
        {
            SQLCommandSenderService.SaveToDatabase(application);
        }

        public ObservableCollection<Application> GetSavedItemsFromDatabase()
        {
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(DatabaseHelper.ConnectionString(DatabaseHelper.ConnectionStringName)))
            {
                return SQLCommandSenderService.GetApplications(npgsqlConnection);
            }
        }
    }
}
