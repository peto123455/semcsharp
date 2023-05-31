using System;

namespace semestralka.Data
{
    public class LeaseInfo
    {
        public string name { get; set; }
        public string contact { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public DateTime? returned { get; set; }
        public int totalCost { get; set; }

        public LeaseInfo(string name, string contact, DateTime from, DateTime to, int totalCost)
        {
            this.name = name;
            this.contact = contact;
            this.from = from;
            this.to = to;
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

        public override string ToString()
        {
            return name + " " + from.ToString("dd-MM-yyyy");
        }

        public string SaveFormat()
        {
            var returnedTmp = "";

            if (returned != null)
            {
                returnedTmp = ((DateTime)returned).ToString("dd.MM.yyyy HH:mm");
            }

            return $"lease;{name};{contact};{from:dd.MM.yyyy};{to:dd.MM.yyyy};{returnedTmp};{totalCost}";
        }
    }
}
