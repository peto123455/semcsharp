using System.IO;
using semestralka.Data;

namespace semestralka.FileHandler
{
    internal class FileHandlerWriter : FileHandler
    {
        private readonly StreamWriter _sw;

        public FileHandlerWriter(Stream fileStream) : base(fileStream)
        {
            _sw = new StreamWriter(fileStream);
        }

        public void SaveVehicle(Vehicle vehicle, string prefix)
        {
            _sw.WriteLine(vehicle.SaveFormat(prefix));
            foreach (var lease in vehicle.leases)
            {
                _sw.WriteLine(lease.SaveFormat());
            }
            foreach (var paperWork in vehicle.paperWorks)
            {
                _sw.WriteLine(paperWork.SaveFormat());
            }
        }

        public override void Close()
        {
            _sw.Close();
            base.Close();
        }
    }
}
