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


        public EditContactPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var contact = (Contact)BindingContext;

            await App.Database.SaveContactAsync(contact);
            await Navigation.PopAsync();
        }


        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            var contact = (Contact)BindingContext;

            await App.Database.DeleteContactAsync(contact);
            await Navigation.PopAsync();
        }

    }
}