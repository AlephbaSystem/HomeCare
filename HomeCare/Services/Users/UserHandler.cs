using HomeCare.Models;
using HomeCare.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HomeCare.Services.Users
{
    class UserHandler
    {
        public DevicesDatabase devicesDatabase;

        public UserHandler()
        {
            devicesDatabase = new DevicesDatabase();
        }

        public Devices GetCurrentUser()
        {
            try
            {
                var cr = GetAllUsers();
                var crr = cr.Where(x => x.Selected == true).FirstOrDefault();
                if (crr is null)
                {
                    crr = cr.FirstOrDefault();
                }
                if (crr is null)
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("لطفا در بخش تنظیمات شماره سیمکارت دستگاه را وارد نمایید.");
                }
                return crr;
            }
            catch
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("لطفا در بخش تنظیمات شماره سیمکارت دستگاه را وارد نمایید.");
                return null;
            }
        }

        public List<Devices> GetAllUsers()
        {
            return devicesDatabase.GetDevices().ToList();
        }

        public string InsertDevice(string Name, string Phone)
        {
            Devices devices = new Devices();
            devices.Name = Name;
            devices.Phone = Phone;
            return devicesDatabase.AddDevice(devices);
        }
        public string RemoveDevice(Devices devices)
        {
            return devicesDatabase.DeleteDevice(devices);
        }
        public string UpdateDevice(Devices devices)
        {
            return devicesDatabase.UpdateDevice(devices);
        }
    }
}
