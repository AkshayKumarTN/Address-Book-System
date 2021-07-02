using System;

namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book Program \n");

            // Object of AdressBook is Created.....
            AddressBook addressBook = new AddressBook();

            // Obtions are Show to User.......
            Console.WriteLine(" Options");
            Console.WriteLine(" 1. Add a new Contact");

            // Reads the Option.....
            Console.Write("\n Select Options : ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Contact contact = new Contact();   // New Contact Object is Created ....
                    Read_Contact(contact);             //method is called for input of contact details....
                    addressBook.Add_Contacts(contact);  // contact details is added to a List...
                    break;
                default:
                    break;
            }
            // Number of Contacts is give......(count)...
            Console.WriteLine("\n Number of Contacts : "+addressBook.ContactList.Count);
        }

        public static void Read_Contact(Contact contact)
        {
            // Contact details is Added.....
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
