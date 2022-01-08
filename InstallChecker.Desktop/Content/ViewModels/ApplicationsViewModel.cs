using InstallChecker.Desktop.Events;
using InstallChecker.Desktop.Models;
using InstallChecker.Desktop.Services;
using InstallChecker.Services;
using Prism.Events;
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
        IXMLSerialization xmlSerialization;
        IFileService fileService;
        IEventAggregator eventAggregator;

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public ObservableCollection<Product> Products{ get; set; }

        public ApplicationsViewModel(IXMLSerialization xmlSerialization, IFileService fileService, IEventAggregator eventAggregator)
        {
            this.xmlSerialization = xmlSerialization;
            this.fileService = fileService;
            this.eventAggregator = eventAggregator;

            DataAccess.Products.Add(new Product(ApplicationName, ApplicationPath));
            Products = DataAccess.Products;
            Products = fileService.GetSavedProducts();
            //Products = databaseConnection.GetSavedItemsFromDatabase();
            fileService.ProductsExist(Products);

            eventAggregator.GetEvent<ProductSavedEvent>().Subscribe(OnProductReceived);
        }

        private void OnProductReceived(Product product)
        {
            Products.Add(product);
            fileService.CheckIfFileExists(product);
        }
    }
}