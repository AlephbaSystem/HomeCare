using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Interfaces;
using HomeCare.Droid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(AntiTheftHelper))]
namespace HomeCare.Droid.Services
{
    internal class AntiTheftHelper : INotification
    {
        private static Context context = global::Android.App.Application.Context;
        public void ShowAlert(string address, string message, Intent mainIntent)
        {
            Android.Net.Uri alarmUri = Android.Net.Uri.Parse($"{ContentResolver.SchemeAndroidResource}://{Application.Context.PackageName}/{Resource.Raw.car_alarm}");
            var mNotificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            NotificationChannel notificationChannel = new NotificationChannel(Constants.FOREGROUND_CHANNEL_ID, "HomeCare", NotificationImportance.Max);
            notificationChannel.Importance = NotificationImportance.Max;
            notificationChannel.SetShowBadge(true);
            notificationChannel.SetBypassDnd(true);
            notificationChannel.LockscreenVisibility = NotificationVisibility.Public;

            var pendingIntent = PendingIntent.GetActivity(context, 0, mainIntent, PendingIntentFlags.UpdateCurrent);
            var notification = new Notification.Builder(context, Constants.FOREGROUND_CHANNEL_ID)
                                                        .SetColor(Android.Resource.Color.DarkerGray)
                                                        .SetContentTitle(address)
                                                        .SetOngoing(true) 
                                                        .SetAutoCancel(true)
                                                        .SetContentText(message)
                                                        .SetSmallIcon(Resource.Mipmap.icon)
                                                        .SetContentIntent(pendingIntent);

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                notification.SetChannelId(Constants.FOREGROUND_CHANNEL_ID);
                mNotificationManager.CreateNotificationChannel(notificationChannel);
                mNotificationManager.Notify(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notification.Build());
            }
        }
    }
}