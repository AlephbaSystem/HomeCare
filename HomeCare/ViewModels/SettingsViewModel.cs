using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HomeCare.ViewModels;

using HomeCare.Services.Users;
using HomeCare.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace HomeCare.ViewModels
{
    public class SettingsViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Models.Devices> _selectDevice;
        private string _phone;
        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            OnMenu();
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        public ObservableCollection<Models.Devices> SelectDevice
        {
            get
            {
                return _selectDevice;
            }
            set
            {
                _selectDevice = value;
                NotifyPropertyChanged(nameof(SelectDevice));
            }
        }

        public void OnMenu()
        {
            SelectDevice = new ObservableCollection<Devices>(new Services.Users.UserHandler().GetAllUsers().OrderByDescending(x => x.Selected));
            if(SelectDevice.Count == 0)
            {
                SelectDevice.Add(new Devices() { Name = "مدیریت دستگاه ها", Phone = "دستگاه فعال نیست" });
            }
            Phone = SelectDevice[0].Phone;
        }
    }
}
