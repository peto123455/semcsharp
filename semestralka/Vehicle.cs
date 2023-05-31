using System;
using System.Collections.Generic;

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
            return this.brand + " " + this.model + " - " + this.plate;
        }

        public String VehicleDetails()
        {
            return String.Format("Výrobca: {0}\nModel: {1}\nFarba: {2}\nPočet dverí: {3}\nNajazdené: {4} km\nRok výroby: {5}\nVIN: {6}\n\n\nCena na deň: {7} €",
                brand, model, color, numberOfDoors, milage, year, vin, rentPrice);
        }

        public String SaveFormat(String prefix)
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};", prefix, brand, model, plate, vin, color, numberOfDoors, milage, year, rentPrice);
        }
    }
}
