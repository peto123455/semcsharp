using System;

namespace semestralka.Data
{
    public class PaperWork
    {
        
        public string name { get; }
        public DateTime dateOfIssue;
        public DateTime? validUntil;
        public string description;

        public PaperWork(string name, DateTime dateOfIssue, string description)
        {
            this.name = name;
            this.dateOfIssue = dateOfIssue;
            this.description = description;
        }


        public override string ToString()
        {
            return name;
        }

        public string PaperworkDetails()
        {
            var untilTmp = " - ";

            if (validUntil != null)
            {
                untilTmp = ((DateTime)validUntil).ToString("dd.MM.yyyy");
            }

            return $"Názov: {name}\nPlatné od: {dateOfIssue:dd.MM.yyyy}\nPlatné do: {untilTmp}\nPopis:\n{description}";
        }

        public string SaveFormat()
        {
            var validTmp = "";

            if (validUntil != null)
            {
                validTmp = ((DateTime) validUntil).ToString("dd.MM.yyyy HH:mm");
            }

            return $"paperwork;{name};{dateOfIssue:dd.MM.yyyy};{validTmp};{description}";
        }
    }
}
