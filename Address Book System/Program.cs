using System;
using System.Collections.Generic;

namespace Address_Book_System
{
    class Program
    {
        public static Dictionary<string, AddressBook> ContactMap = new Dictionary<string, AddressBook>();
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book Program ");

            // Object of AdressBook is Created.....
            int choice;
            bool alive = true;
            string name;
            while (alive)
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n 0.Exit");
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
                Console.WriteLine(" 4.Number of Contacts");
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
    }
}
