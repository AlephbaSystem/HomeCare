using System;
using System.Collections.Generic;
using HomeCare.ViewModels;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class Tutorial : ContentPage
    {
        public Tutorial()
        {
            InitializeComponent();

            BindingContext = new TutorialViewModel();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }
}
