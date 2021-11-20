using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
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
        public void ShowAlert(string title, string body, Intent intent)
        {
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            int notificationId = 1;
            String channelId = Constants.FOREGROUND_CHANNEL_ID;
            var importance = NotificationImportance.Max;
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);
            var notifBuilder = new NotificationCompat.Builder(context, channelId)
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSmallIcon(Resource.Mipmap.icon)
                .SetOngoing(true)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(channelId, "HomeCare", importance);
                notificationChannel.Importance = importance;
                notificationChannel.EnableLights(true);
                notificationChannel.SetShowBadge(true);
                notificationChannel.EnableVibration(false);
                 
                if (notificationManager != null)
                {
                    notifBuilder.SetChannelId(channelId);
                    notificationManager.CreateNotificationChannel(notificationChannel);
                }
            } 
            if (notificationManager != null) notificationManager.Notify(notificationId, notifBuilder.Build());
        }
    }
}