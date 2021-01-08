using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.ObjectConversion
{
    public class ConversionService
    {
        private static readonly ConversionService instance = new ConversionService();



        public static ConversionService GetInstance()
        {
            return instance;
        }

        public Tender ConvertTenderDtoToTender(TenderDto dto)
        {
            var ret = new Tender();
            ret.Name = dto.Name;  
            DateTime dt = DateTime.ParseExact(dto.ClosingDate, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            ret.ClosingDate = dt;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(ret.Name + dto.ClosingDate);
            ret.id = System.Convert.ToBase64String(plainTextBytes);
            ret.RequiredMedicine = dto.RequiredMedicine;
            return ret;
        }
    }
}
