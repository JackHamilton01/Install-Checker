using Install_Checker.Exceptions;
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
        IXMLSerialization xmlService;

        private const string SettingsFolderName = "ToDoList_Settings";
        private string defaultSavePath => Path.Combine(Directory.GetCurrentDirectory(), SettingsFolderName);

        public FileService(IXMLSerialization saveToXMLService)
        {
            this.xmlService = saveToXMLService;
        }

        public void SaveApplicationSettings(Product product, IFileService fileService)
        {
            product.ProductID = GetLastProductID() + 1;
            //databaseConnection.SaveApplicationToDatabase(product);
            xmlService.Serialize(product, fileService);
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

        public int GetLastProductID()
        {
            int largestID = 0;
            ObservableCollection<Product> savedProducts = GetSavedProducts();

            foreach (var product in savedProducts)
            {
                if (product.ProductID >= largestID)
                {
                    largestID = product.ProductID;
                }
            }

            return largestID;
        }

        public void MakeProductEdits(Product productBeforeModified, Product product, IFileService fileService)
        {
            string replacedFileName = $"{FileSettings.SavedApplicationsPath}{productBeforeModified.Name}.xml";
            File.Delete(replacedFileName);
            product.ProductID = productBeforeModified.ProductID;
            xmlService.Serialize(product, fileService);
        }
    }
}
