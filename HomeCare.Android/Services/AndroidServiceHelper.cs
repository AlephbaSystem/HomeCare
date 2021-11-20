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
        private bool IsServiceRunning(System.Type ClassTypeof)
        {
            ActivityManager manager = (ActivityManager)context.ApplicationContext.GetSystemService(Context.ActivityService);
#pragma warning disable CS0618 // Type or member is obsolete
            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ShortClassName == ClassTypeof.ToString())
                {
                    return true;
                }
            }
#pragma warning restore CS0618 // Type or member is obsolete
            return false;
        }
        public void StartService()
        {
            if (IsServiceRunning(typeof(AntiTheft))) return;
            var intentS = new Intent(context, typeof(AntiTheft));
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                context.StartForegroundService(intentS);
            }
            else
            {
                context.StartService(intentS);
            }
        }

        public void StopService()
        {
            var intentS = new Intent(context, typeof(AntiTheft));
            context.StopService(intentS);
        }
    }
}