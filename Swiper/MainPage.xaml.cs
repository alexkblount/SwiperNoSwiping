using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Swiper
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        bool isSwiping;
        double swipeWidth;
        double swipeOffset;

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainPageViewModel();
        }

        void SwipeView_SwipeEnded(System.Object sender, Xamarin.Forms.SwipeEndedEventArgs e)
        {
            if (swipeOffset >= (swipeWidth / 3))
            {
                var swiper = (sender as SwipeView);

                swiper.Close();

                var person = swiper?.BindingContext as Person;

                (BindingContext as MainPageViewModel).SwipeEnded(person);
            }

            isSwiping = false;
            swipeWidth = swipeOffset = 0;

        }

        void SwipeView_SwipeChanging(System.Object sender, Xamarin.Forms.SwipeChangingEventArgs e)
        {
            swipeOffset = e.Offset;
        }

        void SwipeView_SwipeStarted(System.Object sender, Xamarin.Forms.SwipeStartedEventArgs e)
        {
            var swiper = (sender as SwipeView);

            swipeWidth = swiper.Width;

            isSwiping = true;
        }
    }
}
