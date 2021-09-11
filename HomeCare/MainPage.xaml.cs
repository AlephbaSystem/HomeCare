using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HomeCare.Views;

namespace HomeCare
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //this.BackgroundColor = Color.FromHex("a5a58d");
        }

        void AddNewDevice_Clicke(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddNewDevice());
        }
        void Timing_Clicke(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Timing ());
        }

        void SettingsImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}
