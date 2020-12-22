namespace IntegrationAdapters.Dtos
{
    public class MedicineDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public MedicineDto(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
