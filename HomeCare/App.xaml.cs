using HomeCare.Services.SMS;
using HomeCare.Views.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HomeCare.Views;
using Xamarin.Essentials;

namespace HomeCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SMSEvents.OnSMSReceived += ReciveSMSFromDevice;
       
            if (VersionTracking.IsFirstLaunchEver)
            {
                MainPage = new NavigationPage(new Tutorial());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
            
        }

        static   void ReciveSMSFromDevice(object sender, SMSEventArgs e)
        {
              Acr.UserDialogs.UserDialogs.Instance.Alert(e.Message, "", "باشه");
        }
        protected override void OnStart()
        {
            VersionTracking.Track();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
