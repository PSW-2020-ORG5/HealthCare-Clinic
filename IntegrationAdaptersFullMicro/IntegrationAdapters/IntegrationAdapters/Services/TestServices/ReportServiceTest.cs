using System.IO;

namespace IntegrationAdapters.Services.TestServices
{
    public class ReportServiceTest
    {
        public bool UploadFileAndCheckIfItExists(IConsumptionReport consReport)
        {
            return File.Exists(consReport.UploadFileToServer());
        }
    }
}
