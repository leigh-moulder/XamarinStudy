using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinStudy
{
    public partial class MainPage : ContentPage
    {

        int clickCount = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs eventArgs)
        {
            clickCount++;
            ((Button)sender).Text = $"You clicked {clickCount} times.";
        }
    }
}
