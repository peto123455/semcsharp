using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralka
{
    public class LeaseInfo
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public DateTime? returned { get; set; }
        public int totalCost { get; set; }

        public LeaseInfo(string name, string contact, DateTime from, DateTime to, int totalCost)
        {
            Name = name;
            Contact = contact;
            this.from = from;
            this.to = to;
            this.returned = returned;
            this.totalCost = totalCost;
        }

        public void Return()
        {
            if (returned != null) return;

            returned = DateTime.Now;
        }

		public override String ToString()
		{
            return this.Name + " " + this.from.ToString("dd-MM-yyyy");
		}
	}
}
