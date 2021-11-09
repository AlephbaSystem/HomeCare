using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Interfaces;
using HomeCare.Droid.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HomeCare.Droid.Services
{
    [Service(Enabled = true, Label = "HymaxBurglarNotify")]
    public class AntiTheft : Service
    { 
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnCreate()
        {
            base.OnCreate(); 
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Notification notif = DependencyService.Get<INotification>().ReturnNotif();

            StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notif);
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
    }
}