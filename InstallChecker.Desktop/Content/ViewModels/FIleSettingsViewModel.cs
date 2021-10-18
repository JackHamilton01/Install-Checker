using Install_Checker.Exceptions;
using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Application = InstallChecker.Desktop.Models.Application;

namespace InstallChecker.Desktop.Content.ViewModels
{
    class FileSettingsViewModel : BindableBase
    {
        IFileService fileService;

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public DelegateCommand SaveApplicationCommand { get; set; }

        public FileSettingsViewModel(IFileService saveFileService)
        {
            this.fileService = saveFileService;
            SaveApplicationCommand = new DelegateCommand(SaveApplication);
        }

        private void SaveApplication()
        {
            try
            {
                fileService.SaveApplicationSettings(new Application(ApplicationName, ApplicationPath), fileService);
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
