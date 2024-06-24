using System;
using System.Reflection;
using System.Xml.Linq;

namespace RentCar
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            DateTime date;
            Fleet vehicle1 = new Fleet() { Brand = "Fiat", Model = "125p", Mileage = 10264, ProductionYear = 1994, ServiceTime = new DateTime(2024, 12, 24), RentalPrice = 350, Type = "Car", Availability = true, OnService = false };
            Fleet vehicle2 = new Fleet() { Brand = "Fiat", Model = "126p", Mileage = 10205, ProductionYear = 1994, ServiceTime = new DateTime(2024, 11, 12), RentalPrice = 350, Type = "Car", Availability = true, OnService = false };
            Fleet vehicle3 = new Fleet() { Brand = "Ferrari", Model = "Testarossa", Mileage = 605, ProductionYear = 1988, ServiceTime = new DateTime(2024, 8, 16), RentalPrice = 850, Type = "Car", Availability = true, OnService = false };
            Fleet vehicle4 = new Fleet() { Brand = "Toyota", Model = "Yaris", Mileage = 25485, ProductionYear = 2023, ServiceTime = new DateTime(2025, 6, 1), RentalPrice = 200, Type = "Car", Availability = true, OnService = false };
            Customer customer1 = new Customer() { Name = "Przemek", Surname = "Komar", PhoneNumber = "534624089", CompanyName = "", RegularCustumerStatus = false, OneTimeCustomer = true };
            Customer customer2 = new Customer() { Name = "Damian", Surname = "Waman", PhoneNumber = "534564089", CompanyName = "", RegularCustumerStatus = false, OneTimeCustomer = true };
            Customer customer3 = new Customer() { Name = "Gosia", Surname = "Komar", PhoneNumber = "531234089", CompanyName = "", RegularCustumerStatus = true, OneTimeCustomer = false };
            Customer customer4 = new Customer() { Name = "Daniel", Surname = "Roszko", PhoneNumber = "523658489", CompanyName = "", RegularCustumerStatus = true, OneTimeCustomer = false };

            ListOfVehicles vehicles = new ListOfVehicles();
            vehicles.SetListOfVehicles(vehicles);
            ListOfCustomers customers = new ListOfCustomers();
            customers.SetCustomersList(customers);
            ListOfRents rents = new ListOfRents();
            rents.SetRentsList(rents);
            MenuService menuService = new MenuService();
            menuService.SetMenuList(menuService);
            vehicles.AddVehicleTest(vehicle1);
            vehicles.AddVehicleTest(vehicle2);
            vehicles.AddVehicleTest(vehicle3);
            vehicles.AddVehicleTest(vehicle4);
            customers.AddCustomerToTest(customer1);
            customers.AddCustomerToTest(customer2);
            customers.AddCustomerToTest(customer3);
            customers.AddCustomerToTest(customer4);
            bool exit = false;
            Console.WriteLine("Welcome in your fleet manager");

            while (!exit)
            {                
                menuService.DisplayMenuParts("MainMenu");
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.WriteLine("");
                        menuService.FleetMenuAction(menuService, vehicles);                                                
                        break;
                    case '2':
                        Console.WriteLine("");
                        menuService.CustomerMenuAction(menuService, customers);
                        break;
                    case '3':
                        Console.WriteLine("");
                        menuService.RentalMenuAction(menuService, rents, customers, vehicles);
                        break;
                    case '9':                                                
                        Console.WriteLine("\nGood Bye");
                        exit = true;
                    break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Wrong operation, try again");
                        break;
                }
            }




        }
    }
}
