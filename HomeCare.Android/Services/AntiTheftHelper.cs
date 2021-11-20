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
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AntiTheftHelper))]
namespace HomeCare.Droid.Services
{
    internal class AntiTheftHelper : INotification
    {
        private static Context context = global::Android.App.Application.Context;
        public void ShowAlert(string address, string message)
        {
            Toast.MakeText(context, message, ToastLength.Short).Show();
            Intent mainIntent = new Intent(context, typeof(AlertActivity));
            mainIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTop | ActivityFlags.ReorderToFront);
            mainIntent.PutExtra(address, message);
            context.StartActivity(mainIntent);

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            int notificationId = 1;
            String channelId = Constants.FOREGROUND_CHANNEL_ID;
            String channelName = "HomeCare";
            var importance = NotificationImportance.Max;

            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel mChannel = new NotificationChannel(
                        channelId, channelName, importance);
                notificationManager.CreateNotificationChannel(mChannel);
            }

            Notification notif = DependencyService.Get<INotification>().ReturnNotif(address, message);


            notificationManager.Notify(notificationId, notif);
        }

        public Notification ReturnNotif(String title, String body)
        {
            var manager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            var intent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);

            var notifBuilder = new NotificationCompat.Builder(context, Constants.FOREGROUND_CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSmallIcon(Resource.Mipmap.icon)
                .SetOngoing(true)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            // Building channel if API verion is 26 or above
            if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(Constants.FOREGROUND_CHANNEL_ID, "HomeCare", NotificationImportance.Max);
                notificationChannel.Importance = NotificationImportance.Max;
                notificationChannel.EnableLights(true);
                notificationChannel.SetShowBadge(true);
                notificationChannel.EnableVibration(false);

                var notifManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
                if (notifManager != null)
                {
                    notifBuilder.SetChannelId(Constants.FOREGROUND_CHANNEL_ID);
                    notifManager.CreateNotificationChannel(notificationChannel);
                }
            }
            return notifBuilder.Build();
        }
    }
}