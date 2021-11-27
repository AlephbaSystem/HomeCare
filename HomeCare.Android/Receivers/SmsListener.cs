using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;
using HomeCare.Droid.Interfaces;
using HomeCare.Services.SMS;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using static Android.App.ActivityManager;

namespace HomeCare.Droid.Receivers
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED", "android.intent.action.BOOT_COMPLETED" }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class SmsListener : BroadcastReceiver
    {
        protected string message, address = string.Empty;

        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (intent.Action.Equals("android.provider.Telephony.SMS_RECEIVED"))
                {
                    Bundle bundle = intent.Extras;
                    if (bundle != null)
                    {
                        try
                        {
                            var smsArray = (Java.Lang.Object[])bundle.Get("pdus");

                            foreach (var item in smsArray)
                            {
#pragma warning disable CS0618
                                var sms = SmsMessage.CreateFromPdu((byte[])item);
#pragma warning restore CS0618
                                address = sms.OriginatingAddress;
                                message = sms.MessageBody;
                                if (message.Contains("خطرسرقت"))
                                {
                                    Intent mainIntent = new Intent(context, typeof(AlertActivity));
                                    mainIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTop | ActivityFlags.ReorderToFront);
                                    mainIntent.PutExtra(address, message);
                                    context.StartActivity(mainIntent);
                                    return;
                                }
                                SMSEvents.OnSMSReceived_Event(this, new SMSEventArgs() { PhoneNumber = address, Message = message });
                            }
                        }
                        catch (Exception)
                        {
                            //Something went wrong.
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "SmsListener.OnReceive" }
  };
                Crashes.TrackError(e, properties);
            }
        }
    }
}