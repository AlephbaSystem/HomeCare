using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace HomeCare.Droid
{
    [Activity(Label = "AlertActivity", Name = "com.alephbasystem.homecare.AlertActivity", 
        AlwaysRetainTaskState = true, TurnScreenOn = true, NoHistory = true,
    ShowForAllUsers = true, ShowWhenLocked = true,
    LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    internal class AlertActivity : Activity
    {
        ImageView car;
        int howMuch = 0;
        ImageButton icon;
        TextView income;
        bool keepGoing = true;

        MediaPlayer f95mp = new MediaPlayer();
        private string msg;
        bool playSound = false;
        Vibrator f96v;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
             
            Toast.MakeText(this, "خطر سرقت", ToastLength.Short).Show();
            SetContentView(Resource.Layout.activity_alert);
            income = FindViewById<TextView>(Resource.Id.alert_text);
            icon = FindViewById<ImageButton>(Resource.Id.alert_icon);
            car = FindViewById<ImageView>(Resource.Id.alert_car);
            start();
        }
        public void start()
        {
            this.f96v = (Vibrator)this.GetSystemService(Context.VibratorService);
            this.msg = "خطر سرقت"; 
            updateDisplay();
            icon.Click += delegate
            {
                this.keepGoing = false;
                this.f96v.Cancel();
                this.f95mp.Stop();
                var intent = this.PackageManager.GetLaunchIntentForPackage(this.PackageName);
                StartActivity(intent); 
            };

            car.Animate().TranslationY((float)App.Current.MainPage.Width).SetDuration(1000).SetInterpolator(new DecelerateInterpolator()).SetStartDelay(2).Start();
            //icon.Animate().SetInterpolator(new DecelerateInterpolator()).ScaleX(0.4f).ScaleY(0.4f).SetDuration(550).SetStartDelay(2)
            //    .ScaleX(1.4f).ScaleY(1.4f).SetDuration(550)
            //    .ScaleY(1.0f).SetDuration(550).Start();
            onPrepared();
        }
        private void setAudio()
        {
            try
            {
                this.f95mp.Stop();
                this.f95mp.Release();
            }
            catch
            {
            }
            this.f95mp = new MediaPlayer();
            //float volume = (float)(1 - (System.Math.Log(100 - 99) / System.Math.Log(100)));
            //this.f95mp.SetVolume(volume, volume);
            this.f95mp = MediaPlayer.Create(this, Resource.Raw.car_alarm);
            this.playSound = true;
            this.f95mp.Looping = true;
        }

        public void updateDisplay()
        {
            this.income.Text = this.msg;
            this.icon.SetImageDrawable(GetDrawable(Resource.Drawable.icon_alert_warning));
            showAnimationCar();
            showAnimationButton();
        }

        /* access modifiers changed from: private */
        public void showAnimationButton()
        {
            if (this.keepGoing)
            {
                if (this.howMuch == 9)
                {
                    this.keepGoing = false;
                    if (this.playSound)
                    {
                        setAudio();
                    }
                    this.f95mp.Start();
                    return;
                }
                this.howMuch++;

                long[] vbf = { 100, 100, 100, 500, 500, 500, 100, 100, 100 };
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                {
                    var vibrationEffect = VibrationEffect.CreateWaveform(vbf, 1);
                    this.f96v.Vibrate(vibrationEffect);
                }
                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    this.f96v.Vibrate(3000);
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
        }

        /* access modifiers changed from: private */
        public void showAnimationCar()
        {
            if (this.keepGoing)
            {

            }
        }

        /* access modifiers changed from: protected */
        protected override void OnStop()
        {
            base.OnStop();
            this.f96v.Cancel();
            this.f95mp.Stop();
        }

        protected override void OnDestroy()
        {
            this.f96v.Cancel();
            this.f95mp.Stop();
            this.f95mp.Release();
            base.OnDestroy();
        }

        /* access modifiers changed from: protected */
        protected override void OnPause()
        {
            this.f96v.Cancel();
            this.f95mp.Stop();
            base.OnPause();
        }

        public void onPrepared()
        {
            this.playSound = true;
            this.f95mp.Start();
        }
    }

}