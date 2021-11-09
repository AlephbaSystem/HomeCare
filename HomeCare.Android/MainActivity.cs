using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS; 
using Android; 
using Android.Content;
using Acr.UserDialogs;
using CarouselView.FormsPlugin.Android;

namespace HomeCare.Droid
{
    [Activity(Label = "HomeCare", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Acr.UserDialogs.UserDialogs.Init(this);
            CarouselViewRenderer.Init(); 
            LoadApplication(new App());
        }
        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }
        const int RequestLocationId = 0;
        readonly string[] LocationPermissions =
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
