using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinStudy.DataSource;
using XamarinStudy.Models;

namespace XamarinStudy
{
    public partial class MainPage : ContentPage
    {
        private LocalContacts LocalContacts;
        public IList<Contact> Contacts { get; private set; }
        public IList<Contact> FavoriteContacts { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            LocalContacts = new LocalContacts();

            Contacts = LocalContacts.GetContacts();
            FavoriteContacts = LocalContacts.GetFavorites();

            BindingContext = this;
        }


        void OnFavoriteContactsListViewSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            Contact selectedItem = e.SelectedItem as Contact;
        }


        void OnFavoriteContactsListViewTapped(Object sender, ItemTappedEventArgs e)
        {
            Contact tappedItem = e.Item as Contact;
        }


        void OnContactsListViewSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            Contact selectedItem = e.SelectedItem as Contact;
        }


        void OnContactsListViewTapped(Object sender, ItemTappedEventArgs e)
        {
            Contact tappedItem = e.Item as Contact;
        }
    }
}
