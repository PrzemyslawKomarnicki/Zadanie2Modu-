using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class Rent
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Fleet Vehicle { get; set; }
        public DateTime StartRentTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public double Payment {  get; set; } 
        public bool PaymentCollected { get; set; }
    }
}
