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

            SetReturn(DateTime.Now);
        }

        public void SetReturn(DateTime? dateTime)
        {
            returned = dateTime;
        }

        public override String ToString()
		{
            return this.Name + " " + this.from.ToString("dd-MM-yyyy");
		}

        public String SaveFormat()
        {
            String returnedTmp = "";

            if (returned != null)
            {
                returnedTmp = ((DateTime)returned).ToString("dd.MM.yyyy hh:mm");
            }

            return String.Format("lease;{0};{1};{2};{3};{4};{5}", Name, Contact, from.ToString("dd.MM.yyyy"), to.ToString("dd.MM.yyyy"), returnedTmp, totalCost);
        }
    }
}
