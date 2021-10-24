using InstallChecker.Desktop.Models;
using InstallChecker.Desktop.Services;
using InstallChecker.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InstallChecker.Content.ViewModels
{
    class ApplicationsViewModel : BindableBase
    {
        IDatabaseConnection databaseConnection;
        IXMLSerialization xmlSerialization;
        IFileService fileService;

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public ObservableCollection<Product> Products{ get; set; }

        public ApplicationsViewModel(IDatabaseConnection databaseConnection, IXMLSerialization xmlSerialization, IFileService fileService)
        {
            this.databaseConnection = databaseConnection;
            this.xmlSerialization = xmlSerialization;
            this.fileService = fileService;

            DataAccess.Products.Add(new Product(ApplicationName, ApplicationPath));
            Products = DataAccess.Products;
            Products = fileService.GetSavedProducts();
            //Products = databaseConnection.GetSavedItemsFromDatabase();
            fileService.ProductsExist(Products);
        }
    }
}