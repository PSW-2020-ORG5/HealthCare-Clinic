using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.InMemoryRepository;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;

namespace IntegrationAdapters.Services
{
    public class ReportService
    {
        public void Upload(String FileName)
        {
            var Creds = ServerCredentialsDto.GetInstance();
            using SftpClient client = new SftpClient(new PasswordConnectionInfo(Creds.Ip, Creds.Username, Creds.Password));
            client.Connect();
            string sourceFile = ServerCredentialsDto.GetInstance().SourceFolder + Path.DirectorySeparatorChar + FileName;
            using (Stream stream = File.OpenRead(sourceFile))
            {
                Console.WriteLine(Creds.ServerFolder + Path.DirectorySeparatorChar + Path.GetFileName(sourceFile) + "*******************************");
                client.UploadFile(stream, Path.GetFileName(sourceFile) , x => { Console.WriteLine(x); });
            }
            client.Disconnect();
        }

        public void GenerateConsumptionReportBetweenTwoDates(PeriodDto periodDTO)
        {
            List<string> output = GetDataForReport(periodDTO);
            
            string filename = "Report " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".txt";
            File.WriteAllLines(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filename, output.ToArray());
            string path = Environment.CurrentDirectory + Path.DirectorySeparatorChar + filename;

            Upload(filename);
        }

        private List<string> GetDataForReport(PeriodDto periodDTO)
        {
            DateTime start = ParseToDates(periodDTO.StartDate);
            DateTime end = ParseToDates(periodDTO.EndDate);
            List<ConsumedMedicine> result = GetConsumedMedicineBetweenTwoDates(start, end);
            List<string> output = GetFormatedOutput(result);

            return output;
        } 

        private DateTime ParseToDates(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));

            return newDate;
        }

        private List<ConsumedMedicine> GetConsumedMedicineBetweenTwoDates(DateTime start, DateTime end)
        {
            //ConsumedMedicineInMemory consumedMedicineInMemory = ConsumedMedicineInMemory.GetInstance();
            List<ConsumedMedicine> consumed = ConsumedMedicineInMemory.GetInstance().GetMedicine();
            List<ConsumedMedicine> result = new List<ConsumedMedicine>();

            foreach (ConsumedMedicine medicine in consumed)
            {
                if (medicine.date >= start && medicine.date <= end)
                {
                    result.Add(medicine);
                }
            }
            return result;
        }

        private List<string> GetFormatedOutput(List<ConsumedMedicine> result)
        {
            List<string> output = new List<string>();
            foreach (ConsumedMedicine r in result)
            {
                output.Add(r.name + " // " + r.amountSpent.ToString());
            }
            return output;
        }

        private void SendReportSFTP(string path, string filename)
        {
            var Creds = ServerCredentialsDto.GetInstance();
            using SftpClient client = new SftpClient(new PasswordConnectionInfo(Creds.Ip, Creds.Username, Creds.Password));
            client.Connect();
            using (Stream stream = File.OpenRead(path))
            {
                Console.WriteLine(filename);
                client.UploadFile(stream, Creds.ServerFolder + Path.DirectorySeparatorChar + filename, x => { System.Console.WriteLine(x); });
            }
            client.Disconnect();
        }
    }
}
