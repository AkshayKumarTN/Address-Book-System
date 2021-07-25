using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Address_Book_System
{
    class FileReadWrite
    {
        public static AddressBook ReadFromFile(string bookName)
        {
            AddressBook addressBook;
            using (Stream stream = File.Open($"C://Users//Admin//source//repos//Address Book System//Address Book System//Binary//{bookName}.txt", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                addressBook = (AddressBook)bin.Deserialize(stream);
            }
            return addressBook;
        }
        public static void WriteToFile(string bookName, AddressBook addressBook)
        {
            try
            {
                string path = ($"C://Users//Admin//source//repos//Address Book System//Address Book System//Binary//{bookName}.txt");
                FileStream stream = File.OpenWrite(path);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, addressBook.ContactList[0]);
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}
