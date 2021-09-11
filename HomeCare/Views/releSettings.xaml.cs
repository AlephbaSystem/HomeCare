using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class releSettings : ContentPage
    {
        public releSettings()
        {
            InitializeComponent();

            // back button in iOS

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");

            // NavigationPage Title

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "تنظیمات رله";
        }
    }
}
