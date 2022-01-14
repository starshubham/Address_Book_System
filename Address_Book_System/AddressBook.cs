﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Address_Book_System
{
    class AddressBook
    {
        // Constants
        private const int UPDATE_FIRST_NAME = 1;
        private const int UPDATE_LAST_NAME = 2;
        private const int UPDATE_ADDRESS = 3;
        private const int UPDATE_CITY = 4;
        private const int UPDATE_STATE = 5;
        private const int UPDATE_ZIP = 6;
        private const int UPDATE_PHONE_NUMBER = 7;
        private const int UPDATE_EMAIL = 8;
        private const string PERSON_NAME = "name";
        private const string CITY = "city";
        private const string STATE = "state";
        private const string ZIP = "zip";

        // Variables
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNumber;
        private string email;
        public string nameOfAddressBook = " ";

        public List<ContactDetails> contactList = new List<ContactDetails>();
        public AddressBook(string name)
        {
            nameOfAddressBook = name;
        }
        /*UC7:- Ability to ensure there is no Duplicate Entry of the same Person in a particular Address Book
                        - Duplicate Check is done on Person Name while adding person to Address Book. 
                        - Use Collection Methods to Search Person by Name for Duplicate Entry.
                        - Override equals method to check for Duplicate.
                */
        public void AddContact() //Create AddContact method to add Record
        {
            Console.Write("Enter First Name:- "); //Take input
            firstName = Console.ReadLine(); //Store firstname           
            Console.Write("Enter Last Name:- ");//Take input
            lastName = Console.ReadLine();
            Console.Write("Enter The Address:- ");//Take input
            address = Console.ReadLine();
            Console.Write("Enter City:- ");//Take input
            city = Console.ReadLine();
            Console.Write("Enter State:- ");//Take input
            state = Console.ReadLine();
            Console.Write("Enter Zip Code:- ");//Take input
            zip = Console.ReadLine();
            Console.Write("Enter Phone Number:- ");//Take input
            phoneNumber = Console.ReadLine();
            Console.Write("Enter Email:- ");//Take input
            email = Console.ReadLine();
            // Creating an instance of contact with given details
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email, nameOfAddressBook);
            while (addNewContact.Equals(contactList))
            {
                Console.WriteLine("contact already exists");
                // Giving option to user to re enter or to exit
                Console.Write("1.Enter New Name\n0.Exit\nEnter Choice:- ");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 1)
                {
                    Console.WriteLine("Enter new First name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter new Last name");
                    lastName = Console.ReadLine();
                    addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email, nameOfAddressBook);
                }
                else
                    return;
            }

            contactList.Add(addNewContact);  // Adding the contact to list           
            AddressBookDetails.AddToCityDictionary(city, addNewContact); // Adding contact to city dictionary           
            AddressBookDetails.AddToStateDictionary(state, addNewContact);  // Adding contact to state dictionary
            Console.WriteLine("\nContact Added successfully");
        }

        public void SearchContactDetails() //create Search record method
        {
            try
            {
                if (contactList.Count() == 0) //List doesnt have any contacts
                {
                    Console.WriteLine("No Record Found"); //print msg
                    return;
                }
                Console.WriteLine("\nEnter the name of candidate to get Details");
                string name = Console.ReadLine().ToLower();

                ContactDetails contact = SearchByName(name);  // Search the contact by name          
                if (contact == null)  // If contact doesnt exist
                {
                    Console.WriteLine("No record found");
                    return;
                }
                contact.Display();// Print the details of the contact after search
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EditContact() //Create EditContact method to edite record
        {
            try
            {
                if (contactList.Count() == 0) //List have no contacts
                {
                    Console.WriteLine(" Record Not Found"); //print
                    return;
                }
                Console.Write("Enter First Name :- "); //Take First Name
                string name = Console.ReadLine();
                ContactDetails contact = SearchByName(name);   // Search the name

                if (contact == null)// If contact doesnt exist
                {
                    Console.WriteLine($"{name } Record Not Found");//Print
                    return;
                }

                contact.Display();  //  print record of searched contact

                int updateAttributeNum = 0;
                Console.Write("Enter Row number Record to be Edit:- "); //print and take input 
                try
                {
                    updateAttributeNum = Convert.ToInt32(Console.ReadLine());
                    if (updateAttributeNum == 0)
                        return;
                }
                catch
                {
                    Console.WriteLine("Invalid entry");
                    return;
                }
                Console.Write("Enter the New Record:- ");// Take input 
                string newValue = Console.ReadLine();
                switch (updateAttributeNum)   // Updating selected attribute with selected value
                {
                    case UPDATE_FIRST_NAME:
                        firstName = contact.FirstName;  // Store the firstname of contact in variable                   
                        contact.FirstName = newValue; // Update the contact with given name                   
                        if (contact.Equals(contactList)) // If duplicate contact exists with that name then revert the operation
                        {
                            contact.FirstName = firstName;
                            Console.Write($"Contact already exists that{ contact.FirstName} Name");
                            return;
                        }
                        break;
                    case UPDATE_LAST_NAME:
                        lastName = contact.LastName;// Store the LastName of given contact in variable                    
                        contact.LastName = newValue;// Update the contact with given name                   
                        if (contact.Equals(contactList)) // If duplicate contact exists with that name then revert the operation
                        {
                            contact.LastName = lastName;
                            Console.WriteLine($"Contact already exists with that {contact.LastName} name");
                            return;
                        }
                        break;
                    case UPDATE_ADDRESS:
                        contact.Address = newValue;
                        break;
                    case UPDATE_CITY:
                        AddressBookDetails.cityToContactMap[contact.City].Remove(contact);// Remove the contact from city dictionary                        
                        contact.City = newValue;// Update the contact city                        
                        AddressBookDetails.AddToCityDictionary(contact.City, contact);// Add to city dictionary
                        break;
                    case UPDATE_STATE:
                        AddressBookDetails.stateToContactMap[contact.State].Remove(contact);// Remove the contact from state dictionary
                        contact.State = newValue;  // Update the contact state   
                        AddressBookDetails.AddToStateDictionary(contact.State, contact);// Add to state dictionary
                        break;
                    case UPDATE_ZIP:
                        contact.Zip = newValue;
                        break;
                    case UPDATE_PHONE_NUMBER:
                        contact.PhoneNumber = newValue;
                        break;
                    case UPDATE_EMAIL:
                        contact.Email = newValue;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Record Successfully Edit and Updated ");
        }

        public void RemoveContact()
        {
            try
            {
                if (contactList.Count() == 0)  // If the List does not have any contacts
                {
                    Console.WriteLine("Record Not Found");
                    return;
                }
                Console.Write("Enter Name of contact to be Removed:- ");
                string name = Console.ReadLine();
                ContactDetails contact = SearchByName(name); // Search for the contact            
                if (contact == null)// If contact doesnt exist
                {
                    Console.WriteLine("No record found");
                    return;
                }
                contact.Display();// Print the details of contact 

                contactList.Remove(contact);
                AddressBookDetails.cityToContactMap[contact.City].Remove(contact); //remove city from Dictionary
                AddressBookDetails.stateToContactMap[contact.State].Remove(contact);  //remove State from Dictionary
                Console.WriteLine("Successfully Record Deleted"); //print                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /* UC11:- Ability to sort the entries in the address book alphabetically by Person’s name.
                   - Use Console to sort person details by name.
                   - Use Collection Library for Sorting.
                   - Override toString method to finally Print Person Entry in Concole.
                   - Use Lambda Expression.

           UC12:- Ability to sort the entries in the address book by City, State, or Zip
                   - Write functions to sort person by City, State or Zip
                   - Use Collection Library for Sorting
        */
        public void GetAllContacts()
        {
            if (contactList.Count() == 0) //List does not have any contacts
            {
                Console.WriteLine("No Contacts Found");
                return;
            }
            List<ContactDetails> listForSorting = null;
            Console.WriteLine("Select the Sorting Record\n1.Name\n2.City\n3.State\n4.Zip");//Print 
            int op = Convert.ToInt32(Console.ReadLine()); //take input
            switch (op)
            {
                case 1:
                    listForSorting = contactList.OrderBy(contact => (contact.FirstName + contact.LastName)).ToList(); //sort Name wise using lambda Expression
                    break;
                case 2:
                    listForSorting = contactList.OrderBy(contact => contact.City).ToList(); //Sorting city sing lambda Expression
                    break;
                case 3:
                    listForSorting = contactList.OrderBy(contact => contact.Zip).ToList(); //Sorting zip code sing lambda Expression
                    break;
                case 4:
                    listForSorting = contactList.OrderBy(contact => contact.State).ToList(); //Sorting State sing lambda Expression
                    break;
                default:
                    listForSorting = contactList;
                    break;
            }

            listForSorting.ForEach(contact => contact.Display()); // Display all contact details in list
        }

        private ContactDetails SearchByName(string name)
        {
            if (contactList.Count == 0)   // If the list is empty
                return null;
            int numOfContactsSearched = 0;
            int numOfConatctsWithNameSearched = 0; // storing the count of contacts with searched name string
            foreach (ContactDetails contact in contactList) // Search if Contacts have the given string in name
            {
                numOfContactsSearched++;  // Incrementing the no of contacts searched

                // If contact name matches exactly then it returns the index of that contact
                if ((contact.FirstName + " " + contact.LastName).Equals(name))
                    return contact;

                // If a part of contact name matches then we would ask them to enter accurately
                if ((contact.FirstName + " " + contact.LastName).Contains(name))
                {

                    // num of 
                    numOfConatctsWithNameSearched++;
                    Console.WriteLine($"{contact.FirstName} Name Record is Present");
                }

                // If string is not part of any name then exit
                if (numOfContactsSearched == contactList.Count() && numOfConatctsWithNameSearched == 0)
                    return null;
            }

            // Ask to enter name accurately
            Console.Write("\nEnter First Name  and Last Name:- ");
            name = Console.ReadLine();

            //// To exit
            //if (name.ToLower() == "e")
            //   return null;

            return SearchByName(name); //continue search with new name
        }

    }
}
