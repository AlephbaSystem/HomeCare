using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Interfaces;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HomeCare.Droid.Services
{
    [Service(Enabled = true, Label = "HymaxBurglarNotify")]
    public class AntiTheft : Service
    {
        private IWindowManager _windowManager;
        private WindowManagerLayoutParams _layoutParams;
        private Android.Views.View _floatingView;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnCreate()
        {
            base.OnCreate();

            try
            {
                widget();
            }
            catch (System.Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "AntiTheft.OnCreate" }
  };
                Crashes.TrackError(e, properties);
            }
        }
        private void widget()
        {
            try
            {
                _floatingView = LayoutInflater.From(this).Inflate(Resource.Layout.widget, null);

                WindowManagerTypes FLG = WindowManagerTypes.ApplicationOverlay;

                if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.O)
                {
                    FLG = WindowManagerTypes.Phone;
                }

                _layoutParams = new WindowManagerLayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent,
                    FLG,
                    WindowManagerFlags.NotFocusable | WindowManagerFlags.NotTouchable | WindowManagerFlags.LayoutInScreen,
                    Format.Translucent)
                {
                    Gravity = GravityFlags.Left | GravityFlags.Top
                };

                _windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();
                _windowManager.AddView(_floatingView, _layoutParams);
            }
            catch (System.Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "AntiTheft.widget" }
  };
                Crashes.TrackError(e, properties);
            } 
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            try
            {
               
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
                {
                    Notification notif = DependencyService.Get<INotification>().ReturnNotif();
                    StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notif);
                }
                return StartCommandResult.Sticky;
            }
            catch (System.Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "AntiTheft.OnStartCommand" }
  };
                Crashes.TrackError(e, properties);
            }
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            try
            { 
                if (_floatingView != null)
                {
                    _windowManager.RemoveView(_floatingView);
                }
            }
            catch (System.Exception e)
            {
                var properties = new Dictionary<string, string> {
    { "Category", "AntiTheft.OnDestroy" }
  };
                Crashes.TrackError(e, properties);
            }
            base.OnDestroy();
        }
        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
    }
}