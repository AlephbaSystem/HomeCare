using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeCare.ViewModels
{
    public class ZoneSettingViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ZoneSettingViewModel()
        {
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
