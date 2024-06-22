using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class RentService
    {
        public Rent CreateNewRent(ListOfCustomers customers, ListOfVehicles vehicles)
        {            
            Customer customer = customers.ChooseCustomer();
            Console.WriteLine("Is this a new customer or a regular customer? \n1. New\n2. Regular");
            bool validChoice = false;
            var input = Console.ReadKey();
            while (!validChoice)
            {
                switch (input.KeyChar)
                {
                    case '1':
                        customer = customers.AddCustomerForRent();
                        validChoice = true;
                        break;
                    case '2':
                        customer = customers.ChooseCustomer();
                        Console.WriteLine();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Wrong choice, try again\n1. New Customer\n2. Regular Customer");
                        break;
                }
            }
            Fleet vehicle = vehicles.ChooseVehicle();
            
            DateTime startRentTime = DateTime.Now;
            DateTime returnTime;
            double payment;
            if (vehicle.Type == "Bicycle")
            {
                Console.WriteLine("Please enter the number of rental hours: ");                
                int hours;
                while (!int.TryParse(Console.ReadLine(), out hours ) || hours < 0)
                {
                    Console.WriteLine("Wrong data, try again: ");
                }
                returnTime = startRentTime.AddHours(hours);
                payment = vehicle.RentalPrice * hours;
            }
            else
            {
                Console.WriteLine("Please enter the number of rental days: ");
                int days;
                while (!int.TryParse(Console.ReadLine(), out days) || days < 0)
                {
                    Console.WriteLine("Wrong data, try again: ");
                }
                returnTime = startRentTime.AddDays(days);
                payment = vehicle.RentalPrice * days;
            }
            Console.WriteLine($"Has the fee: {payment} €, has been collected? \n1. yes\n2. no");
            input = Console.ReadKey();
            bool paymentCollected = false;
            do
            {
                switch(input.KeyChar)
                {
                    case '1': 
                        paymentCollected = true;
                        validChoice = true;
                        break;
                    case '2': 
                        paymentCollected = false;
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Has the fee been collected? \n1. yes\n2. no");
                        validChoice = false;
                        break;
                };                
            }
            while (!validChoice);
            Rent rent = new Rent() { Customer = customer, Vehicle = vehicle, StartRentTime = startRentTime, ReturnTime = returnTime, Payment = payment, PaymentCollected = paymentCollected};
            return rent;
        }
    }
}
