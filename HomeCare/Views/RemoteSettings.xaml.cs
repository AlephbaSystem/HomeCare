using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class RemoteSettings : ContentPage
    {
        public RemoteSettings()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "تنظیمات ریموت";

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");

            BindingContext = new ViewModels.RemoteSettingsViewModel();
        }
    }
}
