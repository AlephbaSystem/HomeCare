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
    public partial class Page1 : IAnimatedView
    {
        public Page1()
        {
            InitializeComponent();
        }
        public void StartAnimation()
        {
            if (Resources["InfoPanelAnimation"] is StoryBoard animation)
            {
                animation.Begin();
            }
        }
    }
}