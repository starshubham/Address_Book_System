using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program \n");

            // UC2 : Ability to add a new Contact to Address Book
            AddressBook.AddContact();
            AddressBook.Display();
        }
    }
}
