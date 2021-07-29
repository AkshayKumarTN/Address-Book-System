using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Address_Book_System
{
    class FileReadWrite 
    {
        public static void ReadFromFile(string bookName)
        {
            string path = $"C://Users//Admin//source//repos//Address Book System//Address Book System//IOFile//{bookName}.txt";
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }
        public static void WriteToFile(string bookName, AddressBook addressBook)
        {
            try
            {
                string path = ($"C://Users//Admin//source//repos//Address Book System//Address Book System//IOFile//{bookName}.txt");
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

        public static void WriteIntoCSVFile(string bookName, AddressBook addressBook)
        {
            string path = ($"C://Users//Admin//source//repos//Address Book System//Address Book System//CSVFile//{bookName}.csv");

            using (StreamWriter writer = new StreamWriter(path))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(addressBook.ContactList);
                }
            }
        }

        public static Dictionary<string, AddressBook> ReadFromCSVFile()
        {
            string bookName = "Friends";
            string path = ($"C://Users//Admin//source//repos//Address Book System//Address Book System//CSVFile//{bookName}.csv");

            //read all the file from the list
            Dictionary<string, AddressBook> ContactMap = new Dictionary<string, AddressBook>();
            using (StreamReader reader =new StreamReader(path))
            {
                using(var csvReader = new CsvReader(reader,CultureInfo.InvariantCulture))
                {
                    AddressBook addressBook = new AddressBook();
                    csvReader.Read();
                    var result = csvReader.GetRecord<Contact>();
                    addressBook.ContactList.Add(result);
                    ContactMap[bookName] = addressBook;
                }
            }
            return ContactMap;
        }
    }
}
