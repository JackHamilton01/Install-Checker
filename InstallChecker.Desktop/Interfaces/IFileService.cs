using InstallChecker.Desktop.Models;
using System.Collections.ObjectModel;

namespace InstallChecker.Services
{
    public interface IFileService
    {
        void SaveApplicationSettings(Product application, IFileService saveFileService);
        bool CheckIfFileExists(string path);
        ObservableCollection<Product> GetSavedProducts();
        void ProductsExist(ObservableCollection<Product> products);
    }
}