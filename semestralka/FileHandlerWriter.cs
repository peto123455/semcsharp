using System;
using System.IO;

namespace semestralka
{
    class FileHandlerWriter : FileHandler
    {
        StreamWriter sw;

        public FileHandlerWriter(Stream fileStream) : base(fileStream)
        {
            sw = new StreamWriter(fileStream);
        }

        public void SaveVehicle(Vehicle vehicle, String prefix)
        {
            sw.WriteLine(vehicle.SaveFormat(prefix));
            foreach (LeaseInfo lease in vehicle.leases)
            {
                sw.WriteLine(lease.SaveFormat());
            }
        }

        override public void Close()
        {
            sw.Close();
            base.Close();
        }
    }
}
