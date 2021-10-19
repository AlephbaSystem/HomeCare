using HomeCare.Services.SMS;
using HomeCare.Views.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //SMSEvents.OnSMSReceived += OnSMSReceived;
            SMSEvents.OnSMSReceived += c_ThresholdReached;
            MainPage = new NavigationPage(new MainPage());
        }

        static   void c_ThresholdReached(object sender, SMSEventArgs e)
        {
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
