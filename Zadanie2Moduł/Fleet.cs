using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class Fleet
    {
        public int Id { get; set; } = 1000;
        public string Brand {  get; set; }
        public string Model {  get; set; }
        public string Type { get; set; }
        public int ProductionYear {  get; set; }
        public int Mileage {  get ; set; }
        public double RentalPrice {  get; set; }
        public DateTime ServiceTime { get; set; }
        public bool OnService { get; set; }
        public bool Availability { get; set; }
    }
}
