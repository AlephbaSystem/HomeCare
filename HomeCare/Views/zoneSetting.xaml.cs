using System;
using System.Collections.Generic;

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
        }
    }
}
