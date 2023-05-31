using System;
using System.Collections.Generic;
using System.IO;
using semestralka.Data;

namespace semestralka.FileHandler
{
    internal class FileHandlerReader : FileHandler
    {
        private readonly StreamReader _sr;

        public FileHandlerReader(Stream fileStream) : base(fileStream)
        {
            _sr = new StreamReader(fileStream);
        }

        public List<Vehicle> GetVehicles(string prefix)
        {
            FileStream.Seek(0, SeekOrigin.Begin);

            var vehicles = new List<Vehicle>();

            string? s;
            Vehicle? previousVehicle = null;

            while ((s = _sr.ReadLine()) != null)
            {
                var split = s.Split(';');

                if (split[0] != prefix && split[0] != "lease" && split[0] != "paperwork")
                {
                    previousVehicle = null;
                }

                if (split[0] == prefix)
                {
                    var vehicle = new Vehicle(split[1], split[2], split[3], split[4], split[5], int.Parse(split[6]), int.Parse(split[7]), int.Parse(split[8]), int.Parse(split[9]));
                    previousVehicle = vehicle;

                    vehicles.Add(vehicle);
                }

                if (split[0] == "lease")
                {
                    if (previousVehicle == null) continue;

                    var leaseInfo = new LeaseInfo(split[1], split[2], DateTime.Parse(split[3]), DateTime.Parse(split[4]), int.Parse(split[6]));
                    DateTime.TryParse(split[5], out DateTime returned);
                    if (split[5] != "") leaseInfo.SetReturn(returned);

                    previousVehicle.leases.Add(leaseInfo);

                }

                if (split[0] == "paperwork")
                {
                    if (previousVehicle == null) continue;

                    var paperWork = new PaperWork(split[1], DateTime.Parse(split[2]), split[4]);
                    DateTime.TryParse(split[3], out DateTime until);
                    if (split[3] != "") paperWork.validUntil = until;

                    previousVehicle.paperWorks.Add(paperWork);

                }

            }

            return vehicles;
        }

        public override void Close()
        {
            _sr.Close();
            base.Close();
        }
    }
}
