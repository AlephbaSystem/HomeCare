using CarouselView.FormsPlugin.Abstractions;
using HomeCare.Views.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderPage : ContentPage
    {
        private View[] _views;
        public SliderPage()
        {
            InitializeComponent();

            _views = new View[]
            {
                new Page1(),
                new Page2(),
                //new SoExcitedView(),
                //new BikingCoolView()
            };

            Carousel.ItemsSource = _views;
        }
        private void OnCarouselPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            var currentView = _views[e.NewValue];

            if (currentView is IAnimatedView animatedView)
            {
                animatedView.StartAnimation();
            }
        }
    }
}