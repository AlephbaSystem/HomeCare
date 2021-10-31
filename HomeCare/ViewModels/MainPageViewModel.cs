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
        private Models.Status _statusDevice;
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
        public Status StatusDevice
        {
            get
            {
                return _statusDevice;
            }
            set
            {
                _statusDevice = value;
                OnPropertyChanged(nameof(StatusDevice));
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

        private void ReciveSMSFromDevice(object sender, SMSEventArgs e)
        {
            string phone = new Services.Users.UserHandler().GetCurrentUser().Phone;
            if (e.PhoneNumber != phone)
            {
                return;
            }
            var x = 0;
            try
            {
                x = e.Message.Split('\n').Length;
            }
            catch
            {

            }
            if (x == 12)
            {
                var y = e.Message.Split('\n');
                Status stat = new Status();
                try
                {
                    stat.SV = y[1].Split(':')[1];
                    stat.IMEI = y[2].Split(':')[1];
                    stat.CSQ = y[3].Split(':')[1] + " ٪";
                    stat.MoneyCharge = y[4];
                    stat.DATE = y[5].Split(':')[1];
                    stat.TIME = y[6].Split(':')[1] + ':' + y[6].Split(':')[2];
                    stat.DiARM = y[7];
                    stat.No = y[8];
                    stat.REL1 = y[9].Split(':')[1];
                    stat.REL2 = y[10].Split(':')[1];
                    stat.REL3 = y[11].Split(':')[1];
                    stat.op = false;
                }
                catch
                {
                    hideStatBtn();
                    return;
                }
                StatusDevice = stat; 
            }
        }
        private void hideStatBtn()
        {
            Status stat = new Status();
            stat.SV = "0";
            stat.IMEI = "0";
            stat.CSQ = "0 ٪";
            stat.MoneyCharge = "0";
            stat.DATE = "0";
            stat.TIME = "0";
            stat.DiARM = "0";
            stat.No = "0";
            stat.REL1 = "Off";
            stat.REL2 = "Off";
            stat.REL3 = "Off";
            stat.op = true;
            StatusDevice = stat;
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
            UserDialogs.Instance.Toast("درخواست وضعیت با موفقیت ارسال شد.");
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
            hideStatBtn();
            SelectDevice = new ObservableCollection<Devices>(new Services.Users.UserHandler().GetAllUsers().OrderByDescending(x => x.Selected));
            if (SelectDevice.Count <= 0)
            {
                SelectDevice.Add(new Devices() { Name = "مدیریت دستگاه ها", Phone = "دستگاه فعال نیست" });
            }
            if (SelectDevice.Count <= 1)
            {
                IsLoopDevice = false;
            }
            else
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
                    Title = "تنظیمات",
                    ImageUrl = "settings.png"
                },
            };
        }

        public ICommand StatusDeviceCommand { get; }
        public ICommand LockDeviceCommand { get; }
        public ICommand UnLockDeviceCommand { get; }
        public ICommand HalfLockDeviceCommand { get; }
    }
}
