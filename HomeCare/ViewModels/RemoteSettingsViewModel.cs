using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using HomeCare.Models;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class RemoteSettingsViewModel : INotifyPropertyChanged
    {  
        public ICommand AddRemote { get; }

        private int _userID;
        private int _remoteID;
        private List<Remote> _remoteList;
        private Remote _selectedRemote;
        public List<Remote> RemoteList
        {
            get { return _remoteList; }
            set
            {
                _remoteList = value;
                NotifyPropertyChanged(nameof(RemoteList));
            }
        }
        public Remote SelectedRemote
        {
            get { return _selectedRemote; }
            set
            {
                _selectedRemote = value;
                NotifyPropertyChanged(nameof(SelectedRemote));
            }
        } 
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                NotifyPropertyChanged(nameof(UserID));
            }
        }
        public int RemoteId
        {
            get { return _remoteID; }
            set
            {
                _remoteID = value;
                NotifyPropertyChanged(nameof(RemoteId));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RemoteSettingsViewModel()
        {
            RemoteId = 1;
            UserID = 1;
            RemoteList = Remote.GetAll();
            SelectedRemote = RemoteList.FirstOrDefault();

            AddRemote = new Command(LunchAddRemote); 
        } 
        private void LunchAddRemote()
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            if (Services.SMS.Commands.SetRemote(UserID, RemoteId, SelectedRemote.Code))
            {
                string message = "استعلام مربوط به کاربر " + UserID + " با موفقیت ارسال شد.";
                UserDialogs.Instance.Toast(message);
            }
        } 
    }
}
