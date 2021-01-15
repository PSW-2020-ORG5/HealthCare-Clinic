namespace IntegrationAdapters.Dtos
{
    public class PrescriptionDto
    {
        public string Patient { get; set; }
        public string Medicine { get; set; }
        public int Amount { get; set; }
        public string Pharmacy { get; set; }
        public string Location { get; set; }

        public PrescriptionDto(string patient, string medicine, int amount, string pharmacy, string location)
        {
            Patient = patient;
            Medicine = medicine;
            Amount = amount;
            Pharmacy = pharmacy;
            Location = location;
        }
    }
}
