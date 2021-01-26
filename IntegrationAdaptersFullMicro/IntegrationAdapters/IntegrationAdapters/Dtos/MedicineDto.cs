using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapters.Dtos
{
    public class MedicineDto
    {
        [Key] 
        public string Name { get; set; }
        public int Amount { get; set; }

        public MedicineDto(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
