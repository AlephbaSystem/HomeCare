using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timing : ContentPage
    {
        public Timing()
        {
            InitializeComponent();

            // back button in iOS

            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Back");

            // NavigationPage Title

            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "هوشمند سازی";
             
            BindingContext = new ViewModels.TimingViewModel();

        }
    }
}