using Acr.UserDialogs;
using HomeCare.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDevice : ContentPage
    {
        private UserHandler userHandler;
        public AddDevice()
        {
            InitializeComponent();
            userHandler = new UserHandler();
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");
            this.Title = "Add Device";
        }
        public void InsertDevice(object o, EventArgs e)
        {
            if (IsValidPhone(devicePhone.Text))
            {
                if (devicePhone.Text.StartsWith("0"))
                {
                    this.devicePhone.Text = "+98" + this.devicePhone.Text.Substring(1);
                }
                if (devicePhone.Text.StartsWith("98"))
                {
                    this.devicePhone.Text = "+98" + this.devicePhone.Text.Substring(2);
                }
                if (devicePhone.Text.StartsWith("00"))
                {
                    this.devicePhone.Text = "+98" + this.devicePhone.Text.Substring(2);
                }
                if (userHandler.InsertDevice(deviceName.Text, devicePhone.Text) == "success")
                {
                    UserDialogs.Instance.Toast(new ToastConfig($"device {deviceName.Text} with {devicePhone.Text} phone number has been added.")
                                       .SetDuration(TimeSpan.FromSeconds(5)));
                }
            }
            else
            {
                UserDialogs.Instance.Toast(new ToastConfig($"{devicePhone.Text} is invalid phone number.")
                                   .SetDuration(TimeSpan.FromSeconds(5)));
            }
            deviceName.Text = "";
            devicePhone.Text = "";
        }
        public async void ShowDevices(object o, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewDevice());
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
    }
}