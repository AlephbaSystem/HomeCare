using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "تنظیمات";

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("E9F1F7");
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
    }
}
