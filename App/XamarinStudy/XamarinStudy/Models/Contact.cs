﻿using System;
using SQLite;

namespace XamarinStudy.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
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
