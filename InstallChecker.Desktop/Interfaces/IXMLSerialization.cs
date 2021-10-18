using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using System;
using System.Collections.Generic;

namespace InstallChecker.Desktop.Services
{
    public interface IXMLSerialization
    {
        List<Application> Deserialize<T>();
        void Serialize(Application application, IFileService fileService);
    }
}