using InstallChecker.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InstallChecker.Desktop.Services
{
    public static class DataAccess
    {
        public static ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
