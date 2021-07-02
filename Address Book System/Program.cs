using System;

namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book Program ");

            // Object of AdressBook is Created.....
            AddressBook addressBook = new AddressBook();
            bool stop = false;
            while (!stop)
            {
                // Obtions are Show to User.......
                Console.WriteLine("\n Options");
                Console.WriteLine(" 1. Add a new Contact");
                Console.WriteLine(" 2.Edit Contact ");
                Console.WriteLine(" 3.Number of Contacts");
                Console.WriteLine(" 0.Exit ");

                // Reads the Option.....
                Console.Write("\n Select Options : ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Contact contact = new Contact();   // New Contact Object is Created ....
                        Read_Contact(contact);             //method is called for input of contact details....
                        addressBook.Add_Contacts(contact);  // contact details is added to a List...
                        break;
                    case 2:
                        Console.WriteLine("Enter the Phone Number of Contact you wish to Edit");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        int index = addressBook.FindByPhoneNumber((int)phoneNumber);
                        if (index == -1)
                        {
                            Console.WriteLine("\n No Contact Exists With Following Phone Number\n");
                        }
                        else
                        {
                            Contact contact2 = new Contact();
                            Read_Contact(contact2);
                            addressBook.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                    case 0:
                        stop = true;
                        break;
                    case 3:
                        // Number of Contacts is give......(count)...
                        Console.WriteLine("\n Number of Contacts : " + addressBook.ContactList.Count);
                        break;
                    default:
                        break;
                }
            }
            
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
