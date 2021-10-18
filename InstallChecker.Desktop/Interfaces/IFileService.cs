using InstallChecker.Desktop.Models;

namespace InstallChecker.Services
{
    public interface IFileService
    {
        void SaveApplicationSettings(Application application, IFileService saveFileService);
        bool CheckIfFileExists(string path);
    }
}