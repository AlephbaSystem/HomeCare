using HomeCare.Services.SMS;
using HomeCare.Views;
using System.Linq;
using Xamarin.Forms;

namespace HomeCare
{
    public partial class App : Application
    {
        public object MobileCenter { get; private set; }

        public App()
        {
            InitializeComponent();

            var stg = new Services.Database.SettingsDatabase();
            var cst = stg.GetAppSettings().ToList();
            if (cst.Count==0)
            {
                stg.AddAppSetting(new Models.AppSettings() { Key = "FirstLaunch", Value = "true" });
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
