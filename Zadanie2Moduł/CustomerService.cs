using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class CostumerService
    {
        public Customer CreateCustomer()
        {
            Console.WriteLine("Please enter customer's name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter customer's surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Please enter customer's telephone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter customer's company name. If it's private client just press 'ENTER'");
            string companyName = Console.ReadLine();
            if (companyName == "")
            {
                companyName = "PRIVATE";
            }
            Console.WriteLine("Does the customer want to become a regular customer? \n1. yes\n2. no");
            var choice = Console.ReadKey();
            bool validChoice = true;
            bool regularCustomerStatus = false;
            do
            {
               
                switch (choice.KeyChar)
                {
                    case '1':
                        regularCustomerStatus = true;
                        validChoice = true;
                        break;
                    case '2':
                        regularCustomerStatus = false;
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Please enter '1' for 'yes' or '2' for 'no'");
                        validChoice = false;
                        break;

                }
            }
            while (!validChoice);
            bool oneTime = regularCustomerStatus switch
            {
                true => false,
                false => true
            };
            Customer customer = new Customer() {Name = name, Surname = surname, PhoneNumber = phoneNumber, CompanyName = companyName, RegularCustumerStatus = regularCustomerStatus, OneTimeCustomer = oneTime };
            return customer;
        }
    }
}
