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
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public void CheckIfFileExists(Product product)
        {
            if (Directory.Exists(product.Path))
            {
                product.IsInstalled = true;
            }
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

        public void ProductsExist(ObservableCollection<Product> products)
        {
            foreach (var product in products)
            {
                if (Directory.Exists(product.Path))
                {
                    product.IsInstalled = true;
                }
            }
        }
    }
}
