using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinStudy.DataSource
{
    public class LocalContacts
    {

        public List<Contact> Contacts { get; set; }

        public LocalContacts()
        {
            Contacts = new List<Contact>();

            Contacts.Add(new Contact
            {
                ImageUrl = "",
                FirstName = "L",
                LastName = "M",
                IsFavorite = true
            });

            Contacts.Add(new Contact
            {
                ImageUrl = "",
                FirstName = "Abigale",
                LastName = "Adams",
                IsFavorite = true
            });

            Contacts.Add(new Contact
            {
                ImageUrl = "",
                FirstName = "Kiara",
                LastName = "Clark",
                IsFavorite = false
            });

        }


        public List<Contact> GetContacts()
        {
            return Contacts;
        }


        public List<Contact> GetFavorites()
        {
            List<Contact> Favorites = new List<Contact>();

            return Favorites;
        }
    }
}
