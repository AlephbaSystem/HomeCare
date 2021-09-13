using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views.Slider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : IAnimatedView
    {
        public Page2()
        {
            InitializeComponent();
        }
        public void StartAnimation()
        {
            if (Resources["BackgroundColorAnimation"] is ColorAnimation backgroundColorAnimation)
            {
                backgroundColorAnimation.Begin();
            }

            if (Resources["InfoPanelAnimation"] is StoryBoard infoPanelAnimation)
            {
                infoPanelAnimation.Begin();
            }
        }
    }
}