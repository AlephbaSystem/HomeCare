using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HomeCare.Droid.Interfaces; 
using Xamarin.Forms;

namespace HomeCare.Droid.Services
{
    [Service(Enabled = true, Label = "HymaxBurglarNotify")]
    public class AntiTheft : Service
    {
        private IWindowManager _windowManager;
        private WindowManagerLayoutParams _layoutParams;
        private Android.Views.View _floatingView;
        private int _initialX;
        private int _initialY;
        private float _initialTouchX;
        private float _initialTouchY;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnCreate()
        {
            base.OnCreate();

            if (Android.Provider.Settings.CanDrawOverlays(this))
            {
                widget();
            }
        }
        private void widget()
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
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            NotificationManager notificationManager = (NotificationManager)global::Android.App.Application.Context.GetSystemService(Context.NotificationService);

            int notificationId = 1;
            string channelId = Constants.FOREGROUND_CHANNEL_ID;
            string channelName = "HomeCare";
            var importance = NotificationImportance.Max;

            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel mChannel = new NotificationChannel(
                        channelId, channelName, importance);
                notificationManager.CreateNotificationChannel(mChannel);
            }

            Notification notif = DependencyService.Get<INotification>().ReturnNotif("Hymax Burglar", "Your properties are safe with us");


            notificationManager.Notify(notificationId, notif);
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            if (_floatingView != null)
            {
                _windowManager.RemoveView(_floatingView);
            }
            base.OnDestroy();
        }
        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
         
    }
}