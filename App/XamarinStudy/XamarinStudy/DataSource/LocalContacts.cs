using System.Collections.Generic;
using System.Linq;
using XamarinStudy.Models;

namespace XamarinStudy.DataSource
{
    public class LocalContacts : ContactsSource
    {

        public List<Contact> Contacts { get; set; }

        private int ContactIndex = 0;

        public LocalContacts()
        {
            Contacts = new List<Contact>
            {
                new Contact
                {
                    index = 0,
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-cheetah.jpg?h=77f2d4e4&itok=fFHrcejy",
                    FirstName = "L",
                    LastName = "M",
                    IsFavorite = true
                },

                new Contact
                {
                    index = 1,
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-12/animal-hero-dwarf-croc.jpg?h=77f2d4e4&itok=OBnmGEJQ",
                    FirstName = "Abigale",
                    LastName = "Adams",
                    IsFavorite = true
                },

                new Contact
                {
                    index = 2,
                    ImageUrl = "https://kids.sandiegozoo.org/sites/default/files/styles/landing_page_view/public/2017-07/animal-hero-elephant.jpg?h=77f2d4e4&itok=rWNPmsj9",
                    FirstName = "Kiara",
                    LastName = "Clark",
                    IsFavorite = false
                },

                new Contact
                {
                    index = 3,
                    ImageUrl = "",
                    FirstName = "Timon",
                    LastName = "Usman",
                    IsFavorite = false
                }
            };

            ContactIndex = Contacts.Count();
        }


        override public List<Contact> GetContacts()
        {
            return Contacts;
        }


        override public List<Contact> GetFavorites()
        {
            // other options:
            // https://stackoverflow.com/questions/26383431/c-sharp-split-list-into-sublists-based-on-a-value-of-a-certain-property

            IEnumerable<Contact> FavoritesSubList = Contacts.Where(p => p.IsFavorite);
            return FavoritesSubList.ToList();
        }


        override public Contact AddContact(Contact NewContact)
        {
            if (NewContact.index.HasValue)
            {
                return EditContact(NewContact);
            }

            ContactIndex++;
            NewContact.index = ContactIndex;

            Contacts.Add(NewContact);

            return NewContact;
        }


        override public Contact EditContact(Contact UpdatedContact)
        {

            Contact originalContact = Contacts.Where(p => p.index == UpdatedContact.index).First();

            if (originalContact == null)
            {
                // somehow it was removed from the list, simply re-add it
                Contacts.Add(UpdatedContact);
            }
            else
            {
                // yes, yes, i'm sure there's a better way.  I don't care and want to focus on the db implementation
                Contacts.Remove(originalContact);
                Contacts.Add(UpdatedContact);
            }

            return UpdatedContact;
        }


        override public void RemoveContact(Contact RemovedContact)
        {
            if (RemovedContact.index != null)
            {
                Contacts.Remove(RemovedContact);
            }
        }
    }
}
