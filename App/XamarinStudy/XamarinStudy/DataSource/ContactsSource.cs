using System.Collections.Generic;
using XamarinStudy.Models;

namespace XamarinStudy.DataSource
{
    public abstract class ContactsSource
    {

        public abstract List<Contact> GetContacts();

        public abstract List<Contact> GetFavorites();

        public abstract Contact AddContact(Contact NewContact);

        public abstract Contact EditContact(Contact UpdatedContact);

        public abstract void RemoveContact(Contact RemovedContact);

    }
}
