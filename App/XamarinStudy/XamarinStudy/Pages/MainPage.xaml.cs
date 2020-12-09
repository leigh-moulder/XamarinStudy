using System;
using System.Linq;

using Xamarin.Forms;
using XamarinStudy.Models;

namespace XamarinStudy.Pages
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
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

            FavoriteContactsListView.ItemsSource = AllContacts.Where(p => p.IsFavorite).OrderBy(p => p.GetDisplayName()).ToList();
            ContactsListView.ItemsSource = AllContacts.OrderBy(p => p.GetDisplayName()).ToList();
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
    }
}