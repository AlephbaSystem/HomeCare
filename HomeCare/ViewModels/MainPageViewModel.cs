using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            StatusDeviceCommand = new Command(GetStatus);
        }

        private void GetStatus(object obj)
        {
            Task.Delay(100);
            
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand StatusDeviceCommand { get; }

    }
}
