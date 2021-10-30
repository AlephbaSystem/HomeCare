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
    class DevicesDatabase
    {
        private SQLiteConnection conn;

        //CREATE  
        public DevicesDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Devices>();
        }

        //READ  
        public IEnumerable<Devices> GetDevices()
        {
            var device = (from div in conn.Table<Devices>() select div);
            return device.ToList();
        }
        //INSERT  
        public string AddDevice(Devices device)
        {
            conn.Insert(device);
            return "success";
        }
        //DELETE  
        public string DeleteDevice(Devices device)
        {
            conn.Delete(device);
            return "success";
        }
        public string UpdateDevice(Devices device)
        {
            conn.Update(device);
            return "success";
        } 
    }
}
