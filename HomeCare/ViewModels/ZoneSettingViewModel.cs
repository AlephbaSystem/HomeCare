using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

using HomeCare.Models;
using Acr.UserDialogs;

namespace HomeCare.ViewModels
{
    public class ZoneSettingViewModel: INotifyPropertyChanged
    {
        private string _zoneNumber;
        private string _zoneName;
        private string _zoneType;
        private string _zoneState;
        public event PropertyChangedEventHandler PropertyChanged;

        public ZoneSettingViewModel()
        {
            SetSimZone = new Command(LunchSetSimZone);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ZoneNumber
        {
            get { return _zoneNumber; }
            set
            {
                _zoneNumber = value;
                NotifyPropertyChanged(nameof(ZoneNumber));
            }
        }

        public string ZoneName
        {
            get { return _zoneName; }
            set
            {
                _zoneName = value;
                NotifyPropertyChanged(nameof(ZoneName));
            }
        }

        public string ZoneType
        {
            get { return _zoneType; }
            set
            {
                _zoneType = value;
                NotifyPropertyChanged(nameof(ZoneType));
            }
        }

        public string ZoneState
        {
            get { return _zoneState; }
            set
            {
                _zoneState = value;
                NotifyPropertyChanged(nameof(ZoneState));
            }
        }

        private void LunchSetSimZone()
        {
            int state = ZoneState == "NO" ? 0 : 1;
            int zoneId = int.Parse(ZoneNumber);
            Zone z = new Zone(ZoneType);
            try
            {
                DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();

               if(Services.SMS.Commands.SetZone(zoneId, z.GetTypeZone() , state))
                {
                    string message = "تنظیمات زون سیمی با موفقیت انجام شد.";
                    UserDialogs.Instance.Toast(message);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
        }

        public ICommand SetSimZone { get; }
    }
}
