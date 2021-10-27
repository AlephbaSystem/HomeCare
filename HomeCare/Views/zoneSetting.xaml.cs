using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class zoneSetting : ContentPage
    {
        public zoneSetting()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            this.Title = "تنظیمات زون";

            BindingContext = new ViewModels.ZoneSettingViewModel();
        }

        public async void SimZoneQueryButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Button s = (Button)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            Services.SMS.Commands.Zone();
            UserDialogs.Instance.Toast("استعلام وضعیت زون های سیمی با موفقیت ارسال شد.");
        }
    }
}
