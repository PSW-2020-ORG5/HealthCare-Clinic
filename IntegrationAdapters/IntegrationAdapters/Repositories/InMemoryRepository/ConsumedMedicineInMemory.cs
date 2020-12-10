using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;

namespace IntegrationAdapters.Repositories.InMemoryRepository
{
    public class ConsumedMedicineInMemory
    {
        private readonly List<ConsumedMedicine> consumedMedicines = new List<ConsumedMedicine>();

        private static ConsumedMedicineInMemory instance = new ConsumedMedicineInMemory();

        public ConsumedMedicineInMemory()
        {
            consumedMedicines.Add(new ConsumedMedicine("asp1337", "Aspirin", 50, new DateTime(2020, 11, 5)));
            consumedMedicines.Add(new ConsumedMedicine("bruf1487", "Brufen", 30, new DateTime(2020, 11, 15)));
            consumedMedicines.Add(new ConsumedMedicine("brom201", "Bromazepan", 20, new DateTime(2020, 10, 21)));
            consumedMedicines.Add(new ConsumedMedicine("and812", "Andol", 15, new DateTime(2020, 11, 25)));
        }

        public static ConsumedMedicineInMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ConsumedMedicineInMemory();
            }
            return instance;
        }

        public List<ConsumedMedicine> GetMedicine()
        {
            return consumedMedicines;
        }
    }
}
