using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

using XamarinStudy.Models;

namespace XamarinStudy.DataSource
{
    public class ContactsDatabase
    {

        readonly SQLiteAsyncConnection Database; 

        public ContactsDatabase()
        {
            Database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinContacts.db3"));

            Database.CreateTableAsync<Contact>().Wait();
            InitializeDatabase().Wait();
        }


        private Task<int> InitializeDatabase()
        {
            var ExistingContacts = GetContactsAsync().Result;
            if (ExistingContacts.Count == 0)
            {
                List<Contact> DefaultContacts = new List<Contact>
                {
                    new Contact
                    {
                        ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-cheetah.jpg?h=77f2d4e4&itok=fFHrcejy",
                        FirstName = "L",
                        LastName = "M",
                        IsFavorite = true
                    },
                    new Contact
                    {
                        ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-dwarf-croc.jpg?h=77f2d4e4&itok=OBnmGEJQ",
                        FirstName = "Abigale",
                        LastName = "Adams",
                        IsFavorite = true
                    },
                    new Contact
                    {
                        ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-07/animal-hero-elephant.jpg?h=77f2d4e4&itok=rWNPmsj9",
                        FirstName = "Kiara",
                        LastName = "Clark",
                        IsFavorite = false
                    },
                    new Contact
                    {
                        ImageUrl = "",
                        FirstName = "Timon",
                        LastName = "Usman",
                        IsFavorite = false
                    } 
                };

                return SaveContactsAsync(DefaultContacts);                
            }

            return null;
        }



        public Task<List<Contact>> GetContactsAsync()
        {
            return Database.Table<Contact>().ToListAsync();
        }


        public Task<Contact> GetContactAsync(int id)
        {
            return Database.Table<Contact>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }


        /**
         * 
         * Returns the number of rows affected, not the id of the contact.  The contact is updated by referrence. 
         */
        public Task<int> SaveContactAsync(Contact contact)
        {
            if (contact.ID != 0)
            {
                return Database.UpdateAsync(contact);
            }
            else
            {
                return Database.InsertAsync(contact);
            }
        }


        public Task<int> SaveContactsAsync(List<Contact> contacts)
        {
            return Database.InsertAllAsync(contacts);
        }


        public Task<int> DeleteContactAsync(Contact contact)
        {
            return Database.DeleteAsync(contact);
        }
    }
}
