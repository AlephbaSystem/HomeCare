using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Android.Content;
using Acr.UserDialogs; 
using Android.Views;
using HomeCare.Droid.Services;
using System;
using HomeCare.Interfaces;
using Xamarin.Essentials;

namespace HomeCare.Droid
{
    [Activity(Label = "HomeCare", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int RequestCode = 5469;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            Acr.UserDialogs.UserDialogs.Init(this); 
            LoadApplication(new App());

            KeyguardManager keyguardManager = (KeyguardManager)GetSystemService(Context.KeyguardService);
            PowerManager pm = (PowerManager)GetSystemService(Context.PowerService);
            if (keyguardManager != null)
            {
                if (keyguardManager.IsKeyguardLocked)
                {
                    keyguardManager.RequestDismissKeyguard(this, null);
                    PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Full | WakeLockFlags.AcquireCausesWakeup, "");
                    wl.Acquire();
                }
            }

            Window.AddFlags(WindowManagerFlags.ShowWhenLocked |
                            WindowManagerFlags.KeepScreenOn |
                            WindowManagerFlags.DismissKeyguard |
                            WindowManagerFlags.TurnScreenOn | WindowManagerFlags.AllowLockWhileScreenOn | WindowManagerFlags.TouchableWhenWaking);

        }

        private void reset()
        {
            try
            {
                Android.Media.MediaPlayer f95mp = new Android.Media.MediaPlayer();
                Vibrator f96v;
                f96v = (Vibrator)this.GetSystemService(Context.VibratorService);
                f96v.Cancel();
                f95mp.Stop();
                f95mp.Release();

                checkPermission();
                if (Android.Provider.Settings.CanDrawOverlays(global::Android.App.Application.Context)) Xamarin.Forms.DependencyService.Get<IAndroidService>().StartService();
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }

        public void checkPermission()
        {
            if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M) return;
            if (Android.Provider.Settings.CanDrawOverlays(global::Android.App.Application.Context)) return;
            var intent = new Intent(Android.Provider.Settings.ActionManageOverlayPermission);
            intent.SetData(Android.Net.Uri.Parse("package:" + PackageName));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }
        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(RequirePermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }

            reset();
        }
        const int RequestLocationId = 0;
        readonly string[] RequirePermissions =
        {
            Manifest.Permission.BroadcastSms,
            Manifest.Permission.ReadSms,
            Manifest.Permission.SendSms,
            Manifest.Permission.ReceiveSms,
            Manifest.Permission.WriteSms,
            Manifest.Permission.ForegroundService,
            Manifest.Permission.InstantAppForegroundService,
            Manifest.Permission.SystemAlertWindow,
            Manifest.Permission.DisableKeyguard,
            Manifest.Permission.WakeLock,
            Manifest.Permission.ModifyPhoneState,
            Manifest.Permission.ModifyAudioSettings,
        };

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}
