using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_System
{
    public class Contact
    {
        // Contact details....
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

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
        public override string ToString()
        {
            return $"Name : {FirstName} {LastName} \nAddress : {Address} \nCity : {City} \nState : {State} \nZip : {Zip} \nPhone : {PhoneNumber} \nEmail : {Email}";
        }
    }
}
