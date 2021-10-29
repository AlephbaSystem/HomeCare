using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class PartZoneSetting : ContentPage
    {
        public PartZoneSetting()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "تنظیمات پارت زون";

            BindingContext = new ViewModels.PartZoneViewModel();
        }
    }
}
