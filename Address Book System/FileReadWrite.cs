using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Address_Book_System
{
    class FileReadWrite
    {
        public static void ReadFromFile(string bookName)
        {
            string path = $"C://Users//Admin//source//repos//Address Book System//Address Book System//Binary//{bookName}.txt";
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }
        public static void WriteToFile(string bookName, AddressBook addressBook)
        {
            try
            {
                string path = ($"C://Users//Admin//source//repos//Address Book System//Address Book System//Binary//{bookName}.txt");
                StreamWriter stream = new StreamWriter(path);
                foreach(Contact list in addressBook.ContactList)
                {
                    string line = "Name:" + list.FirstName + " " + list.LastName + " Address:" + list.Address + " City:" + list.City + " State:" + list.State + " Zipcode:" + list.Zip + " Ph.No:" + list.PhoneNumber;
                    stream.WriteLine(line);
                }
                stream.Close();
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}
