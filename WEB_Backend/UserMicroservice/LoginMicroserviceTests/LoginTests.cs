using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using LoginMicroservice;
using LoginMicroservice.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

namespace LoginMicroserviceIntegrationTests
{
    public class LoginTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public LoginTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }



        [Fact]
        public async void Login_with_good_credidental_good_token()
        {
            var user = new UserDTO { Username = "marko1", Password = "marko1" };
            var client = factory.CreateClient();
            var userResp = await client.PostAsync("api/users/login", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            UserDTO userr = JsonConvert.DeserializeObject<UserDTO>(userResp.Content.ReadAsStringAsync().Result);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userr.Token);
            var response = await client.GetAsync("api/validate");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Login_with_good_credidental_bad_token()
        {
            var user = new UserDTO { Username = "marko1", Password = "marko1" };
            var client = factory.CreateClient();
            var userResp = await client.PostAsync("api/users/login", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            UserDTO userr = JsonConvert.DeserializeObject<UserDTO>(userResp.Content.ReadAsStringAsync().Result);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "randomToken");
            var response = await client.GetAsync("api/validate");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void Login_with_bad_credidental()
        {
            var user = new UserDTO { Username = "marko1", Password = "marko12" };
            var client = factory.CreateClient();
            var response = await client.PostAsync("api/users/login", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
