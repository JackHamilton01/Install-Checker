using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop.ViewModels
{
    public class FileSettingsViewModel : BindableBase
    {
        ISaveFileService saveFileService;

        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public DelegateCommand SaveApplicationCommand { get; set; }

        public FileSettingsViewModel(ISaveFileService saveFileService)
        {
            this.saveFileService = saveFileService;
            SaveApplicationCommand = new DelegateCommand(SaveApplication);
        }

        private void SaveApplication()
        {
            Application application = new Application(ApplicationName, ApplicationPath);
            saveFileService.SaveApplicationSettings(application);
        }
    }
}
