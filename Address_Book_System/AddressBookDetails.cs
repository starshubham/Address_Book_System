﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class AddressBookDetails : IAddressBook
    {
        string nameOfAddressBook;
        // Constants
        const string ADD_CONTACT = "add";
        const string UPDATE_CONTACT = "update";
        const string SEARCH_CONTACT = "search";
        const string REMOVE_CONTACT = "remove";
        const string GET_ALL_CONTACTS = "view";
        const string WRITE = "write";
        const string READFILE = "fread";
        const string READCSV = "cread";
        const string READJSON = "jread";


        // Collection Decleration
        public Dictionary<string, AddressBook> addressBookList = new Dictionary<string, AddressBook>();
        public static Dictionary<string, List<ContactDetails>> cityToContactMap = new Dictionary<string, List<ContactDetails>>();
        public static Dictionary<string, List<ContactDetails>> stateToContactMap = new Dictionary<string, List<ContactDetails>>();
        private Dictionary<string, List<ContactDetails>> cityToCOntactMapInstance;
        private Dictionary<string, List<ContactDetails>> stateToContactMapInstance;

        /*   UC6:- Refactor to add multiple Address Book to the System.Each Address Book has a unique Name 
                    - Use Console to add new Address Book - Maintain Dictionary of Address Book Name to Address Book
           */
        private AddressBook GetAddressBook() //create get address book method
        {
            try
            {
                Console.Write("\nEnter Address Book System Name:-"); //print
                nameOfAddressBook = Console.ReadLine(); //take input           
                while (addressBookList.ContainsKey(nameOfAddressBook)) // search for address book in dictionary
                {
                    Console.Write($"\nAddress Book System Name {nameOfAddressBook} is Already Exist\n"); //print
                    Console.Write("Please Enter New Address Book Name:-");
                    nameOfAddressBook = Console.ReadLine(); //take input          
                }
                AddressBook addressBook = new AddressBook(nameOfAddressBook);
                addressBookList.Add(nameOfAddressBook, addressBook);//Add Address Book NAme
                Console.WriteLine("\nSuccessfully Address Book Created");  //print
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return addressBookList[nameOfAddressBook];
        }

        /* UC8:- Ability to search Person in a City or State across the multiple AddressBook
                     - Search Result can show multiple person in the city or state
         */
        public void SearchInCity()
        {
            try
            {

                if (addressBookList.Count == 0) //no record found if address book is empty
                {
                    Console.WriteLine("\nRecord Not Found");
                    return;
                }
                Console.Write("\nEnter City Name to search for Record:- ");// Get the name of city from user
                string cityName = Console.ReadLine();
                if (!cityToContactMap.ContainsKey(cityName) || cityToContactMap[cityName].Count == 0) // If the city doesnt have any contacts
                {
                    Console.WriteLine($"\n{cityName } Name Record Not Found");
                    return;
                }

                Console.Write("\nEnter Person First Name to Search:- "); // Get the person name to be searched
                string firstName = Console.ReadLine();
                var searchResult = cityToContactMap[cityName].FindAll(contact => contact.FirstName.ToLower() == firstName); //city and name matches with search
                if (searchResult.Count == 0)
                {
                    Console.WriteLine("\nRecord  Not Found");
                    return;
                }
                Console.Write("The contacts found in of given search are:-");

                searchResult.ForEach(contact => contact.Display());   // print the list of contacts whose city and name matches with search
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void SearchInState()
        {
            try
            {
                if (addressBookList.Count == 0) //no record found if address book is empty
                {
                    Console.WriteLine("\nNo Record Found");
                    return;
                }
                Console.Write("\nEnter State Name:- "); // Get the name of city from user
                string stateName = Console.ReadLine();
                if (!stateToContactMap.ContainsKey(stateName) || stateToContactMap[stateName].Count == 0)// If the city doesnt have any contacts
                {
                    Console.WriteLine("\nNo Record Found");
                    return;
                }

                // Get the person name to be searched
                Console.WriteLine("\nEnter the person firstname to be searched");
                string firstName = Console.ReadLine().ToLower();
                Console.WriteLine("\nEnter the person lastname to be searched");
                string lastName = Console.ReadLine().ToLower();

                // Get the list of contacts whose city and name matches with search
                var searchResult = stateToContactMap[stateName].FindAll(contact => contact.FirstName.ToLower() == firstName
                                                                        && contact.LastName.ToLower() == lastName);

                // If no contacts exist
                if (searchResult.Count() == 0)
                {
                    Console.WriteLine("\nNo contacts found");
                    return;
                }
                Console.Write("\nThe contacts found in of given search are :");

                // Display the search results
                searchResult.ForEach(contact => contact.Display());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        /* UC9 :- Ability to view Persons by City or State
                  - Maintain Dictionary of City and Person as well as State and Person
                  - Use Collection Library to maintain Dictionary
         */
        public void ViewAllByCity()
        {
            try
            {
                if (addressBookList.Count == 0)
                {
                    Console.WriteLine("\nNo record found");
                    return;
                }

                // Get the name of city from user
                Console.WriteLine("\nEnter the city name to search for contact");
                string cityName = Console.ReadLine().ToLower();

                // If the given city doesnt exist
                if (!(cityToContactMap.ContainsKey(cityName)))
                {
                    Console.WriteLine($"\n{cityName} Record Not exist in the city");
                    return;
                }

                cityToContactMap[cityName].ForEach(contact => contact.Display());   // Print all contact details in city
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ViewAllByState()
        {
            try
            {

                if (addressBookList.Count == 0)
                {
                    Console.WriteLine("\n Record Not Found");
                    return;
                }
                Console.WriteLine("\nEnter State Name to search for Record"); // take the name of city from user
                string stateName = Console.ReadLine().ToLower();

                if (!(stateToContactMap.ContainsKey(stateName))) //given city doesnt exist
                {
                    Console.WriteLine("\nNo contacts exist in the state");
                    return;
                }

                // To print details of all the contacts
                stateToContactMap[stateName].ForEach(contact => contact.Display());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public static void AddToCityDictionary(string cityName, ContactDetails contact)
        {
            try
            {
                if (!(cityToContactMap.ContainsKey(cityName)))  // Check if the map already has city key
                    cityToContactMap.Add(cityName, new List<ContactDetails>());
                cityToContactMap[cityName].Add(contact); // Add the contact to list of respective city map
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void AddToStateDictionary(string stateName, ContactDetails contact)
        {
            try
            {

                if (!stateToContactMap.ContainsKey(stateName)) // Check if the map already has state key
                    stateToContactMap.Add(stateName, new List<ContactDetails>());

                stateToContactMap[stateName].Add(contact); // Add the contact to list of respective city map
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        /* UC10:- Ability to get number of contact persons i.e. count by City or State.
                      - Search Result will show count by city and by state.
        */
        internal void CountAllByCity()
        {           
            try
            {

                if (addressBookList.Count == 0)// Returns no record found if address book is empty
                {
                    Console.WriteLine("\nNo record found");
                    return;
                }

                // To get count of contacts in all cities
                foreach (KeyValuePair<string, List<ContactDetails>> keyValuePair in cityToContactMap)
                    Console.WriteLine("No of contacts in city {0} is {1}", keyValuePair.Key, keyValuePair.Value.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        internal void CountAllByState()
        { 
            try
            {

                if (addressBookList.Count == 0) // Returns no record found if address book is empty
                {
                    Console.WriteLine("\nNo record found");
                    return;
                }
                foreach (KeyValuePair<string, List<ContactDetails>> keyValuePair in stateToContactMap) // To get count of contacts in all cities
                    Console.WriteLine("Nunber of contacts in state {0} is {1}", keyValuePair.Key, keyValuePair.Value.Count());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        
        public void DeleteAddressBook()
        {

            if (addressBookList.Count == 0) // Returns no record found if address book is empty
            {
                Console.WriteLine("Record Not Found");
                return;
            }
            Console.Write("\nEnter Name of Address Book to Deleted:- ");
            try
            {
                string addressBookName = Console.ReadLine();//search for address book with given name              
                addressBookList.Remove(addressBookName);  // Remove AddressBook with given name               
                foreach (KeyValuePair<string, List<ContactDetails>> keyValuePair in cityToContactMap)
                    cityToContactMap[keyValuePair.Key].RemoveAll(contact => contact.NameOfAddressBook == addressBookName); // Remove contacts from city dictionary                
                foreach (KeyValuePair<string, List<ContactDetails>> keyValuePair in stateToContactMap)
                    stateToContactMap[keyValuePair.Key].RemoveAll(contact => contact.NameOfAddressBook == addressBookName);
                Console.WriteLine("Address Book Successfully Deleted ");
            }
            catch
            {
                Console.WriteLine("Address book not found");
            }
        }

        public void ViewAllAddressBooks()
        {
            try
            {
                if (addressBookList.Count() == 0) // Returns no record found if address book is empty
                {
                    Console.WriteLine("No Address Book Found");
                    return;
                }

                // Print the address book names available
                Console.WriteLine("\nThe Address Books Available are Name is :- ");
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookList) //iterate and print
                    Console.WriteLine(keyValuePair.Key); //ptint address book name
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void AddAddressBook()
        {
            try
            {
                AddressBook addressBook = GetAddressBook(); //get the name of the addressbook

                if (addressBook == null) //address book is empty
                {
                    Console.WriteLine("Address Book Empty");
                    return;
                }

                while (true)
                {
                    Console.WriteLine($"\n**** Welcome To {addressBook.nameOfAddressBook} Address Book System ****");

                    Console.Write("\n1.Add New contact" +
                                      "\n2.Display all contacts" +
                                      "\n3.Edit Record" +
                                      "\n4.Delete Records" +
                                      "\n5.Search Contact Records" +
                                      "\n0.Exit\n " +
                                      "\nEnter Your Choice:- ");
                    int choice4 = Convert.ToInt32(Console.ReadLine());

                    switch (choice4)
                    {
                        case 1:
                            addressBook.AddContact();
                            break;
                        case 2:
                            addressBook.GetAllContacts();
                            break;
                        case 3:
                            addressBook.EditContact();
                            break;
                        case 4:
                            addressBook.RemoveContact();
                            break;

                        case 5:
                            addressBook.SearchContactDetails();
                            break;

                        case 0:
                            Console.WriteLine("Exiting Address Book");
                            return;
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
