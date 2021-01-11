using IntegrationAdapters.Repositories.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class StorageService
    {

        private static StorageService instance = null;
        public static StorageService GetInstance()
        {
            if(instance == null)
            {
                instance = new StorageService();
            }
            return instance;
        }

        public bool AddMedToStorage(StorageMedicine storageMedicine) {

            foreach (var Med in InMemoryMedicineStorage.GetInstance().storage) { 
                if (Med.Name != storageMedicine.Name) {
                    continue;
                }
                Console.WriteLine("PRE DODAVANJA LEKA: "+ Med.Name + "      " + Med.Amount);
                Med.Amount = Med.Amount + storageMedicine.Amount;
                Console.WriteLine("POSLE DODAVANJA LEKA: " + Med.Name + "      " + Med.Amount);

                return true;
            }

            InMemoryMedicineStorage.GetInstance().storage.Add(storageMedicine);
            return true;
        }

    }
}
