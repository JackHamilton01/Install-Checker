using InstallChecker.Desktop.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop.Events
{
    class ModifyProductEvent : PubSubEvent<Product>
    {
        public string ApplicationName { get; set; }
        public string ApplicationPath { get; set; }

        public ModifyProductEvent(string applicationName, string applicationPath)
        {
            ApplicationName = applicationName;
            ApplicationPath = applicationPath;
        }

        public ModifyProductEvent()
        {

        }
    }
}
