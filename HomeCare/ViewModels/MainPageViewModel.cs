using Acr.UserDialogs;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using HomeCare.Models;
using System.Collections.ObjectModel;
using HomeCare.Services.SMS;

namespace HomeCare.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Models.Menu> _items;
        private ObservableCollection<Models.Devices> _selectDevice;
        private bool _isLoopDevice;
        public bool IsLoopDevice
        {
            get
            {
                return _isLoopDevice;
            }
            set
            {
                _isLoopDevice = value;
                OnPropertyChanged(nameof(IsLoopDevice));
            }
        }
        public MainPageViewModel()
        {
            StatusDeviceCommand = new Command(GetStatus);
            LockDeviceCommand = new Command(SetToLockDevice);
            UnLockDeviceCommand = new Command(SetToUnLockDevice);
            HalfLockDeviceCommand = new Command(SetToHalfLockDevice);

            SMSEvents.OnSMSReceived += ReciveSMSFromDevice;
            OnMenu();
            
        }

        static void ReciveSMSFromDevice(object sender, SMSEventArgs e)
        {
           if (e.Message.Length > 2)
            {

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
                OnPropertyChanged(nameof(SelectDevice));
            }
        }
        public ObservableCollection<Models.Menu> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private void GetStatus()
        {
            Task.Delay(100);
            Services.SMS.Commands.Status();
            UserDialogs.Instance.Toast("درخواست وضعیت با موفقیت ارصال شد.");
        }

        private void SetToLockDevice()
        {
            Task.Delay(100);
            Services.SMS.Commands.Close();
            UserDialogs.Instance.Toast("درخواست قفل کردن دستگاه با موفقیت ارسال شد.");
        }

        private void SetToHalfLockDevice()
        {
            Task.Delay(100);
            Services.SMS.Commands.PartialOpen();
            UserDialogs.Instance.Toast("درخواست نیمه باز کردن دستگاه با موفقیت ارسال شد.");
        }

        private void SetToUnLockDevice()
        {
            Task.Delay(100);
            Services.SMS.Commands.Open();
            UserDialogs.Instance.Toast("درخواست باز کردن دستگاه با موفقیت ارسال شد.");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnMenu()
        { 
            SelectDevice = new ObservableCollection<Devices>(new Services.Users.UserHandler().GetAllUsers().OrderByDescending(x => x.Selected));
            if (SelectDevice.Count <=0)
            {
                SelectDevice.Add(new Devices() { Name = "مدیریت دستگاه ها", Phone = "دستگاه فعال نیست" }); 
            }
            if (SelectDevice.Count <= 1)
            { 
                IsLoopDevice = false;
            } else
            { 
                IsLoopDevice = true;
            }
            Items = new ObservableCollection<Models.Menu>
            {
                new Models.Menu
                {
                    Title = "هوشمند سازی",
                    ImageUrl = "ai.png"
                },
                new Models.Menu
                {
                    Title = "تنظیمات رله",
                    ImageUrl = "relle.png"
                },
                new Models.Menu
                {
                    Title = "تنظیمات ریموت",
                    ImageUrl = "remote.png"
                },
                new Models.Menu
                {
                    Title = "تنظیمات",
                    ImageUrl = "settings.png"
                },
            };
        }

        public ICommand StatusDeviceCommand { get; }
        public ICommand LockDeviceCommand { get;}
        public ICommand UnLockDeviceCommand { get;}
        public ICommand HalfLockDeviceCommand { get;}
    }
}
