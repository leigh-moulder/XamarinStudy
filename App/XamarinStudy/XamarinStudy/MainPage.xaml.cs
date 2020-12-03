using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinStudy.DataSource;

namespace XamarinStudy
{
    public partial class MainPage : ContentPage
    {
        private LocalContacts LocalContacts;
        public IList<DataSource.Contact> Contacts { get; private set; }
        public IList<DataSource.Contact> FavoriteContacts { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            LocalContacts = new LocalContacts();

            Contacts = LocalContacts.GetContacts();
            FavoriteContacts = LocalContacts.GetFavorites();

            BindingContext = this;
        }
    }
}
