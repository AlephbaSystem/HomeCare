using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Services;
using HomeCare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidServiceHelper))]
namespace HomeCare.Droid.Services
{
    public class AndroidServiceHelper : IAndroidService
    {
        private static Context context = global::Android.App.Application.Context;
        public void StartService()
        {
            var intent = new Intent(context, typeof(AntiTheft));
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                context.StartForegroundService(intent);
            }
            else
            {
                context.StartService(intent);
            }
        }

        public void StopService()
        {
            var intent = new Intent(context, typeof(AntiTheft));
            context.StopService(intent);
        }
    }
}