using System;

namespace XamarinStudy.Models
{
    public class Contact
    {
        public int? index { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Boolean IsFavorite { get; set; }

        public string PhoneNumber { get; set; }

        public string GetDisplayName()
        {
            return FirstName + " " + LastName;
        }

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}
