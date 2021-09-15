using Xamarin.Forms;
using HomeCare.iOS.Audio;
using HomeCare.Services.Audio;
using System.Runtime.InteropServices;
using Foundation;
using System;
using AudioToolbox;

[assembly: Dependency(typeof(AudioService))]
namespace HomeCare.iOS.Audio
{
    class AudioService : IAudio
    {
        public enum VibrationPower
        {
            Normal,
            Low,
            Hight
        }
        [DllImport("/System/Library/Frameworks/AudioToolbox.framework/AudioToolbox")]
        private static extern void AudioServicesPlaySystemSoundWithVibration(uint inSystemSoundID, NSObject arg,
    IntPtr pattert);

        public bool PlayWavSuccess()
        {
            //var am = (AudioManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AudioService);

            //if (am.RingerMode == RingerMode.Normal)
            //{
            //    mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.good);
            //    mediaPlayer.Start();
            //}


            SystemSound.Vibrate.PlaySystemSound();

            return true;
        }

        public bool PlayWavError()
        {
            //var am = (AudioManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AudioService);

            //if (am.RingerMode == RingerMode.Normal)
            //{
            //    mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.bad);
            //    mediaPlayer.Start();
            //}

            var dictionary = new NSMutableDictionary();
            var vibePattern = new NSMutableArray();
            vibePattern.Add(NSNumber.FromBoolean(true));
            vibePattern.Add(NSNumber.FromInt32(1000)); 
            dictionary.Add(NSObject.FromObject("VibePattern"), vibePattern);
            dictionary.Add(NSObject.FromObject("Intensity"), NSNumber.FromInt32(1));
            AudioServicesPlaySystemSoundWithVibration(4095U, null, dictionary.Handle);

            return true;
        }
    }
}