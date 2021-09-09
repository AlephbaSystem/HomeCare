using HomeCare.Services.SMS;
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

            MainPage = new MainPage();
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
