using HomeCare.Services.SMS; 
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HomeCare.Views;
using Xamarin.Essentials;
using HomeCare.Interfaces;

namespace HomeCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("IsAppFirstLaunchEver"))
            {
                Preferences.Set("IsAppFirstLaunchEver", "false");
                MainPage = new NavigationPage(new Tutorial());
            }
            else
            {
                SMSEvents.OnSMSReceived += ReciveSMSFromDevice;
                MainPage = new NavigationPage(new MainPage());
            }
        }

        static void ReciveSMSFromDevice(object sender, SMSEventArgs e)
        {
            string phone = new Services.Users.UserHandler().GetCurrentUser().Phone;
            if (e.PhoneNumber != phone)
            {
                return;
            }
            var x = 0;
            try
            {
                x = e.Message.Split('\n').Length;
            }
            catch
            {

            }
            if (x == 12)
            {
                return;
            }
            Acr.UserDialogs.UserDialogs.Instance.Alert(e.Message, "", "باشه");

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {  
        }

        protected override void OnResume()
        { 
        }
    }
}
