using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeCare.Droid.Services
{
    public class SMSService : Service
    { 
        private static int SERVICE_NOTIFICATION_ID = 54321;
        private static String CHANNEL_ID = "Notification service";

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
    }
}