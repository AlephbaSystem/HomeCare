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
        public void ShowAlert(string address, string message)
        {
            Toast.MakeText(context, message, ToastLength.Short).Show();
            Intent mainIntent = new Intent(context, typeof(AlertActivity));
            mainIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTop | ActivityFlags.ReorderToFront);
            mainIntent.PutExtra(address, message);
            context.StartActivity(mainIntent);
             
            Toast.MakeText(context, message, ToastLength.Short).Show();
            var f96v = (Vibrator)context.GetSystemService(Context.VibratorService);
            long[] vbf = { 100, 200, 200, 500, 500, 400, 400, 100 };
            f96v.Cancel();
            f96v.Vibrate(VibrationEffect.CreateWaveform(vbf, 1));

            var alarmAttributes = new AudioAttributes.Builder()
                       .SetContentType(AudioContentType.Music)
                       .SetUsage(AudioUsageKind.Alarm)
                       .Build();

            Android.Net.Uri alarmUri = Android.Net.Uri.Parse($"{ContentResolver.SchemeAndroidResource}://{Application.Context.PackageName}/{Resource.Raw.car_alarm}");
            var mNotificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            NotificationChannel notificationChannel = new NotificationChannel(Constants.FOREGROUND_CHANNEL_ID, "HomeCare", NotificationImportance.Default);
            notificationChannel.Importance = NotificationImportance.High;
            notificationChannel.EnableLights(true);
            notificationChannel.EnableVibration(true);
            notificationChannel.SetSound(alarmUri, alarmAttributes);
            notificationChannel.SetShowBadge(true);
            notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });
            notificationChannel.SetBypassDnd(true);
            notificationChannel.LockscreenVisibility = NotificationVisibility.Public;

            var pendingIntent = PendingIntent.GetActivity(context, 0, mainIntent, PendingIntentFlags.UpdateCurrent);
            var notification = new Notification.Builder(context, Constants.FOREGROUND_CHANNEL_ID)
                                                        .SetColor(Android.Resource.Color.DarkerGray)
                                                        .SetContentTitle(address)
                                                        .SetOngoing(true)
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

        public Notification ReturnNotif()
        {
            var manager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            var intent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);

            var notifBuilder = new Notification.Builder(context, Constants.FOREGROUND_CHANNEL_ID)
                .SetContentTitle("Hymax Burglar")
                .SetContentText("Your properties are safe with us")
                .SetSmallIcon(Resource.Mipmap.icon)
                .SetOngoing(true)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            // Building channel if API verion is 26 or above
            if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(Constants.FOREGROUND_CHANNEL_ID, "HomeCare", NotificationImportance.High);
                notificationChannel.Importance = NotificationImportance.High;
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