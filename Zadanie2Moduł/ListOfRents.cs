using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
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
            }
            Rents.Remove(rentToRemove);
            Rents.Sort((x, y) => x.Id.CompareTo(y.Id));

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
