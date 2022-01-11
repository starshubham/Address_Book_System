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
            Console.Write("How many contacts do you want to add ? : ");
            int contactsNum = Convert.ToInt32(Console.ReadLine());
            while (contactsNum > 0)
            {
                PersonsDetails person = new PersonsDetails();


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

                addressBook.Add(person);
                Console.WriteLine("\n {0}'s contact succesfully added", person.FirstName);
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
                    if (nameKey.ToLower() == contact.FirstName.ToLower())
                    {
                        Console.WriteLine("\n First name-->{0}", contact.FirstName);
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
                        Console.WriteLine(" Contact of the person {0} does not exist", nameKey);
                    }
                }
            }
            else
            {
                Console.WriteLine(" Your address book is empty");
            }
        }

        public static void Delete()
        {
            Console.Write("\n Enter the first name of the person whose contact you want to delete from the addressbook : ");
            string deleteKey = Console.ReadLine();
            int flag = 0;
            if (addressBook.Count > 0)
            {
                foreach (PersonsDetails person in addressBook)
                {
                    if (deleteKey.ToLower() == person.FirstName.ToLower())
                    {
                        Console.Write("\n Do You Want To Delete This Contact press Y : ");
                        char ch = Convert.ToChar(Console.ReadLine());

                        if (ch == 'Y' || ch == 'y')
                        {
                            flag = 1;
                            addressBook.Remove(person);
                            Console.WriteLine(" Contact is Deleted.");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }

            if (flag == 0)
            {
                Console.WriteLine("contact of the person {0} does not exist", deleteKey);
            }
        }

        public static void Edit()
        {
            Console.Write("\n Enter the first name of the person whom you want to edit the details : ");
            string editKey = Console.ReadLine();
            if (addressBook.Count > 0)
            {
                foreach (PersonsDetails persons in addressBook)
                {
                    if (editKey.ToLower() == persons.FirstName.ToLower())
                    {
                        Console.WriteLine("\n Enter the key number for editing the details." +
                            "\n1.First Name " +
                            "\n2.Last Name " +
                            "\n3.Address " +
                            "\n4.City " +
                            "\n5.State " +
                            "\n6.Zipcode " +
                            "\n7.Phone Number " +
                            "\n8.Email ID");
                        Console.Write(" Enter your option : ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        switch (key)
                        {
                            case 1:
                                Console.Write("Enter the new First Name : ");
                                persons.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the new Last name");
                                persons.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write(" Enter the New Address : ");
                                persons.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.Write(" Enter the New City : ");
                                persons.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.Write(" Enter the New State : ");
                                persons.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.Write("Enter the New Zip Code : ");
                                persons.ZipCode = Console.ReadLine();
                                break;
                            case 7:
                                Console.Write(" Enter the New Phone Number : ");
                                persons.PhoneNumber = Console.ReadLine();
                                break;
                            case 8:
                                Console.Write(" Enter the New EMail-ID : ");
                                persons.Email = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine(" Please enter a valid input");
                                Edit();
                                break;
                        }
                        Console.WriteLine(" {0}'s contact has been successfully added", editKey);
                        break;
                    }
                }
                //Console.WriteLine(" Contact of the person {0} does not exist", editKey);
            }
            else
            {
                Console.WriteLine(" Your address book is empty");
            }
        }
    }
}
