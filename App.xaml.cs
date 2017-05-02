using Bookcase.db;
using Bookcase.dialogs;
using Bookcase.model;
using Bookcase.ui.uibases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bookcase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledError;
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var db = new BookcaseDB())
            {
                db.Database.CreateIfNotExists();
            }
        }

        private void OnUnhandledError(object sender, UnhandledExceptionEventArgs e)
        {
            var result = System.Windows.MessageBox.Show(String.Format("Error: {0}", e.ExceptionObject.ToString()));
            Application.Current.Shutdown();
        }
    }
}
