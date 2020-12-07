using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using XamarinStudy.DataSource;
using XamarinStudy.Models;

namespace XamarinStudy.Pages
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ContactsSource ContactSource;
        public IList<Contact> AllContacts { get; private set; }
        public IList<Contact> FavoriteContacts { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            ContactSource = new LocalContacts();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            AllContacts = ContactSource.GetContacts().OrderBy(p => p.GetDisplayName()).ToList();
            FavoriteContacts = AllContacts.Where(p => p.IsFavorite).OrderBy(p => p.GetDisplayName()).ToList();

            FavoriteContactsListView.ItemsSource = FavoriteContacts;
            ContactsListView.ItemsSource = AllContacts;
        }


        async void OnContactAddClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditContactPage(ref ContactSource)
            {
                BindingContext = new Contact()
            });
        }


        async void OnContactSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditContactPage(ref ContactSource)
                {
                    BindingContext = e.SelectedItem as Contact
                });
            }
        }
    }
}