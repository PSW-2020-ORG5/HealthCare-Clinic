using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories.InMemoryRepository
{
    public class InMemoryMedicineStorage
    {
        public readonly List<StorageMedicine> storage = new List<StorageMedicine>();

        private static InMemoryMedicineStorage instance = new InMemoryMedicineStorage();

        public InMemoryMedicineStorage()
        {
            storage.Add(new StorageMedicine("Brufen", 200));
            storage.Add(new StorageMedicine("Aspirin", 500));
            storage.Add(new StorageMedicine("Panadol", 350));
            storage.Add(new StorageMedicine("Bromazepan", 100));
        }

        public static InMemoryMedicineStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new InMemoryMedicineStorage();
            }
            return instance;
        }

    }

    public class StorageMedicine
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public StorageMedicine(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
