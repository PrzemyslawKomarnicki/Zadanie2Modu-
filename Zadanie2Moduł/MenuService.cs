using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class MenuService
    {
        private List<Menu> MenuList { get; set; }
        


        private void AddMenuAction(int id, string name, string menuPart)
        {
            Menu menu = new Menu() { Id = id, Name = name, MenuPart = menuPart};
            MenuList.Add(menu);
        }
        public void SetMenuList(MenuService menuService)
        {
            List<Menu> menuList = new List<Menu>();
            menuService.MenuList = menuList;

            menuService.AddMenuAction(1, "Fleet Management", "MainMenu");
            menuService.AddMenuAction(2, "Customer Management", "MainMenu");
            menuService.AddMenuAction(3, "Vehicle Rental", "MainMenu");
            menuService.AddMenuAction(9, "EXIT", "MainMenu");

            menuService.AddMenuAction(1, "Check service time of vehicles", "FleetMenu");
            menuService.AddMenuAction(2, "Add vehicle to list", "FleetMenu");
            menuService.AddMenuAction(3, "Vehicle return from service", "FleetMenu");
            menuService.AddMenuAction(4, "Remove Vehicle from list", "FleetMenu");
            menuService.AddMenuAction(5, "Check list of Vehicles", "FleetMenu");
            menuService.AddMenuAction(6, "Return to Main Menu", "FleetMenu");

            menuService.AddMenuAction(1, "Add Customer to list", "CustomerMenu");
            menuService.AddMenuAction(2, "Remove Customer from list", "CustomerMenu");
            menuService.AddMenuAction(3, "Check list of Customers", "CustomerMenu");
            menuService.AddMenuAction(4, "Return to Main Menu", "CustomerMenu");

            menuService.AddMenuAction(1, "Rent a vehicle", "RentalMenu");
            menuService.AddMenuAction(2, "Return the vehicle", "RentalMenu");
            menuService.AddMenuAction(3, "Check list of availables venicles", "RentalMenu");
            menuService.AddMenuAction(4, "Check list of rented venicles", "RentalMenu");
            menuService.AddMenuAction(5, "Return to Main Menu", "RentalMenu");
        }       

        public void DisplayMenuParts(string menuPart)
        {
            Console.WriteLine("");
            foreach (var menu in MenuList)
            {
                if (menu.MenuPart == menuPart)
                {
                    Console.WriteLine($"{menu.Id}. {menu.Name}");
                }
            }
        }

        public void FleetMenuAction(MenuService menuService, ListOfVehicles vehicles)
        {
            bool restart = false;
            do
            {
                menuService.DisplayMenuParts("FleetMenu");
                Console.WriteLine("Select Action: ");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("");
                        int service = vehicles.DisplayVehiclesByServiceDate();
                        if (service == 1)
                        {
                            vehicles.DesignateService();
                        }
                        restart = true;
                        break;
                    case '2':
                        Console.WriteLine("");
                        vehicles.AddVehicle();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '3':
                        Console.WriteLine("");
                        vehicles.ReturnFromService();
                        Console.ReadKey();
                        Console.WriteLine("Press any key to continue");
                        restart = true;
                        break;
                    case '4':
                        Console.WriteLine("");
                        vehicles.RemoveVehicle();                        
                        restart = true;
                        break;
                    case '5':
                        Console.WriteLine("");
                        vehicles.DisplayAllVehicles();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        restart = true;
                        break;
                    case '6':
                        Console.WriteLine("");
                        restart = false;
                        break;
                    default:
                        Console.WriteLine("\nWrong action, try again.");
                        restart = true;
                        break;
                }
            }
            while (restart);
        }
        public void CustomerMenuAction(MenuService menuService, ListOfCustomers customers)
        {
            bool restart = false;
            do
            {
                menuService.DisplayMenuParts("CustomerMenu");
                Console.WriteLine("Select Action: ");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("");
                        customers.AddCustomerToList();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '2':
                        Console.WriteLine("");
                        customers.RemoveCustomerFromList(customers.GetCustomerId());
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '3':
                        Console.WriteLine("");
                        customers.DisplayAllCustomers();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '4':
                        Console.WriteLine("");
                        restart = false;
                        break;
                    default:
                        Console.WriteLine("\n Wrong action, try again.");
                        restart = true;
                        break;
                }
            }
            while (restart);

        }
        public void RentalMenuAction(MenuService menuService, ListOfRents rents, ListOfCustomers customers, ListOfVehicles vehicles)
        {
            bool restart = false;
            do
            {
                menuService.DisplayMenuParts("RentalMenu");
                Console.WriteLine("Select Action: ");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        rents.AddRents(customers, vehicles);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '2':
                        rents.RemoveRent(customers);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '3':
                        vehicles.DisplayAvailableVehicles();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '4':
                        rents.DisplayRentedVehicles();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        restart = true;
                        break;
                    case '5':
                        Console.WriteLine("");
                        restart = false;
                        break;
                    default:
                        Console.WriteLine("\nWrong action, try again.");
                        restart = true;
                        break;

                }
            }
            while (restart);
        }








    }
    
}
