using InstallChecker.Desktop.Models;
using Npgsql;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InstallChecker.Services
{
    public interface ISQLCommandSenderService
    {
        void CreateApplicationsTable();
        void SaveToDatabase(Application application);
        ObservableCollection<Application> GetApplications(NpgsqlConnection npgsqlConnection);
    }
}