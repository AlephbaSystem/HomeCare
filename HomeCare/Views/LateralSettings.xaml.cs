using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class LateralSettings : ContentPage
    {
        public LateralSettings()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "تنظیمات جانبی";

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
