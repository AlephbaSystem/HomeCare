using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class UserAccess : ContentPage
    {
        public UserAccess()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "کاربران";

            BindingContext = new ViewModels.UserAccessViewModel();
        }

        public async void QueryButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<Services.Audio.IAudio>().PlayWavSuccess();
            Button s = (Button)sender;
            await Task.Delay(100);
            await s.FadeTo(0, 100);
            await Task.Delay(100);
            await s.FadeTo(1, 100);

            Services.SMS.Commands.User();
            UserDialogs.Instance.Toast("درخواست لیست کاربران با موفقیت ارسال شد.");
        }
    }
}
