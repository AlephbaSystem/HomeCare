using Android.OS; 
using HomeCare.Droid.Audio; 
using HomeCare.Services.Audio; 
using Xamarin.Forms; 
using Android.Media; 



[assembly: Dependency(typeof(AudioService))] 
namespace HomeCare.Droid.Audio
{
    class AudioService : IAudio
    {
        private MediaPlayer mediaPlayer;

        public AudioService()
        {
        }

        public bool PlayWavSuccess()
        {
            //var am = (AudioManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AudioService);

            //if (am.RingerMode == RingerMode.Normal)
            //{
            //    mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.good);
            //    mediaPlayer.Start();
            //}

            var v = (Vibrator)Android.App.Application.Context.GetSystemService(Android.App.Application.VibratorService);
#pragma warning disable CS0618 // Type or member is obsolete
            v.Vibrate(50);
#pragma warning restore CS0618 // Type or member is obsolete

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

            var v = (Vibrator)Android.App.Application.Context.GetSystemService(Android.App.Application.VibratorService);
#pragma warning disable CS0618 // Type or member is obsolete
            v.Vibrate(1000);
#pragma warning restore CS0618 // Type or member is obsolete

            return true;
        }
    }
} 