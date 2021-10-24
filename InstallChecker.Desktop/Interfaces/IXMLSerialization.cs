using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InstallChecker.Desktop.Services
{
    public interface IXMLSerialization
    {
        Product Deserialize(string path);
        void Serialize(Product application, IFileService fileService);
    }
}