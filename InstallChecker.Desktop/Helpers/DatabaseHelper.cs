using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NewToDoList.Helpers
{
    public class DatabaseHelper
    {
        public static string ConnectionStringName { get; private set; } = "postgres";

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
