using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace semestralka
{
    public class Vehicle
    {
        public String brand { get; set; }
        public String model { get; set; }
        public String plate { get; set; }
        public String vin { get; set; }
        public String color { get; set; }
        public int numberOfDoors { get; set; }
        public int milage { get; set; }
        public int year { get; set; }
        public int rentPrice { get; set; }

        public List<LeaseInfo> leases { get; }

        public Vehicle(string brand, string model, string plate, string vin, string color, int numberOfDoors, int milage, int year, int rentPrice)
        {
            this.leases = new List<LeaseInfo>();

            this.brand = brand;
            this.model = model;
            this.plate = plate;
            this.vin = vin;
            this.color = color;
            this.numberOfDoors = numberOfDoors;
            this.milage = milage;
            this.year = year;
            this.rentPrice = rentPrice;
        }

        public override String ToString()
        {
            return this.brand + " " + this.model;
        }
    }
}
