using Acr.UserDialogs;
using HomeCare.Models;
using HomeCare.Services.Users;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewDevice : ContentPage, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private UserHandler userHandler;
        private ObservableCollection<Devices> _listOfItems;
        public ObservableCollection<Devices> ListOfItems
        {
            get
            {
                return _listOfItems;
            }
            set
            {
                _listOfItems = value;
                NotifyPropertyChanged(nameof(ListOfItems));
            }
        }
        public void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Devices iUser = ListOfItems.Where(x => x.Name == mi.CommandParameter.ToString()).FirstOrDefault();
            Devices Tmp = iUser;
            bool cnsl = false;
            UserDialogs.Instance.ActionSheet(new ActionSheetConfig()
                           .SetTitle("Edit")
                           .Add("Name", async () =>
                           {
                               var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                               {
                                   Title = $"Editing {iUser.Name}",
                                   Text = iUser.Name,
                                   IsCancellable = true
                               });
                               if (result.Ok)
                               {
                                   cnsl = true;
                                   Tmp.Name = result.Text;
                                   ListOfItems.Remove(iUser);
                                   ListOfItems.Add(Tmp);
                                   this._UpdateDevic(Tmp);

                               }
                           })
                           .Add("Phone", async () =>
                           {
                               var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                               {
                                   Title = $"Editing {iUser.Phone}",
                                   Text = iUser.Phone,
                                   IsCancellable = true
                               });
                               if (result.Ok)
                               {
                                   cnsl = true;
                                   Tmp.Phone = result.Text;
                                   ListOfItems.Remove(iUser);
                                   ListOfItems.Add(Tmp);
                                   this._UpdateDevic(Tmp);
                               }
                           })
                           .SetCancel()
                       );

            if (cnsl)
            {
                UserDialogs.Instance.Toast(new ToastConfig($"{iUser.Name} Changed.")
                                     .SetDuration(TimeSpan.FromSeconds(5))
                                     .SetPosition(ToastPosition.Bottom)
                                     .SetAction(x => x
                                         .SetText("Undo")
                                         .SetAction(() =>
                                         {
                                             ListOfItems.Remove(Tmp);
                                             ListOfItems.Add(iUser);
                                             this._UpdateDevic(iUser);
                                         })
                                     )
                                 );
                ListOfItems = ListOfItems;
            }
        }
        public bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void _AddDDevic(string devicePhoneText, string deviceNameText)
        {
            if (IsValidPhone(devicePhoneText))
            {
                if (devicePhoneText.StartsWith("0"))
                {
                    devicePhoneText = "+98" + devicePhoneText.Substring(1);
                }
                if (devicePhoneText.StartsWith("98"))
                {
                    devicePhoneText = "+98" + devicePhoneText.Substring(2);
                }
                if (devicePhoneText.StartsWith("00"))
                {
                    devicePhoneText = "+98" + devicePhoneText.Substring(2);
                }
                if (userHandler.InsertDevice(deviceNameText, devicePhoneText) == "success")
                {
                    UserDialogs.Instance.Toast(new ToastConfig($"device {deviceNameText} with {devicePhoneText} phone number has been added.")
                                       .SetDuration(TimeSpan.FromSeconds(5)));
                }
            }
            else
            {
                UserDialogs.Instance.Toast(new ToastConfig($"{devicePhoneText} is invalid phone number.")
                                   .SetDuration(TimeSpan.FromSeconds(5)));
            }
        }
        private void _RemoveDevic(Devices device)
        {
            if (userHandler.RemoveDevice(device) == "success")
            {
                UserDialogs.Instance.Toast(new ToastConfig($"device {device.Name} with {device.Phone} phone number has been removed.")
                                   .SetDuration(TimeSpan.FromSeconds(5)));
            }
        }
        private void _UpdateDevic(Devices device)
        {
            if (userHandler.UpdateDevice(device) == "success")
            {
                UserDialogs.Instance.Toast(new ToastConfig($"device {device.Name} with {device.Phone} phone number has been updated.")
                                   .SetDuration(TimeSpan.FromSeconds(5)));
            }
        }
        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Devices iUser = ListOfItems.Where(x => x.Name == mi.CommandParameter.ToString()).FirstOrDefault();
            await DisplayAlert("Delete", iUser.Name, "OK");
            bool answer = await DisplayAlert("Delete item", $"Would you like to remove {iUser.Name} permanently?", "Yes", "No");
            if (answer)
            {
                ListOfItems.Remove(iUser);
                //ListOfItems = new ObservableCollection<User>(ListOfItems.Where(x => x.Name != iName).ToList()); 
                this._RemoveDevic(iUser);


                UserDialogs.Instance.Toast(new ToastConfig($"{iUser.Name} Deleted.")
                    .SetDuration(TimeSpan.FromSeconds(5))
                    .SetPosition(ToastPosition.Bottom)
                    .SetAction(x => x
                        .SetText("Undo")
                        .SetAction(() =>
                        {
                            ListOfItems.Add(iUser);
                            this._AddDDevic(iUser.Phone, iUser.Name);
                        })
                    )
                );
                ListOfItems = ListOfItems;
            }
        }
        public AddNewDevice()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            this.BindingContext = this;
            UpdateList();
        }
        private void UpdateList()
        {
            userHandler = new UserHandler();
            ListOfItems = new ObservableCollection<Devices>(userHandler.GetAllUsers());
            lstDevices.ItemsSource = ListOfItems;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateList();
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDevice());
        }
    }
}