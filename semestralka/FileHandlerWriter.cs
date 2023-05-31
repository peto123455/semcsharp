using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
