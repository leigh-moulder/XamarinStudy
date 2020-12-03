using System;

namespace XamarinStudy.DataSource
{
    public class Contact
    {

        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Boolean IsFavorite { get; set; }

        public string PhoneNumber { get; set; }
        
        public string GetDisplayName()
        {
            return FirstName + " " + LastName;
        }
    }
}
