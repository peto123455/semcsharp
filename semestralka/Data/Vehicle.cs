using System.Collections.Generic;

namespace semestralka.Data
{
    public class Vehicle
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string plate { get; set; }
        public string vin { get; set; }
        public string color { get; set; }
        public int numberOfDoors { get; set; }
        public int mileage { get; set; }
        public int year { get; set; }
        public int rentPrice { get; set; }

        public List<LeaseInfo> leases { get; }
        public List<PaperWork> paperWorks { get; }

        public Vehicle(string brand, string model, string plate, string vin, string color, int numberOfDoors, int mileage, int year, int rentPrice)
        {
            leases = new List<LeaseInfo>();
            paperWorks = new List<PaperWork>();

            this.brand = brand;
            this.model = model;
            this.plate = plate;
            this.vin = vin;
            this.color = color;
            this.numberOfDoors = numberOfDoors;
            this.mileage = mileage;
            this.year = year;
            this.rentPrice = rentPrice;
        }

        public override string ToString()
        {
            return brand + " " + model + " - " + plate;
        }

        public string VehicleDetails()
        {
            return $"Výrobca: {brand}\nModel: {model}\nFarba: {color}\nPočet dverí: {numberOfDoors}\nNajazdené: {mileage} km\nRok výroby: {year}\nŠPZ: {plate}\nVIN: {vin}\n\n\nCena na deň: {rentPrice} €";
        }

        public string SaveFormat(string prefix)
        {
            return $"{prefix};{brand};{model};{plate};{vin};{color};{numberOfDoors};{mileage};{year};{rentPrice};";
        }
    }
}
