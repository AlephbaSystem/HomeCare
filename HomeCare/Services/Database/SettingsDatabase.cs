using HomeCare.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Collections;

namespace HomeCare.Services.Database
{
    class SettingsDatabase
    {
        private SQLiteConnection conn;

        //CREATE  
        public SettingsDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Devices>();
        }

        //READ  
        public IEnumerable<AppSettings> GetAppSettings()
        {
            var device = (from div in conn.Table<AppSettings>() select div);
            return device.ToList();
        }
        //INSERT  
        public string AddAppSetting(AppSettings device)
        {
            conn.Insert(device);
            return "success";
        }
        //DELETE  
        public string DeleteAppSetting(AppSettings device)
        {
            conn.Delete(device);
            return "success";
        }
        public string UpdateAppSetting(AppSettings device)
        {
            conn.Update(device);
            return "success";
        } 
    }
}
