﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_System
{
    class Contact
    {
        // Contact details....
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public int Zip;
        public long PhoneNumber;
        public string Email;

        public override bool Equals(object obj)
        {
            Contact contact = obj as Contact;
            if (obj == null)
                return false;
            return this.FirstName.Equals(contact.FirstName) && this.LastName.Equals(contact.LastName);
        }
        public static void DisplayContact(Contact contact)
        {
            Console.WriteLine(" Name : " + contact.FirstName + " " + contact.LastName);
        }
    }
}
