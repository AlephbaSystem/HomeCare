using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

using HomeCare.Models;

namespace HomeCare.ViewModels
{
    public class UserAccessViewModel : INotifyPropertyChanged
    {
        private string _userId;
        private string _phone;
        private string _name;
        private string _shift;
        private bool _hasRelleControl;
        private bool _isManager;
        private bool _isEnable;
        private bool _isDisable;
        private bool _hasCall;
        private bool _hasText;

        public UserAccessViewModel()
        {
            OnMenu();
            UserQuery = new Command(LunchUserQuery);
            UserDelete = new Command(LunchUserDelete);
            SendShift = new Command(LunchSendShift);
            AddUser = new Command(LunchAddUser);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                NotifyPropertyChanged(nameof(UserId));
            }
        }

        public string Shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                NotifyPropertyChanged(nameof(Shift));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public bool HasRelleControl
        {
            get { return _hasRelleControl; }
            set
            {
                _hasRelleControl = value;
                NotifyPropertyChanged(nameof(HasRelleControl));
            }
        }

        public bool IsManager
        {
            get { return _isManager; }
            set
            {
                _isManager = value;
                NotifyPropertyChanged(nameof(IsManager));
                IfIsManager();
            }
        }

        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                NotifyPropertyChanged(nameof(IsEnable));
            }
        }

        public bool IsDisable
        {
            get { return _isDisable; }
            set
            {
                _isDisable = value;
                NotifyPropertyChanged(nameof(IsDisable));
            }
        }

        public bool HasText
        {
            get { return _hasText; }
            set
            {
                _hasText = value;
                NotifyPropertyChanged(nameof(HasText));
            }
        }

        public bool HasCall
        {
            get { return _hasCall; }
            set
            {
                _hasCall = value;
                NotifyPropertyChanged(nameof(HasCall));
            }
        }

        public void IfIsManager()
        {
            if (IsManager)
            {
                HasRelleControl = true;
                IsEnable = true;
                IsDisable = true;
                HasCall = true;
                HasText = true;
            }

        }

        public void OnMenu()
        {
            UserId = "1";
            Shift = "بدون شیفت";
        }

        private void LunchUserQuery()
        {
            try
            {
                DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();

                if(Services.SMS.Commands.UserInquire(int.Parse(UserId)))
                {
                    string message = "استعلام مربوط به کاربر " + UserId + " با موفقیت ارسال شد.";
                    UserDialogs.Instance.Toast(message);
                }
                else
                {
                    UserDialogs.Instance.Toast("لطفا در بخش تنظیمات شماره سیمکارت دستگاه را وارد نمایید.");
                }
               
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
        }

        private void LunchUserDelete()
        {
            try
            {
                DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
                Services.SMS.Commands.RemoveUser(int.Parse(UserId));

                string message = "حذف کاربر شماره " + UserId + "با موفقیت ارسال شد.";
                UserDialogs.Instance.Toast(message);
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
        }

        private void LunchSendShift()
        {
            try
            {
                string shiftType;
                switch(Shift)
                {
                    case "بدون شیفت":
                        shiftType = "D";
                        break;
                    case "شیفت ۱":
                        shiftType = "A";
                        break;
                    case "شیفت ۲":
                        shiftType = "B";
                        break;
                    default:
                        shiftType = "F";
                        break;
                }
                DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
                Services.SMS.Commands.UserShift(int.Parse(UserId), shiftType);
                string message = "فعال سازی شیفت برای کاربر " + UserId + " با موفقیت ارسال شد.";
                UserDialogs.Instance.Toast(message);
            }
            catch(Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
        }

        private void LunchAddUser()
        {
            UserAccess user = new UserAccess(UserId, Phone, Name, IsManager, HasRelleControl, IsEnable, IsDisable, HasCall, HasText);
            if (user.IsValidPhone())
            {
                try
                {
                    DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
                    Services.SMS.Commands.AddUser(int.Parse(UserId), Phone, user.GetAccess());

                    string message = "درخواست افزودن/ویرایش کاربر " + UserId + " با موفقیت ارسال شد."; ;
                    UserDialogs.Instance.Toast(message);
                }
                catch (Exception ex)
                {
                    Console.Write("Error info:" + ex.Message);
                }
            }
            else
            {
                UserDialogs.Instance.Toast("شماره تلفن معتبر نیست٬ لطفا دوباره تلاش کنید.");
            }
        }

        public ICommand UserQuery { get;}
        public ICommand UserDelete { get; }
        public ICommand SendShift { get; }
        public ICommand AddUser { get; }
    }
}