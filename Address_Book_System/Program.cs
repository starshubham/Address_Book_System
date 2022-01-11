using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program \n");

            // UC4 : Ability to delete a person using person's name
            AddressBook.AddContact();
            AddressBook.Display();
            AddressBook.Delete();
            AddressBook.Display();
        }
    }
}
