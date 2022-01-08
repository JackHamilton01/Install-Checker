using InstallChecker.Desktop.Events;
using InstallChecker.Desktop.Models;
using InstallChecker.Desktop.Services;
using InstallChecker.Services;
using Prism.Commands;
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
        public DelegateCommand<Product> EditItemCommand { get; set; }

        private Product productBeforeModified;

        public ApplicationsViewModel(IXMLSerialization xmlSerialization, IFileService fileService, IEventAggregator eventAggregator)
        {
            this.xmlSerialization = xmlSerialization;
            this.fileService = fileService;
            this.eventAggregator = eventAggregator;

            Products = new ObservableCollection<Product>(fileService.GetSavedProducts().OrderBy(a => a.ProductID));
            //Products = databaseConnectiontemsFromDatabase();
            fileService.ProductsExist(Products);

            EditItemCommand = new DelegateCommand<Product>(EditItem);

            eventAggregator.GetEvent<ProductSavedEvent>().Subscribe(OnProductReceived);
        }

        private void EditItem(Product product)
        {
            productBeforeModified = new Product(product.Name, product.Path);
            productBeforeModified.ProductID = Products.IndexOf(product);
            eventAggregator.GetEvent<ModifyProductEvent>().Publish(product);
        }

        private void OnProductReceived(Product product)
        {
            if (!product.IsEdited)
            {
                Products.Add(product);
                fileService.CheckIfFileExists(product); 
            }
            else
            {
                product.ProductID = productBeforeModified.ProductID;
                Products[product.ProductID] = product;

                fileService.MakeProductEdits(productBeforeModified, product, fileService);
            }
        }
    }
}