using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop.ViewModels
{
    public class FIleSettingsViewModel : BindableBase
    {
        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public DelegateCommand SaveApplicationCommand { get; set; }

        public FIleSettingsViewModel()
        {
            SaveApplicationCommand = new DelegateCommand(SaveApplication);
        }

        private void SaveApplication()
        {
            throw new NotImplementedException();
        }
    }
}
