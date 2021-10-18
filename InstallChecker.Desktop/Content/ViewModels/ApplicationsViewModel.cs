using InstallChecker.Desktop.Models;
using InstallChecker.Desktop.Services;
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
        IXMLSerialization xmlSerialization;

        public ObservableCollection<Application> Applications{ get; set; }
        private List<Application> deserializedApplications;

        public ApplicationsViewModel(IDatabaseConnection databaseConnection, IXMLSerialization xmlSerialization)
        {
            this.databaseConnection = databaseConnection;
            this.xmlSerialization = xmlSerialization;

            Applications = new ObservableCollection<Application>();
            deserializedApplications = new List<Application>();

            Applications = databaseConnection.GetSavedItemsFromDatabase();
            //Application application = xmlSerialization.Deserialize<Application>();
            Applications.Clear();
            //Applications.Add(application);
            //deserializedApplications = xmlSerialization.Deserialize<Application>();
        }
    }
}