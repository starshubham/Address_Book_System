using System;

namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program \n");

            // UC6 : Refactor to add multiple Address Book to the System.Each Address Book has a unique Name

            Console.Write("Enter Number of Address Book you want : ");
            int numBook = Convert.ToInt32(Console.ReadLine());
            int numberBook = 0;
            int key = 1;
            while (numberBook < numBook)
            {
                Console.Write("\n Enter name of Address Book : ");
                string book = Console.ReadLine();
                Console.WriteLine("\n Select the below option");
                Console.WriteLine("1.Add Contact Details \n2.View Contact Details ");
                Console.Write("Enter Your Choice : ");
                int num = Convert.ToInt32(Console.ReadLine());

                while (key != 0)
                {
                    switch (num)
                    {

                        case 1:
                            AddressBook.AddContact();
                            break;
                        case 2:
                            AddressBook.Details();
                            break;
                        default:
                            Console.Write("Choose correct option : ");
                            num = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                    Console.Write("\n Do you wish to continue press 1 or Press O for exit : ");
                    key = Convert.ToInt32(Console.ReadLine());
                }
                AddressBook.AddTo(book);
                numberBook++;
            }
        }
    }
}
