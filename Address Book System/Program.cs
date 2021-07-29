using System;
using System.Collections.Generic;

namespace Address_Book_System
{
    class Program
    {
        // Dictionary for Mulyiple AddressBook......
        public static Dictionary<string, AddressBook> ContactMap = new Dictionary<string, AddressBook>();
        // Dictionary for Contacts which are in same City ......
        public static Dictionary<string, List<Contact>> CityWiseContacts = new Dictionary<string, List<Contact>>();
        // Dictionary for Contacts which are in same State......
        public static Dictionary<string, List<Contact>> StateWiseContacts = new Dictionary<string, List<Contact>>();
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book Program ");

            // Object of AdressBook is Created.....
            int choice;
            bool alive = true;
            string name;
            while (alive)
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n 3.View Contact By City or State \n 4.Count Number of in City or State \n 5.Save and Exit \n 6.Read File \n 0.Exit");
                Console.Write("\n Select Options : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the Name of Address Book : ");
                        name = Console.ReadLine();
                        ContactMap.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.Write("Enter the Name of Address Book you wish to Work On : ");
                        name = Console.ReadLine();
                        AddressBook addressBook = ContactMap[name];
                        AddressBookMain(addressBook,name);
                        break;
                    case 3:
                        ViewPersonByCityOrState();
                        break;
                    case 4:
                        CountPersonByCityOrState();
                        break;
                    case 5:
                        foreach (KeyValuePair<string, AddressBook> kvp in ContactMap)
                        {
                            FileReadWrite.WriteIntoCSVFile(kvp.Key, kvp.Value);
                        }
                        break;
                    case 6:
                        ContactMap = FileReadWrite.ReadFromCSVFile();
                        break;
                    case 0:
                        alive = false;
                        break;
                }
            } 
        }
        public static void AddressBookMain(AddressBook addressBook,string addressBookName)
        { 
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("\n Name of Address Book : " + addressBookName);
                // Obtions are Show to User.......
                Console.WriteLine(" Options");
                Console.WriteLine(" 1. Add a new Contact");
                Console.WriteLine(" 2.Edit Contact ");
                Console.WriteLine(" 3.Delete Contact ");
                Console.WriteLine(" 4.Number of Contacts in Address Book : "+ addressBookName);
                Console.WriteLine(" 0.Exit ");

                // Reads the Option.....
                Console.Write("\n Select Options : ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Contact contact = new Contact();   // New Contact Object is Created ....
                        ReadContact(contact);             //method is called for input of contact details....
                        addressBook.Add_Contacts(contact);  // contact details is added to a List...
                        AddCityOrStateContacts(contact);   // Add City and State Contacts to City and State Address Book........
                        break;
                    case 2:                        
                        //  PhoneNumber of Contact to be Edit is given as input.......
                        Console.Write("Enter the Phone Number of Contact you wish to Edit : ");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        //Index of the Contact Object is given with the help of PhoneNumber......
                        int index = addressBook.FindByPhoneNumber((int)phoneNumber);
                        if (index == -1)
                        {
                            Console.WriteLine("\n No Contact Exists With Following Phone Number\n");
                        }
                        else
                        {
                            Contact contact2 = new Contact(); 
                            ReadContact(contact2);
                            // Updating List and Dictionary After editing......
                            addressBook.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                                        
                    case 3:
                        Console.Write("Enter the First Name of Contact you wish to delete : ");
                        string firstname = Console.ReadLine();
                        // Index of the Contact Object is given with the help of FirstName......
                        int contact_id = addressBook.FindByFirstName(firstname);
                        if (contact_id == -1)
                        {
                            Console.WriteLine("\n No Contact Exists with Following First Name\n");                            
                        }
                        else
                        {
                            // method to delete the contact is called.....
                            addressBook.DeleteContact(contact_id);
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        break;

                    case 4:
                        // Number of Contacts is give......(count)...
                        Console.WriteLine("\n Total Number of myDict are : " + ContactMap.Count);
                        Console.WriteLine(" Number of Contacts in this Dictionary : " + addressBook.ContactList.Count);
                        break;

                    case 0:
                        stop = true;
                        break;
                    default:
                        break;
                }
            }
            
        }

        public static void ReadContact(Contact contact)
        {
            // Persons Contact details is Added.....
            Console.Write("Enter the First Name : ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter the Last Name : ");
            contact.LastName = Console.ReadLine();
            Console.Write("Enter the Address : ");
            contact.Address = Console.ReadLine();
            Console.Write("Enter the City Name : ");
            contact.City = Console.ReadLine();
            Console.Write("Enter the State Name : ");
            contact.State = Console.ReadLine();
            Console.Write("Enter the zip code : ");
            contact.Zip = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Phone Number : ");
            contact.PhoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter the email address : ");
            contact.Email = Console.ReadLine();
        }
        public static void AddCityOrStateContacts(Contact contact)
        {
            // Adding City Wise Contacts to City Address Book........
            if (!CityWiseContacts.ContainsKey(contact.City))
            {
                List<Contact> cityContact = new List<Contact>();
                cityContact.Add(contact);
                CityWiseContacts.Add(contact.City, cityContact);
            }
            else
            {
                List<Contact> cityContact=CityWiseContacts[contact.City];
                cityContact.Add(contact);
            }


            // Adding State Wise Contacts to State Address Book........
            if (!StateWiseContacts.ContainsKey(contact.State))
            {
                List<Contact> stateContact = new List<Contact>();
                stateContact.Add(contact);
                StateWiseContacts.Add(contact.State, stateContact);
            }
            else
            {
                List<Contact> stateContact = StateWiseContacts[contact.State];
                stateContact.Add(contact);
            }
        }
        public static void ViewPersonByCityOrState()
        {
            int choice;
            Console.WriteLine(" 1.View Person Contact By City \n 2.View Person Contact By State");
            Console.Write("\n Select Options : ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write(" Enter the City Name : ");
                    string city = Console.ReadLine();
                    List<Contact> cityContact = CityWiseContacts[city];
                    Console.WriteLine("\n Contacts in the "+city+" City");
                    foreach (Contact contact in cityContact)
                    {
                        Contact.DisplayContact(contact);
                    }
                    break;
                case 2:
                    Console.Write(" Enter the State Name : ");
                    string state = Console.ReadLine();
                    List<Contact> stateContact = StateWiseContacts[state];
                    Console.WriteLine("\n Contacts in the " + state + " State");

                    foreach (Contact contact in stateContact)
                    {
                        Contact.DisplayContact(contact);
                    }
                    break;
            }
        }
        public static void CountPersonByCityOrState()
        {
            int choice;
            Console.WriteLine(" 1.Count Number of Contacts in City \n 2.Count Number of Contacts in State");
            Console.Write("\n Select Options : ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write(" Enter the City Name : ");
                    string city = Console.ReadLine();
                    List<Contact> cityContact = CityWiseContacts[city];
                    Console.WriteLine("\n Number of Contacts in the " + city + " City : "+cityContact.Count);
                    break;
                case 2:
                    Console.Write(" Enter the State Name : ");
                    string state = Console.ReadLine();
                    List<Contact> stateContact = StateWiseContacts[state];
                    Console.WriteLine("\n Number of Contacts in the " + state + " State : "+stateContact.Count);
                    break;
            }
        }
    }
}
