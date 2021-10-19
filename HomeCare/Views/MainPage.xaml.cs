using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HomeCare.Views;

namespace HomeCare
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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

      async  void SettingsImageButton_Clicked(System.Object sender, System.EventArgs e)
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
    }
}
