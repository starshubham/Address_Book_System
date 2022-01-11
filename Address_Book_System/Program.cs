using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program \n");

            // UC5 : Ability to multiple person to Address Book
            AddressBook.AddContact();
            AddressBook.Display();
        }
    }
}
