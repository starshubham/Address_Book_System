using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class AddressBook
    {
        public static List<PersonsDetails> addressBook = new List<PersonsDetails>();

        public static void AddContact()
        {
            Console.WriteLine(" You have to enter your details here. \n");
            int contactsNum = 1;
            while (contactsNum > 0)
            {
                PersonsDetails person = new PersonsDetails();

                Console.Write(" Enter your First name : ");
                person.Firstname = Console.ReadLine();
                Console.Write(" Enter your Last name : ");
                person.LastName = Console.ReadLine();
                Console.Write(" Enter your Address : ");
                person.Address = Console.ReadLine();
                Console.Write(" Enter your City : ");
                person.City = Console.ReadLine();
                Console.Write(" Enter your State : ");
                person.State = Console.ReadLine();
                Console.Write(" Enter your Zip code : ");
                person.ZipCode = Console.ReadLine();
                Console.Write(" Enter your Phone number : ");
                person.PhoneNumber = Console.ReadLine();
                Console.Write(" Enter your Email ID : ");
                person.Email = Console.ReadLine();

                addressBook.Add(person);
                Console.WriteLine("\n {0}'s contact succesfully added", person.Firstname);
                contactsNum--;
            }
        }
        public static void Display()
        {
            if (addressBook.Count > 0)
            {
                Console.Write("\n Enter the name of the person to get all the contact details : ");
                string nameKey = Console.ReadLine();
                foreach (PersonsDetails contact in addressBook)
                {
                    if (nameKey.ToLower() == contact.Firstname.ToLower())
                    {
                        Console.WriteLine(" First name-->{0}", contact.Firstname);
                        Console.WriteLine(" Last name-->{0}", contact.LastName);
                        Console.WriteLine(" Address-->{0}", contact.Address);
                        Console.WriteLine(" City-->{0}", contact.City);
                        Console.WriteLine(" State-->{0}", contact.State);
                        Console.WriteLine(" Zip code-->{0}", contact.ZipCode);
                        Console.WriteLine(" Phone number-->{0}", contact.PhoneNumber);
                        Console.WriteLine(" E-Mail ID-->{0}", contact.Email);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Contact of the person {0} does not exist", nameKey);
                    }
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
        }
    }
}
