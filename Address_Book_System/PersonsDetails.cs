using System;

namespace Address_Book_System
{
    class Person
    {
        public Person(String fname, String lname, String address, String city, String state, String phone, String zip, string email)
        {                                                   //Parameterize constructor
            this.FirstName = fname;
            this.LastName = lname;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.PhoneNo = phone;
            this.ZipCode = zip;
            this.Email = email;
        }

        public string FirstName { get; set; }         // get method returns the value of the variable FirstName.
                                                      // set method assigns a value to the name variable.
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNo { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public override string ToString() //Tostring  method to store value
        {
            return "FirstName:- " + FirstName + "\nLastName:- " + LastName + " \nAddress:- " + Address + " \nCity:- " + City
                 + "\nState:- " + State + "\nZipCode:- " + ZipCode + "\nPhoneNo:- " + PhoneNo + "\nEmail:- " + Email + " " + "\n";
        }
    }
}
