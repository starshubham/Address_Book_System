using System;
using System.Collections.Generic;

namespace Address_Book_System
{
    /* UC9:- Ability to view Persons by City or State
             - Maintain Dictionary of City and Person as well as State and Person
             - Use Collection Library to maintain
     */
    class Program
    {
        
        //create Dictionary for AddressBook
        static Dictionary<String, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();

        static void Main(string[] args)
        {
            bool loop1 = true; //Boolean Value True Or False

            while (loop1)  //While loop to adding number of Address book system
            {
                Console.WriteLine("**** Welcome To Address Book System ****");
                Console.WriteLine("\n1.Add Address Book System\n2.Show Address Books System Names\n3.Search Person in City or State" +
                    "\n4.Get Number of Persons by city or States\n5.Exit "); //Print menu

                Console.Write("Enter Your Choice:- "); //Take input
                int choice1 = Convert.ToInt32(Console.ReadLine()); //take input user and store choice1 veriable

                while (choice1 > 4)//Check input is greater or not
                {
                    Console.WriteLine("Plz Enter Valid Option"); //print 
                    Console.Write("Enter Your Choice:-");  //take input
                    choice1 = Convert.ToInt32(Console.ReadLine()); //store choice1
                }


                AddressBook addressBook = new AddressBook(); //Creating Object of AddressBook
                string addressBookName = null; // addressBookName empty or null

                AddressBook edit = new AddressBook();  //Create object of AddressBook class

                switch (choice1)  //switch Case
                {
                    case 1:

                        Console.Write("Enter Address Book System Name:- "); //take input user side

                        addressBookName = Console.ReadLine();  //Store name addressBookName

                        bool isKeyAvailable = false; // true if a key press is available; otherwise, false.

                        foreach (KeyValuePair<string, AddressBook> keyValue in addressBookDictionary) //Iterating dictionary  displayed
                        {
                            if (keyValue.Key.Equals(addressBookName)) //Check Addressbook name exixt or not
                            {
                                isKeyAvailable = true; //value is present
                            }
                        }
                        if (isKeyAvailable) //value is present print message
                        {
                            Console.WriteLine($"Address Book System {addressBookName} is Already Exist\n Please Enter New Address Book Name:-");
                            addressBookName = Console.ReadLine();//Take input user

                        }
                        bool loop2 = true;
                        Console.WriteLine("**** Welcome To Address Book System ****");
                        //AddressBook edit = new AddressBook();  //Create object of AddressBook class
                        while (loop2)
                        {
                            Console.WriteLine("\n1. Add New Person      ");
                            Console.WriteLine("2. Display Records     ");
                            Console.WriteLine("3. Edit Records        ");
                            Console.WriteLine("4. Delete Records      ");
                            Console.WriteLine("5. Exit		        \n");
                            Console.Write("Enter Your Choice:- ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    edit.AddRecord(); //call AddRecord Method
                                    break;
                                case 2:
                                    edit.DisplayRecord();  //call DisplayRecord Method
                                    break;
                                case 3:
                                    Console.Write("Enter First Name To Edit Records:- ");
                                    String firstName = Console.ReadLine();
                                    edit.EditRecord(firstName); //call Edit record method
                                    break;
                                case 4:
                                    Console.Write("Enter First Name To Delete Records:- ");
                                    String Name = Console.ReadLine();
                                    edit.DeleteRecord(Name); //call Delete record method
                                    break;
                                case 5:
                                    loop2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter Valid Option");
                                    break;
                            }
                        }
                        addressBookDictionary.Add(addressBookName, addressBook);//Addrees book add Name
                        break;
                    case 2:
                        Console.WriteLine(" Available Address Books System ");

                        foreach (KeyValuePair<String, AddressBook> keyValue in addressBookDictionary) //Iterating
                        {
                            Console.WriteLine("Address Book System Name:- " + keyValue.Key); //print 
                        }
                        break;
                    case 3:
                        edit.SearchRecordCityOrState(); 
                        break;
                    case 4:
                        AddressBook.CountByCityOrStateName();
                        break;
                    default:
                        loop1 = false;
                        break;
                }

            }
        }
    }
}
