﻿using Android.App;
using Android.Content;
using Android.Telephony;
using HomeCare.Droid.Receivers;
using HomeCare.Services.SMS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SendSms))]
namespace HomeCare.Droid.Receivers
{
    public class SendSms : ISendSms
    {
        public bool Send(string address, string message)
        {
            if (address is null) return false;
            var pendingIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, new Intent(Android.App.Application.Context, typeof(MainActivity)).AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask), PendingIntentFlags.NoCreate);
            // updated......
            SmsManager smsM = SmsManager.Default;
            smsM.SendTextMessage(address, null, message, pendingIntent, null);

            return true;
        }
    }
}