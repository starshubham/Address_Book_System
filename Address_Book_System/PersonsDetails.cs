using System;

namespace Address_Book_System
{
    class Person
    {
        private string fname, lname, address, city, state, phone, zip, email; //Declaring (Creating) Variables
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

        public string FirstName { get => fname; set => fname = value; }         // get method returns the value of the variable FirstName.
                                                                                // set method assigns a value to the name variable.
        public string LastName { get => lname; set => lname = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string PhoneNo { get => phone; set => phone = value; }
        public string ZipCode { get => zip; set => zip = value; }
        public string Email { get => email; set => email = value; }
        public override string ToString() //Tostring  method to store value
        {
            return "FirstName:- " + FirstName + "\nLastName:- " + LastName + " \nAddress:- " + Address + " \nCity:- " + City
                 + "\nState:- " + State + "\nZipCode:- " + ZipCode + "\nPhoneNo:- " + PhoneNo + "\nEmail:- " + Email + " " + "\n";
        }
    }
}
