using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class HttpService
    {
        private static HttpService instance = new HttpService();

        public HttpService GetInstance()
        {
            return instance;
        }

        public static async Task SendPostRequest(string file)
        {

            HttpClient client = new HttpClient();
            string url = "http://localhost:8080/httpfile/download/ftpsettings";

            var bytes = File.ReadAllBytes(file);
            var str = System.Text.Encoding.Default.GetString(bytes);

            var stringContent = new StringContent(str);
            HttpResponseMessage response = await client.PostAsync(url, stringContent);
        }

        public static async Task SendPostRequest2(string file)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:8080/httpfile/download/" + file;

            var bytes = File.ReadAllBytes(file + ".txt");
            var str = System.Text.Encoding.Default.GetString(bytes);

            var stringContent = new StringContent(str);
            HttpResponseMessage response = await client.PostAsync(url, stringContent);
        }
        
    }
}
