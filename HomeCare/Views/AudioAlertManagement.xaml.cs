using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class AudioAlertManagement : ContentPage
    {
        public AudioAlertManagement()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "مدیریت هشدارهای صوتی";

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
