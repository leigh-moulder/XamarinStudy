using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinStudy.DataSource;
using XamarinStudy.Models;

namespace XamarinStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {

        private ContactsSource Source;

        public EditContactPage(ref ContactsSource source)
        {
            InitializeComponent();

            this.Source = source;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var contact = (Contact)BindingContext;

            contact = Source.AddContact(contact);

            await Navigation.PopAsync();
        }


        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            var contact = (Contact)BindingContext;

            Source.RemoveContact(contact);

            await Navigation.PopAsync();
        }

    }
}