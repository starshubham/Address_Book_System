using System;
using System.Collections.Generic;

namespace Address_Book_System
{
    class AddressBook
    {
        //declaring list with class contacts type
        public static List<PersonsDetails> contacts = new List<PersonsDetails>();
        //declaring dictionary
        public static Dictionary<string, List<PersonsDetails>> addressBook = new Dictionary<string, List<PersonsDetails>>();
        //declaring it static so that we dont need to create an object in the program.cs
        public static void AddTo(string name)      //this method is used to pass the new address book name to the dictionary
        {
            addressBook.Add(name, contacts);
        }
        //This method for add new contact in address book
        public static void AddContact()
        {
            //creating object of PersonsDetails class
            PersonsDetails person = new PersonsDetails();
            //storing user input in contact
            Console.Write(" Enter your First name : ");
            person.FirstName = Console.ReadLine();
            Console.Write(" Enter your Last name : ");
            person.LastName = Console.ReadLine();
            Console.Write(" Enter your Address : ");
            person.Address = Console.ReadLine();
            Console.Write(" Enter your City : ");
            person.City = Console.ReadLine();
            Console.Write(" Enter your State : ");
            person.State = Console.ReadLine();
            Console.Write(" Enter your Zip Code : ");
            person.ZipCode = Console.ReadLine();
            Console.Write(" Enter your Phone Number : ");
            person.PhoneNumber = Console.ReadLine();
            Console.Write(" Enter your Email-ID : ");
            person.Email = Console.ReadLine();
            //storing all input from user into contacts
            contacts.Add(person);
            Console.WriteLine("\n {0}'s contact succesfully added", person.FirstName);
        }

        //This method for view added Contact details
        public static void Details()
        {
            //if statement for show nothing in list
            if (contacts.Count == 0)
            {
                Console.WriteLine("Currently there are no people added in your address book.");
            }
            //else statement for show details of contacts in addressbook
            else
            {
                Console.WriteLine("Here is the list and details of all the contacts in your addressbook.");

                // foreacch loops iterates through all the contacts objects in the contacts class
                foreach (var Detailing in contacts)
                {
                    Console.WriteLine("First name : " + Detailing.FirstName);
                    Console.WriteLine("Last name : " + Detailing.LastName);
                    Console.WriteLine("Address : " + Detailing.Address);
                    Console.WriteLine("State : " + Detailing.State);
                    Console.WriteLine("City : " + Detailing.City);
                    Console.WriteLine("Zip Code : " + Detailing.ZipCode);
                    Console.WriteLine("Phone number = " + Detailing.PhoneNumber);
                    break;
                }
            }
        }


    }
}
