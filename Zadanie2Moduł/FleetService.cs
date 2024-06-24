using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class FleetService
    {
        public Fleet CreateNewVehicle()
        {
            Console.WriteLine("Please choose Type of vehicle: ");
            Console.WriteLine("'Car' \n'Motorbike' \n'Bicycle'\n");
            string input = Console.ReadLine();
            while (input.ToLower() != "car" && input.ToLower() != "motorbike" && input.ToLower() != "bicycle")
            {
                Console.WriteLine("Wrong type, write again:  ");
                Console.WriteLine("'Car' \n'Motorbike' \nor 'Bicycle'");
                input = Console.ReadLine();
            }
            string type = input.ToLower() switch
            { 
              "motorbike" => "Motorbike",
              "car" => "Car",
              "bicycle" => "Bicycle"
            } ;
            Console.WriteLine("Please enter brand of vehicle: ");
            string brand = Console.ReadLine();
            Console.WriteLine("Please enter mark of vehicle: ");
            string model = Console.ReadLine();
            Console.WriteLine("Please enter production year of vehicle: ");
            int productionYear;
            while (!int.TryParse(Console.ReadLine(), out productionYear))
            {
                Console.WriteLine("Wrong data, please enter again: ");
            }
            Console.WriteLine("Please enter mileage of vehicle: ");
            int mileage;
            while (!int.TryParse(Console.ReadLine(), out mileage))
            {
                Console.WriteLine("Wrong data, please enter again: ");
            }
            Console.WriteLine("Please enter date of service (DD-MM-YYYY): ");
            DateTime serviceTime;
            while (!DateTime.TryParse(Console.ReadLine(), out serviceTime))
            {
                Console.WriteLine("Wrond date format, please try again");
            }
            Console.WriteLine("Please enter rental price of vehicle: ");
            double rentalPrice;
            while (!double.TryParse(Console.ReadLine(), out rentalPrice))
            {
                Console.WriteLine("Wrong data, please enter again: ");
            }
            
            
            Fleet vehicle = new Fleet() { Brand = brand, Model = model, Mileage = mileage, ProductionYear = productionYear, ServiceTime = serviceTime, RentalPrice = rentalPrice, Type = type, Availability = true , OnService = false};
            return vehicle;

        }        
    }
}
