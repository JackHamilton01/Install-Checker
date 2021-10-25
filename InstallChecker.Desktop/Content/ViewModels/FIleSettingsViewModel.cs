using Install_Checker.Exceptions;
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

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public DelegateCommand SaveApplicationCommand { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public FileSettingsViewModel(IFileService saveFileService, IEventAggregator eventAggregator)
        {
            this.fileService = saveFileService;
            this.eventAggregator = eventAggregator;
            SaveApplicationCommand = new DelegateCommand(SaveApplication);

        }

        private void SaveApplication()
        {
            try
            {
                DataAccess.Products.Add(new Product(ApplicationName, ApplicationPath));
                fileService.SaveApplicationSettings(new Product(ApplicationName, ApplicationPath), fileService);

                eventAggregator.GetEvent<ProductSavedEvent>().Publish(new Product(ApplicationName, ApplicationPath));
            }
            catch (FileAlreadyExistsException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
