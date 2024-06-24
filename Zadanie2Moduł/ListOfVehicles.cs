using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager
{
    public class ListOfVehicles
    {
        private List<Fleet> Vehicles {  get; set; }

        public List<Fleet> SetListOfVehicles(ListOfVehicles vehicles)
        {
            List<Fleet> listOfVehicles = new List<Fleet>();
            vehicles.Vehicles = listOfVehicles;
            return vehicles.Vehicles;
        }
        public int DisplayVehiclesByServiceDate()
        {
            int choose = 0;
            Vehicles.Sort((x, y)=> x.ServiceTime.CompareTo(y.ServiceTime));
            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine($"ID: {vehicle.Id}. Type: {vehicle.Type}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}, Service Time: {vehicle.ServiceTime.ToString("dd-MM-yyyy")} ");
            }     
            Console.WriteLine("Do you want to send vehicle on service?\n1. yes\n2. no");
            var input = Console.ReadKey();
            while (choose != 1 && choose != 2)
            {
                switch (input.KeyChar)
                {
                    case '1':
                        choose = 1;
                        break;
                    case '2':
                        choose = 2;
                        break;
                    default:
                        Console.WriteLine("Wrong choise, try again.\nDo you want to send vehicle on service?\n1. yes\n2. no");
                        input = Console.ReadKey();
                        break;
                }
            }
            Vehicles.Sort((x, y) => x.Id.CompareTo(y.Id));
            return choose;
        }
        public void DesignateService()
        {
            Console.WriteLine("\nEnter ID of vehicle designated to service: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\nWrong data, please enter again: ");
            }
            Fleet vehicleToService = Vehicles.Find(vehicle => vehicle.Id == id);
            if (vehicleToService != null)
            {
                Console.WriteLine($"You have designated {vehicleToService.Type.ToLower()} {vehicleToService.Brand} {vehicleToService.Model} for services");
                vehicleToService.OnService = true;
                vehicleToService.Availability = false;
            }
            else 
            {
                Console.WriteLine("Vehicle with that ID doesn't exist" +
                    "");
            }
            
        }
        public void AddVehicle()
        {
            FleetService newVehicle = new FleetService();
            Fleet vehicle = newVehicle.CreateNewVehicle();
            vehicle.Id += Vehicles.Count;
            Vehicles.Add(vehicle);
            Console.WriteLine($"Yout have successfully added {vehicle.Brand} {vehicle.Model}");
        }
        public void AddVehicleTest(Fleet vehicle)
        {            
            vehicle.Id += Vehicles.Count;
            Vehicles.Add(vehicle);
        }
        public void ReturnFromService()
        {
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.OnService == true)
                {
                    Console.WriteLine($"Id {vehicle.Id}. Brand: {vehicle.Brand} Model: {vehicle.Model} Mileage: {vehicle.Mileage}");
                }
            }
            Console.WriteLine("\nEnter ID of returned vehicle: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data, try again: ");
            }
            Fleet returnedVehicle = Vehicles.Find(vehicle => vehicle.Id == id);
            if (returnedVehicle != null)
            {
                returnedVehicle.OnService = false;
                returnedVehicle.Availability = true;
                Console.WriteLine($"{returnedVehicle.Type} {returnedVehicle.Brand} {returnedVehicle.Model} has been returned and is now available.");
            }
            else
            {
                Console.WriteLine("Vehicle with that ID is not or service or doesn't exist");
            }
            
        }
        public void RemoveVehicle()
        {
            
            string type = "";
            while (type != "Car" && type != "Motorbike" && type != "Bicycle")
            {
                Console.WriteLine("\nSelect type of vehicle: \n1. Car\n2. Motorbike\n3. Bicycle");
                var input1 = Console.ReadKey();
                type = input1.KeyChar switch
                {
                    '1' => type = "Car",
                    '2' => type = "Motorbike",
                    '3' => type = "Bicycle",
                    _ => "Wrong choice, try Again\nSelect type of vehicle: \n1. Car\n2. Motorbike\n3. Bicycle"
                };
            }
            Console.WriteLine("");
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Type == type)
                {
                    Console.WriteLine($"{vehicle.Id}. {vehicle.Brand}, {vehicle.Model}, {vehicle.Mileage}");
                }
            }
            Console.WriteLine("Enter ID of vehicle to remove: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data, try again.\nEnter ID of vehicle to remove: ");
            }            
            Fleet vehicleToRemove = Vehicles.Find(vehicle => vehicle.Id == id);
            if (vehicleToRemove != null)
            {
                Console.WriteLine($"Are youe sure you want to remove {vehicleToRemove.Id}. {vehicleToRemove.Brand} {vehicleToRemove.Model}\n1. yes\n2. no");
                var input2 = Console.ReadKey();
                bool validChoice = true;
                do
                {
                    switch (input2.KeyChar)
                    {
                        case '1':
                            Vehicles.Remove(vehicleToRemove);
                            Vehicles.Sort((x, y) => x.Id.CompareTo(y.Id));
                            int newId = 1000;
                            foreach (var vehicle in Vehicles)
                            {
                                vehicle.Id = newId;
                                newId++;
                            }
                            validChoice = true;
                            break;
                        case '2':
                            Console.WriteLine($"You didn't remove anyone");
                            validChoice = true;
                            break;
                        default:
                            validChoice = false;
                            Console.WriteLine("Wrong choice, try again: \n1. yes\n2. no");
                            break;
                    }
                }
                while (!validChoice);
            }
            else 
            { 
                Console.WriteLine("A vehicle with this ID doesn't exist");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }
        public void DisplayAllVehicles()
        {
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.OnService)
                {
                    Console.WriteLine($"ID: {vehicle.Id}. Type: {vehicle.Type}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage} [ON SERVICE]");
                }
                else
                {
                    Console.WriteLine($"ID: {vehicle.Id}. Type: {vehicle.Type}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}");
                }
                
            }
        }        
        public void DisplayAvailableVehicles()
        {
            Console.WriteLine("");
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Availability)
                {
                    Console.WriteLine($"ID: {vehicle.Id}. Type: {vehicle.Type}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}");
                }
            }
        }
        public Fleet ChooseVehicle()
        {
            foreach (var v in Vehicles)
            {
                if (v.Availability)
                {
                    Console.WriteLine($"ID: {v.Id}. Type: {v.Type}, Brand: {v.Brand}, Model: {v.Model}, Mileage: {v.Mileage}");
                }
            }
            Console.WriteLine("Please enter ID of selected customer: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data, try again: ");
            }
            Fleet vehicle = Vehicles.Find(customer => customer.Id == id);
            return vehicle;
        }

    }



    
}
