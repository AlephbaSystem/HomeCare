﻿using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using HomeCare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeCare.Droid
{
    [Activity(Label = "AlertActivity", Name = "com.alephbasystem.homecare.AlertActivity", AlwaysRetainTaskState = true, TurnScreenOn = true, NoHistory = true,
    ShowForAllUsers = true, ShowWhenLocked = true,
    LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    internal class AlertActivity : Activity
    {
        ImageView car;
        int howMuch = 0;
        ImageButton icon;
        private int image;
        TextView income;
        bool keepGoing = true;

        /* renamed from: mp */
        MediaPlayer f95mp = new MediaPlayer();
        private string msg;
        bool playSound = false;
        string state = "";
        //Techniques teq = Techniques.Shake;

        /* renamed from: v */
        Vibrator f96v;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            KeyguardManager keyguardManager = (KeyguardManager)GetSystemService(Context.KeyguardService);
            PowerManager pm = (PowerManager)GetSystemService(Context.PowerService);
            if (keyguardManager != null)
            {
                keyguardManager.RequestDismissKeyguard(this, null);
                PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Full | WakeLockFlags.AcquireCausesWakeup, "");
                wl.Acquire();
            }

            Window.AddFlags(WindowManagerFlags.ShowWhenLocked |
                            WindowManagerFlags.KeepScreenOn |
                            WindowManagerFlags.DismissKeyguard |
                            WindowManagerFlags.TurnScreenOn | WindowManagerFlags.AllowLockWhileScreenOn | WindowManagerFlags.TouchableWhenWaking);
             
            // Create your application here
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
            this.image = Resource.Drawable.icon_alert_warning;
            updateDisplay();
            icon.Click += delegate
            {
                this.keepGoing = false;
                this.f96v.Cancel();
                this.f95mp.Stop();
                Xamarin.Forms.DependencyService.Get<IAndroidService>().StopService();
                Xamarin.Forms.DependencyService.Get<IAndroidService>().StartService();
                this.Finish();
            };
            var metrics = new DisplayMetrics();
            var windowManager = this.GetSystemService(Context.WindowService) as IWindowManager;
            windowManager?.DefaultDisplay.GetMetrics(metrics);
            car.Animate().TranslationY((float)metrics.HeightPixels).SetDuration(1000).SetInterpolator(new DecelerateInterpolator()).SetStartDelay(2).Start();
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

                this.f96v.Vibrate(VibrationEffect.CreateWaveform(vbf, 1));
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