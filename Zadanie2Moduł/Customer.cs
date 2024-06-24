using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager
{
    public class Customer
    {
        public int Id { get; set; } = 1000;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName {  get; set; }
        public bool RegularCustumerStatus { get; set; }
        public bool OneTimeCustomer { get; set; }

    }
}
