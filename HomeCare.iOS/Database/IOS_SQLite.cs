using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using SQLite;
using HomeCare.iOS.Database;
using HomeCare.Services.Database;
using System.IO;

[assembly: Dependency(typeof(IOS_SQLite))]
namespace HomeCare.iOS.Database
{
    class IOS_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "HomeCare.sqlite";
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(dbPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, dbName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}