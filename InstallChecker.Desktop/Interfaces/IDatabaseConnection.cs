using InstallChecker.Desktop.Models;
using System.Collections.ObjectModel;

namespace InstallChecker.Services
{
    public interface IDatabaseConnection
    {
        void SaveApplicationToDatabase(Product application);
        ObservableCollection<Product> GetSavedItemsFromDatabase();
    }
}