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
        public void ShowAlert(string address, string message, Intent mainIntent)
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
    }
}