namespace IntegrationAdapters.Dtos
{
    public class PrescriptionDto
    {
        public string Patient { get; set; }
        public string Medicine { get; set; }
        public int Amount { get; set; }
        public string Pharmacy { get; set; }

        public PrescriptionDto(string patient, string medicine, int amount, string pharmacy)
        {
            Patient = patient;
            Medicine = medicine;
            Amount = amount;
            Pharmacy = pharmacy;
        }
    }
}
