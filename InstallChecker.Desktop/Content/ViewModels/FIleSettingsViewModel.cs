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
using System.Text;
using System.Windows;

namespace InstallChecker.Desktop.Content.ViewModels
{
    class FileSettingsViewModel : BindableBase
    {
        IFileService fileService;
        IEventAggregator eventAggregator;
        FolderBrowserService folderBrowserService;

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public DelegateCommand SaveApplicationCommand { get; set; }
        public DelegateCommand BrowseCommand { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private bool productEdited;
        private Product editedProduct;

        public FileSettingsViewModel(IFileService saveFileService, IEventAggregator eventAggregator)
        {
            this.fileService = saveFileService;
            this.eventAggregator = eventAggregator;
            folderBrowserService = new FolderBrowserService();
            SaveApplicationCommand = new DelegateCommand(SaveApplication);
            BrowseCommand = new DelegateCommand(Browse);

            eventAggregator.GetEvent<ModifyProductEvent>().Subscribe(OnProductRecieved);
        }

        private void Browse()
        {
            string path = folderBrowserService.OpenFileExplorer();
            ApplicationPath = path;
        }

        private void SaveApplication()
        {
            try
            {
                if (!productEdited)
                {
                    fileService.SaveApplicationSettings(new Product(ApplicationName, ApplicationPath), fileService);

                    eventAggregator.GetEvent<ProductSavedEvent>().Publish(new Product(ApplicationName, ApplicationPath));
                }
                else
                {
                    eventAggregator.GetEvent<ProductSavedEvent>().Publish(new Product(ApplicationName, ApplicationPath, true));
                }

                ApplicationName = string.Empty;
                ApplicationPath = string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnProductRecieved(Product product)
        {
            ApplicationName = product.Name;
            ApplicationPath = product.Path;
            product.IsEdited = true;
            productEdited = true;
            editedProduct = product;
        }
    }
}
