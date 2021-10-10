using InstallChecker.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Services
{
    public class SaveFileService : ISaveFileService
    {
        IDatabaseConnection databaseConnection;

        public SaveFileService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public void SaveApplicationSettings(Application application)
        {
            databaseConnection.SaveApplicationToDatabase(application);
        }
    }
}
