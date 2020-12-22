using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services.TestServices
{
    public class HttpTestService
    {
        public static int Num { get; set; }

        public HttpTestService(int num)
        {
            Num = num;
        }

        public static async Task SendFileViaHttp(string file) {
            
            await SendPostRequestTest(file);
        }

        public static async Task SendPostRequestTest(string file)
        {

            HttpClient client = new HttpClient();

            string url = "http://localhost:8080/httpfile/download/" + file;

            string path = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "IntegrationAdapters" + Path.DirectorySeparatorChar + "MedSpec" + Path.DirectorySeparatorChar + file + ".txt";

            if (!File.Exists(path)) 
            {
                return;
            }

            var bytes = File.ReadAllBytes(path);
            var str = System.Text.Encoding.Default.GetString(bytes);

            var stringContent = new StringContent(str);
            HttpResponseMessage response = await client.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode) {
                Num = 200;
            }

        }

    }
}
