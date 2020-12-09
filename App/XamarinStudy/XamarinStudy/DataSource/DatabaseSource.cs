using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinStudy.Models;

namespace XamarinStudy.DataSource
{
    public class DatabaseSource
    {

        static ContactsDatabase _database = null;

        public DatabaseSource()
        {
            // setup the database 
            if (_database == null)
            {
                _database = new ContactsDatabase();
            }

            // populate the database
            InitializeDatabase();
        }


        private void InitializeDatabase()
        {

            List<Contact> ExistingContacts = GetContacts();
            if (ExistingContacts.Count == 0)
            {
                AddContact(new Contact
                {
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-cheetah.jpg?h=77f2d4e4&itok=fFHrcejy",
                    FirstName = "L",
                    LastName = "M",
                    IsFavorite = true
                });
                AddContact(new Contact
                {
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-dwarf-croc.jpg?h=77f2d4e4&itok=OBnmGEJQ",
                    FirstName = "Abigale",
                    LastName = "Adams",
                    IsFavorite = true
                });
                AddContact(new Contact
                {
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-07/animal-hero-elephant.jpg?h=77f2d4e4&itok=rWNPmsj9",
                    FirstName = "Kiara",
                    LastName = "Clark",
                    IsFavorite = false
                });
                AddContact(new Contact
                {

                    ImageUrl = "",
                    FirstName = "Timon",
                    LastName = "Usman",
                    IsFavorite = false
                });
            }
        }

        public List<Contact> GetContacts()
        {
            List<Contact> Contacts = _database.GetContactsAsync().Result;

            return Contacts;
        }


        public List<Contact> GetFavorites()
        {
            List<Contact> Contacts = _database.GetContactsAsync().Result;

            return Contacts.Where(p => p.IsFavorite).ToList<Contact>();
        }


        public Contact AddContact(Contact NewContact)
        {
            int RowsAffected = _database.SaveContactAsync(NewContact).Result;
            return NewContact;
        }


        public Contact EditContact(Contact UpdatedContact)
        {
            int RowsAffected = _database.SaveContactAsync(UpdatedContact).Result;
            return UpdatedContact;
        }


        public void RemoveContact(Contact RemovedContact)
        {
            _database.DeleteContactAsync(RemovedContact);
        }
    }
}
