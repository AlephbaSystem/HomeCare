﻿using System;
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

        void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
            Navigation.PushAsync(new MainPage());
        }

        void RelleButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new releSettings());
        }

        void AddNewDevice_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddNewDevice());
        }

        void AudioAlertButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AudioAlertManagement());
        }
    }
}
