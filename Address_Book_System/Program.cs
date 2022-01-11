using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program \n");

            // UC3 : Ability to edit existing contact person using their name
            AddressBook.AddContact();
            AddressBook.Display();
            AddressBook.Edit();
            AddressBook.Display();
        }
    }
}
