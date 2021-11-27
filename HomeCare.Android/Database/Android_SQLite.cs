using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Database;
using HomeCare.Services.Database;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Android_SQLite))]
namespace HomeCare.Droid.Database
{
    class Android_SQLite : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            try
            {
                var dbName = "HomeCare.sqlite";
                var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                var path = System.IO.Path.Combine(dbPath, dbName);
                var conn = new SQLite.SQLiteConnection(path);
                return conn;
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "Android_SQLite.GetConnection" }
  };
                Crashes.TrackError(e, properties);
            }
            return null;
        }
    }
}