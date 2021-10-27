using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class TimingViewModel : INotifyPropertyChanged
    {
        public ICommand SendShiftOne { get; }
        public ICommand SendShiftTwo { get; }

        private TimeSpan _shiftOneEnter;
        private TimeSpan _shiftTwoEnter;
        private TimeSpan _shiftOneExit;
        private TimeSpan _shiftTwoExit;
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                NotifyPropertyChanged(nameof(UserId));
            }
        }
        public TimeSpan ShiftOneEnter
        {
            get { return _shiftOneEnter; }
            set
            {
                _shiftOneEnter = value;
                NotifyPropertyChanged(nameof(ShiftOneEnter));
            }
        }
        public TimeSpan ShiftTwoEnter
        {
            get { return _shiftTwoEnter; }
            set
            {
                _shiftTwoEnter = value;
                NotifyPropertyChanged(nameof(ShiftTwoEnter));
            }
        }
        public TimeSpan ShiftOneExit
        {
            get { return _shiftOneExit; }
            set
            {
                _shiftOneExit = value;
                NotifyPropertyChanged(nameof(ShiftOneExit));
            }
        }
        public TimeSpan ShiftTwoExit
        {
            get { return _shiftTwoExit; }
            set
            {
                _shiftTwoExit = value;
                NotifyPropertyChanged(nameof(ShiftTwoExit));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TimingViewModel()
        {
            _shiftOneEnter = new TimeSpan(1, 0, 0);
            _shiftTwoEnter = new TimeSpan(1, 0, 0);
            _shiftOneExit = new TimeSpan(1, 0, 0);
            _shiftTwoExit = new TimeSpan(1, 0, 0);

            SendShiftOne = new Command(LunchSendShiftOne);
            SendShiftTwo = new Command(LunchSendShiftTwo);
        }
        private void LunchSendShiftOne()
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            string ste = ShiftOneEnter.ToString(@"hhmm");
            string stx = ShiftOneExit.ToString(@"hhmm");
            if (Services.SMS.Commands.CreateShift(UserId, 1, ste, stx))
            {
                string message = " با موفقیت ارسال شد.";
                UserDialogs.Instance.Toast(message);
            }
        }
        private void LunchSendShiftTwo()
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            string ste = ShiftTwoEnter.ToString(@"hhmm");
            string stx = ShiftTwoExit.ToString(@"hhmm");
            if (Services.SMS.Commands.CreateShift(UserId, 2, ste, stx))
            {
                string message = " با موفقیت ارسال شد.";
                UserDialogs.Instance.Toast(message);
            }
        } 
    }
}
