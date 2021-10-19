using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeCare.ViewModels
{
    public class AddDeviceViewModel: INotifyPropertyChanged
    {
        public AddDeviceViewModel()
        {
        }

        private string deviceName;
        private string phone;
        private bool isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string DeviceName
        {
            get { return deviceName; }
            set
            {
                deviceName = value;

                OnPropertyChanged();
            }
        }


    }
}
