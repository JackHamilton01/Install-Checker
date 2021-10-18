using Install_Checker.Exceptions;
using InstallChecker.Desktop.Models;
using InstallChecker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace InstallChecker.Desktop.Services
{
    public class XMLSerialization : IXMLSerialization
    {
        public void Serialize(Application application, IFileService fileService)
        {
            string savePath = FileSettings.SavedApplicationsPath + $"{application.Name}.xml";
            try
            {
                if (fileService.CheckIfFileExists(savePath))
                {
                    throw new FileAlreadyExistsException($"Application {application.Name} already exists");
                }

                using (var stream = new FileStream(savePath, FileMode.CreateNew))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(Application));
                    XML.Serialize(stream, application);
                }
            }
            catch (IOException e)
            {
                throw new IOException($"Error occured when saving application, please check correct permissions are granted to the following path: {FileSettings.SavedApplicationsPath}", e.InnerException);
            }
        }

        public List<Application> Deserialize<T>()
        {
            var loadedItems = new List<Application>();

            using (FileStream fs = new FileStream(FileSettings.SavedApplicationsPath, FileMode.Open))
            {
                XmlSerializer serializedComSettings = new XmlSerializer(typeof(List<Application>));
                StreamReader reader = new StreamReader(fs);

                loadedItems = (List<Application>)serializedComSettings.Deserialize(reader);
                reader.Close();
            }

            return loadedItems;
        }
    }
}
