using System;
using System.Collections.Generic;
using System.IO;
namespace semestralka
{
    class FileHandlerReader : FileHandler
    {
        StreamReader sr;

        public FileHandlerReader(Stream fileStream) : base(fileStream)
        {
            sr = new StreamReader(fileStream);
        }

        public List<Vehicle> GetVehicles(String prefix)
        {
            fileStream.Seek(0, SeekOrigin.Begin);

            var vehicles = new List<Vehicle>();

            String? s = "";
            Vehicle? previouseVehicle = null;

            while ((s = sr.ReadLine()) != null)
            {
                string[] split = s.Split(';');

                if (split[0] != prefix && split[0] != "lease")
                {
                    previouseVehicle = null;
                }

                if (split[0] == prefix)
                {
                    Vehicle vehicle = new Vehicle(split[1], split[2], split[3], split[4], split[5], int.Parse(split[6]), int.Parse(split[7]), int.Parse(split[8]), int.Parse(split[9]));
                    previouseVehicle = vehicle;

                    vehicles.Add(vehicle);
                }

                if (split[0] == "lease")
                {
                    if (previouseVehicle == null) continue;

                    LeaseInfo leaseInfo = new LeaseInfo(split[1], split[2], DateTime.Parse(split[3]), DateTime.Parse(split[4]), int.Parse(split[6]));
                    DateTime.TryParse(split[5], out DateTime returned);
                    if (split[5] != "") leaseInfo.SetReturn(returned);

                    previouseVehicle.leases.Add(leaseInfo);

                }

            }

            return vehicles;
        }

        public override void Close()
        {
            sr.Close();
            base.Close();
        }
    }
}
