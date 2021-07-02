using System;
using System.Collections.Generic;
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
            this.ContactList.Add(contact);
        }
    }
}
