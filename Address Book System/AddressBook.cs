using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_System
{
    class AddressBook
    {

        // List for (Contact) class objects is created.....
        public List<Contact> ContactList;
        public Dictionary<string, Contact> ContactMap;
        public AddressBook()
        {
            this.ContactList = new List<Contact>();
            ContactMap = new Dictionary<string, Contact>();
        }
        public void Add_Contacts(Contact contact, string name)
        {
            // add class objects in list c.....
            this.ContactList.Add(contact);
            ContactMap.Add(name, contact);
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
        
    }
}
