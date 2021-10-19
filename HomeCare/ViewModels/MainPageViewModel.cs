using Acr.UserDialogs;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            StatusDeviceCommand = new Command(GetStatus);
            LockDeviceCommand = new Command(SetToLockDevice);
            UnLockDeviceCommand = new Command(SetToUnLockDevice);
            HalfLockDeviceCommand = new Command(SetToHalfLockDevice);

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

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand StatusDeviceCommand { get; }
        public ICommand LockDeviceCommand { get;}
        public ICommand UnLockDeviceCommand { get;}
        public ICommand HalfLockDeviceCommand { get;}
    }
}
