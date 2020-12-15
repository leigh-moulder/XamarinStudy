using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinStudy.Models;

namespace XamarinStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
                
        public MainPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var AllContacts = await App.Database.GetContactsAsync();

            FavoriteContactsListView.ItemsSource = AllContacts.Where(p => p.IsFavorite).OrderBy(p => p.DisplayName).ToList();
            ContactsListView.ItemsSource = AllContacts.OrderBy(p => p.DisplayName).ToList();
        }


        async void OnContactAddClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditContactPage()
            {
                BindingContext = new Contact()
            });
        }


        async void OnContactSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditContactPage()
                {
                    BindingContext = e.SelectedItem as Contact
                });
            }
        }


        async void OnContactTapped(Object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Navigation.PushAsync(new EditContactPage()
                {
                    BindingContext = e.Item as Contact
                });
            }
        }


        async void OnSensorClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SensorPage());
        }


        async void OnWebClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WebPage());
        }
    }
}