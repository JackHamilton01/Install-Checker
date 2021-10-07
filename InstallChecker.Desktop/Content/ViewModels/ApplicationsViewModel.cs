using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InstallChecker.Content.ViewModels
{
    class ApplicationsViewModel : BindableBase
    {
        IDatabaseConnection databaseConnection;

        public ObservableCollection<Application> Applications{ get; set; }

        public ApplicationsViewModel(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;

            Applications = new ObservableCollection<Application>();

            Applications = databaseConnection.GetSavedItemsFromDatabase();
        }
    }
}
