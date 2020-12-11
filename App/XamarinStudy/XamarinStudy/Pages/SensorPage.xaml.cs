using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SensorPage : ContentPage
    {

        CancellationTokenSource cts;

        public SensorPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            GetLocationInformation();

        }


        protected override void OnDisappearing()
        {
            if ((cts != null) && !cts.IsCancellationRequested)
            {
                cts.Cancel();
            }

            base.OnDisappearing();
        }



        private async void GetLocationInformation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();

                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    LabelPosition.Text = location.Latitude + "N, " + location.Longitude + "W";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}