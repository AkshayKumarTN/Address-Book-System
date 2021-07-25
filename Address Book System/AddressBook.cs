using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Address_Book_System
{
    class AddressBook
    {

        // List for (Contact) class objects is created.....
        public List<Contact> ContactList;
        public AddressBook()
        {
            this.ContactList = new List<Contact>();
        }
        public void Add_Contacts(Contact contact)
        {
            // add class objects in list c.....
            if (this.ContactList.Find(e => e.Equals(contact))!= null)
                Console.WriteLine("\n The Contact Already Exists! Try Again.");
            else
                this.ContactList.Add(contact);
        }
        public int FindByPhoneNumber(int number)
        {
            // Returns the index of Contact....
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(number));
           
        }
        //Find Contact Object Index with help of  given FirstName......
        public int FindByFirstName(string firstName)
        {
            return this.ContactList.FindIndex(contact => contact.FirstName.Equals(firstName));
        }
        //Delete Contact with help of Index.......
        public void DeleteContact(int index)
        {
            this.ContactList.RemoveAt(index);
        }

        // Sorting Entries By First Name.............
        public List<Contact> SortByFirstName()
        {
            return this.ContactList.OrderBy(contact => contact.FirstName).ToList();
        }

        // Sorting Entries By City.............
        public List<Contact> SortByCity()
        {
            return this.ContactList.OrderBy(contact => contact.City).ToList();
        }
        // Sorting Entries By State.............
        public List<Contact> SortByState()
        {
            return this.ContactList.OrderBy(contact => contact.State).ToList();
        }

        // Sorting Entries By Zip.............
        public List<Contact> SortByZip()
        {
            return this.ContactList.OrderBy(contact => contact.Zip).ToList();
        }

    }
}
