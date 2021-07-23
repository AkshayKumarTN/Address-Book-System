using System;
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
            Console.Write(" [Name] : " + contact.FirstName + " " + contact.LastName);
            Console.Write("\t[Address] : "+ contact.Address);
            Console.Write("\t[City Name] : " + contact.City);
            Console.Write("\t[State Name] : " + contact.State);
            Console.Write("\t[zip code] : " + contact.Zip);
            Console.Write("\t[Phone Number] : " + contact.PhoneNumber);
            Console.Write("\t[Email address] : " + contact.Email+"\n");
        }
    }
}
