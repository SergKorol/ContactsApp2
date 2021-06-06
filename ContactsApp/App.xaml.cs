using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string dbName = "Contact.db";
        private static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string dbPath = System.IO.Path.Combine(folderPath, dbName);
    }
}