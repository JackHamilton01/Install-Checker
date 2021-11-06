using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace InstallChecker.Desktop.Models
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsInstalled { get; set; }
        public bool IsEdited { get; set; }
        public int ProductID { get; set; }

        public Product(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public Product(string name, string path, bool isEdited)
        {
            Name = name;
            Path = path;
            IsEdited = isEdited;
        }

        // Parameterless constructor for xml serialization
        public Product()
        {

        }
    }
}
