﻿using HomeCare.Services.SMS;
using HomeCare.Views.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //SMSEvents.OnSMSReceived += OnSMSReceived;

            MainPage = new NavigationPage(new SliderPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
