﻿using Install_Checker.Exceptions;
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
        public void Serialize(Product product, IFileService fileService)
        {
            string savePath = FileSettings.SavedApplicationsPath + $"{product.Name}.xml";
            try
            {
                if (fileService.CheckIfFileExists(savePath))
                {
                    throw new FileAlreadyExistsException($"Application {product.Name} already exists");
                }

                using (var stream = new FileStream(savePath, FileMode.CreateNew))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(Product));
                    XML.Serialize(stream, product);
                }
            }
            catch (IOException e)
            {
                throw new IOException($"Error occured when saving application, please check correct permissions are granted to the following path: {FileSettings.SavedApplicationsPath}", e.InnerException);
            }
        }

        public Product Deserialize(string path)
        {
            var loadedItems = new ObservableCollection<Product>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Product));
                StreamReader reader = new StreamReader(fs);

                return (Product)xml.Deserialize(reader);
            }
        }
    }
}
