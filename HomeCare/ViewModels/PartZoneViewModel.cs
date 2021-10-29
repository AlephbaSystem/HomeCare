using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class PartZoneViewModel: INotifyPropertyChanged
    {
        private bool _partZone1;
        private bool _partZone2;
        private bool _partZone3;
        private bool _partZone4;
        private bool _partZone5;
        private bool _partZone6;
        private bool _partZone7;
        private bool _partZone8;
        private bool _partZone9;
        public event PropertyChangedEventHandler PropertyChanged;

        public PartZoneViewModel()
        {
            SendPartZone = new Command(LunchSendPartZone);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool PartZone1
        {
            get { return _partZone1; }
            set
            {
                _partZone1 = value;
                NotifyPropertyChanged(nameof(PartZone1));
            }
        }

        public bool PartZone2
        {
            get { return _partZone2; }
            set
            {
                _partZone2 = value;
                NotifyPropertyChanged(nameof(PartZone2));
            }
        }

        public bool PartZone3
        {
            get { return _partZone3; }
            set
            {
                _partZone3 = value;
                NotifyPropertyChanged(nameof(PartZone3));
            }
        }

        public bool PartZone4
        {
            get { return _partZone4; }
            set
            {
                _partZone4 = value;
                NotifyPropertyChanged(nameof(PartZone4));
            }
        }

        public bool PartZone5
        {
            get { return _partZone5; }
            set
            {
                _partZone5 = value;
                NotifyPropertyChanged(nameof(PartZone5));
            }
        }

        public bool PartZone6
        {
            get { return _partZone6; }
            set
            {
                _partZone6 = value;
                NotifyPropertyChanged(nameof(PartZone6));
            }
        }

        public bool PartZone7
        {
            get { return _partZone7; }
            set
            {
                _partZone7 = value;
                NotifyPropertyChanged(nameof(PartZone7));
            }
        }

        public bool PartZone8
        {
            get { return _partZone8; }
            set
            {
                _partZone8 = value;
                NotifyPropertyChanged(nameof(PartZone8));
            }
        }

        public bool PartZone9
        {
            get { return _partZone9; }
            set
            {
                _partZone9 = value;
                NotifyPropertyChanged(nameof(PartZone9));
            }
        }


        public string GetZones()
        {
            string ans = "";
            if (PartZone1)
            {
                ans += "1";
            }
            if(PartZone2)
            {
                ans += "2";
            }
            if (PartZone3)
            {
                ans += "3";
            }
            if (PartZone4)
            {
                ans += "4";
            }
            if (PartZone5)
            {
                ans += "5";
            }
            if (PartZone6)
            {
                ans += "6";
            }
            if (PartZone7)
            {
                ans += "7";
            }
            if (PartZone8)
            {
                ans += "8";
            }
            if (PartZone9)
            {
                ans += "9";
            }
            return ans;
        }

        private void LunchSendPartZone()
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            if (Services.SMS.Commands.SetPartZone(GetZones()))
            {
                UserDialogs.Instance.Toast("تنظیمات پارت زون با موفقیت انجام شد.");
            }
        }

        public ICommand SendPartZone { get; }

    }
}
