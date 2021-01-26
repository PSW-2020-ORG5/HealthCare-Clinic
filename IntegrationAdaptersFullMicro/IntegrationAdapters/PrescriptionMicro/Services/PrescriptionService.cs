using IntegrationAdapters.Dtos;
using System;
using System.IO;

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
            output += "///";
            output += prescriptionDto.Location;

            string filename = "Prescription-" + prescriptionDto.Patient.Replace(" ", "_") + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + prescriptionDto.Medicine;
            File.WriteAllText(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filename + ".txt", output);

            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                reportservice.Upload(filename + ".txt");
            }

            return filename;
        }
    }
}
