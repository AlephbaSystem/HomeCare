using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HomeCare.Views;
using Acr.UserDialogs;
using HomeCare.Models;

namespace HomeCare
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ViewModels.MainPageViewModel();
            //this.BackgroundColor = Color.FromHex("a5a58d");
        }

        async void AddNewDevice_Clicke(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            ImageButton s = (ImageButton)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new AddNewDevice());
        }
        async void Timing_Clicke(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            ImageButton s = (ImageButton)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new Timing());
        }

        async void SettingsImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            ImageButton s = (ImageButton)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new Settings());
        }

        async void releSettingsImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            ImageButton s = (ImageButton)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new releSettings());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ViewModels.MainPageViewModel)BindingContext).OnMenu();
        }

        private async void DeviceStatus_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Button s = (Button)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            Services.SMS.Commands.Status();
            UserDialogs.Instance.Toast("درخواست وضعیت با موفقیت ارسال شد.");
        }

        private async void Open_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            openFrame.BackgroundColor = Color.FromHex("F68D99");
            halfFrame.BackgroundColor = Color.FromHex("eff7f6");
            closeFrame.BackgroundColor = Color.FromHex("eff7f6");
            await Task.Delay(200);

            Services.SMS.Commands.Open();
            UserDialogs.Instance.Toast("درخواست باز کردن دستگاه با موفقیت ارسال شد.");
        }

        private async void Hearing_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            Services.SMS.Commands.Wiretapping();
            UserDialogs.Instance.Toast("درخواست شنود با موفقیت ارسال شد.");
        }


        private async void Partial_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            halfFrame.BackgroundColor = Color.FromHex("FEC872");
            openFrame.BackgroundColor = Color.FromHex("eff7f6");
            closeFrame.BackgroundColor = Color.FromHex("eff7f6");

            Services.SMS.Commands.PartialOpen();
            UserDialogs.Instance.Toast("درخواست نیمه باز کردن دستگاه با موفقیت ارسال شد.");
        }
        private async void Close_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            closeFrame.BackgroundColor = Color.FromHex("95d5b2");
            halfFrame.BackgroundColor = Color.FromHex("eff7f6");
            openFrame.BackgroundColor = Color.FromHex("eff7f6");

            Services.SMS.Commands.Close();
            UserDialogs.Instance.Toast("درخواست قفل کردن دستگاه با موفقیت ارسال شد.");
        }
        private async void Settings_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new Settings());
        }
        private async void RELE_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            await Navigation.PushAsync(new releSettings());
        }
        private async void Silence_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Frame s = (Frame)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            Services.SMS.Commands.Silence();
            UserDialogs.Instance.Toast("درخواست سکوت با موفقیت ارسال شد.");
        }

        private async void onMenuCarousel_CurrentItemChanged(Xamarin.Forms.CarouselView sender, CurrentItemChangedEventArgs e)
        {
            await Task.Delay(100);
            var userHandler = new Services.Users.UserHandler();
            var citem = ((Devices)sender.CurrentItem);
            foreach (Devices item in sender.ItemsSource)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    userHandler.UpdateDevice(citem);
                }
            }
            citem.Selected = true;
            userHandler.UpdateDevice(citem);
        }
    }
}
