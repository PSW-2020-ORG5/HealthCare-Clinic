using IntegrationAdapters.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class PrescriptionService
    {
        ReportService reportservice = new ReportService();

        public string GeneratePrescription(PrescriptionDto prescriptionDto)
        {
            string output = "";
            output += prescriptionDto.Patient;
            output += "///";

            output += prescriptionDto.Medicine;
            output += "///";

            output += prescriptionDto.Amount;
            output += "///";

            output += prescriptionDto.Pharmacy;


            string filename = "Prescription-" + prescriptionDto.Patient + "-" + DateTime.Now.ToString("dd-MM-yyyy");
            File.WriteAllText(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filename + ".txt", output);

            reportservice.Upload(filename + ".txt");

            return filename;
        }
    }
}
