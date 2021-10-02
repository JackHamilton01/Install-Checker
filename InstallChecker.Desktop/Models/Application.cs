using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop.Models
{
    public class Application
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Application(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
