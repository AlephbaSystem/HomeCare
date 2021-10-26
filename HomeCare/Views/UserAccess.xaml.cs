using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeCare.Views
{
    public partial class UserAccess : ContentPage
    {
        public UserAccess()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "کاربران";

            BindingContext = new ViewModels.UserAccessViewModel();
        }
    }
}
