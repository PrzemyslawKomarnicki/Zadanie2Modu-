using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager
{
    public class ListOfCustomers
    {
        private List<Customer> Customers { get; set; }

        public List<Customer> SetCustomersList(ListOfCustomers customers)
        {
            List<Customer> customersList = new List<Customer>();
            customers.Customers = customersList;
            return customers.Customers;
        }
        public int GetCustomerId()
        {
            foreach (var customer in Customers)
            {
                Console.WriteLine($"{customer.Id}. Name: {customer.Name} {customer.Surname}");
            }
            Console.WriteLine("Enter ID of choosen customer: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data, please ty again: ");
            }
            return id;
        }
        public void DisplayAllCustomers()
        {
            foreach (var customer in Customers) 
            {
                Console.WriteLine($"{customer.Id}. Name: {customer.Name} {customer.Surname} {customer.CompanyName} Phone Number: {customer.PhoneNumber}, ");
            }
        }
        public void AddCustomerToList()
        {
            CostumerService newCustomer = new CostumerService();
            Customer customer = newCustomer.CreateCustomer();
            customer.Id += Customers.Count;
            Customers.Add(customer);
            Console.WriteLine($"Yout have successfully added {customer.Name} {customer.Surname}");
        }
        public void AddCustomerToTest(Customer customer)
        {            
            customer.Id += Customers.Count;
            Customers.Add(customer);
            
        }
        public Customer ChooseCustomer()
        {
            foreach (var c in Customers)
            {
                if (c.RegularCustumerStatus)
                {
                    Console.WriteLine($"{c.Id}. Name: {c.Name} {c.Surname} {c.CompanyName}");
                }
            }
            Console.WriteLine("Please enter ID of selected customer: ");
            int id;
            while(!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data, try again: ");
            }
            Customer customer = Customers.Find(customer => customer.Id== id);
            return customer;
        }
        public Customer AddCustomerForRent()
        {
            CostumerService newCustomer = new CostumerService();
            Customer customer = newCustomer.CreateCustomer();
            customer.Id += Customers.Count;
            Customers.Add(customer);
            return customer;
        }
        public void RemoveCustomerFromList(int id)
        {
            
            Customer customerToRemove = Customers.Find(cus => cus.Id == id);
            if (customerToRemove != null)
            {
                Console.WriteLine($"Are youe sure you want to remove {customerToRemove.Id}. {customerToRemove.Name} {customerToRemove.Surname}\n1. yes\n2. no");
                var choice = Console.ReadKey();                
                bool validChoice = false;
                do
                {
                    switch (choice.KeyChar)
                    {
                        case '1':
                            Customers.Remove(customerToRemove);
                            Console.WriteLine($"You have succesfully removed {customerToRemove.Id}. {customerToRemove.Name} {customerToRemove.Surname}");
                            Customers.Sort((x, y) => x.Id.CompareTo(y.Id));
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
                    };                    
                }
                while(!validChoice);
            }
            
        }
    }
}
