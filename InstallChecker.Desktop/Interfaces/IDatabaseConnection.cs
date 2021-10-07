using InstallChecker.Desktop.Models;
using System.Collections.ObjectModel;

namespace InstallChecker.Services
{
    public interface IDatabaseConnection
    {
        void SaveApplicationToDatabase(Application application);
        ObservableCollection<Application> GetSavedItemsFromDatabase();
    }
}