using System;

namespace IntegrationAdapters.Models
{
    public class ConsumedMedicine
    {
        public string id { get; set; }
        public string name { get; set; }
        public int amountSpent { get; set; }
        public DateTime date { get; set; }

        public ConsumedMedicine()
        {
        }

        public ConsumedMedicine(string id, string name, int amountSpent, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.amountSpent = amountSpent;
            this.date = date;
        }
    }
}
