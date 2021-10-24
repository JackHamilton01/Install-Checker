using InstallChecker.Desktop.Models;
using InstallChecker.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace InstallChecker.Services
{
    public class FileService : IFileService
    {
        IDatabaseConnection databaseConnection;
        IXMLSerialization xmlService;

        private const string SettingsFolderName = "ToDoList_Settings";
        private string defaultSavePath => Path.Combine(Directory.GetCurrentDirectory(), SettingsFolderName);

        public FileService(IDatabaseConnection databaseConnection, IXMLSerialization saveToXMLService)
        {
            this.databaseConnection = databaseConnection;
            this.xmlService = saveToXMLService;
        }

        public void SaveApplicationSettings(Product application, IFileService fileService)
        {
            databaseConnection.SaveApplicationToDatabase(application);
            xmlService.Serialize(application, fileService);
        }

        public bool CheckIfFileExists(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        public ObservableCollection<Product> GetSavedProducts()
        {
            string[] filePaths = Directory.GetFiles(FileSettings.SavedApplicationsPath, "*.xml", SearchOption.AllDirectories);
            ObservableCollection<Product> productList = new ObservableCollection<Product>();

            foreach (var filePath in filePaths)
            {
                Product product = xmlService.Deserialize(filePath);
                productList.Add(product);
            }
            return productList;
        }
    }
}
