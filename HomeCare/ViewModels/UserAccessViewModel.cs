using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeCare.ViewModels
{
    public class UserAccessViewModel: INotifyPropertyChanged
    {
        private string _phone;
        private string _name;
        private bool _hasRelleControl;
        private bool _isManager;
        private bool _isEnable;
        private bool _isDisable;
        private bool _hasCall;
        private bool _hasText;

        public UserAccessViewModel()
        {
            OnMenu();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Phone
        {
            get
            {   return _phone; }
            set
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        public string Name
        {
            get{ return _name;}
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
            if(IsManager)
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
        }

    }
}
