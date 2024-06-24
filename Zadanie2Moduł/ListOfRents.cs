using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager
{
    public class ListOfRents
    {
        private List<Rent> Rents {  get; set; }
        public List<Rent> SetRentsList(ListOfRents rents)
        { 
            List<Rent> newRentsList = new List<Rent>();
            rents.Rents = newRentsList;
            return rents.Rents;
        }
        public void AddRents(ListOfCustomers customers, ListOfVehicles vehicles)
        {
            RentService rentService = new RentService();
            Rent rent = rentService.CreateNewRent(customers, vehicles);
            rent.Id += Rents.Count();
            Console.WriteLine($"Yout have successfully added {rent.Customer.Name} {rent.Customer.Surname}");
            Rents.Add(rent);
        }
        public void RemoveRent(ListOfCustomers customers)
        {
            foreach (var rent in Rents)
            {
                Console.WriteLine($"{rent.Id} Customer Name: {rent.Customer.Name} {rent.Customer.Surname} Vehicle: {rent.Vehicle.Brand} {rent.Vehicle.Model}");
            }
            Console.WriteLine("Please enter ID of the rental agreement: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data, please try again: ");
            }
            Rent rentToRemove = Rents.Find(rent => rent.Id == id);
            if (rentToRemove.Customer.OneTimeCustomer)
            {
                customers.RemoveCustomerFromList(rentToRemove.Customer.Id);
                Console.WriteLine($"Yout have successfully removed {rentToRemove.Customer.Name} {rentToRemove.Customer.Surname}");
                Rents.Remove(rentToRemove);
                Rents.Sort((x, y) => x.Id.CompareTo(y.Id));
            }            
            else if (rentToRemove == null)
            {
                Console.WriteLine($"Rent with this ID doesn't exist");
            }
            else
            {
                Console.WriteLine($"Yout have successfully removed {rentToRemove.Id} {rentToRemove.Vehicle.Type}: {rentToRemove.Vehicle.Brand}, Customer: {rentToRemove.Customer.Name} {rentToRemove.Customer.Surname} ");
                Rents.Remove(rentToRemove);
                Rents.Sort((x, y) => x.Id.CompareTo(y.Id));
            }

        }
        public void DisplayRentedVehicles()
        {
            foreach (var rent in Rents)
            {
                Console.WriteLine($"{rent.Id}. {rent.Vehicle.Brand} {rent.Vehicle.Model} {rent.ReturnTime}");
            }
        }
    }
}
