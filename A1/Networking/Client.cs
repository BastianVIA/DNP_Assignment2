using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using A1.Data;

namespace A1.Networking
{
    public class Client : IClient
    {
        private string uri = "http://localhost:8080/";

        public async Task<List<Adult>> ReadData()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "adult");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> adultList = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adultList;
        }

        public async Task SaveChanges(IList<Adult> adults)
        {
            using HttpClient client = new HttpClient();

            string adultListAsJson = JsonSerializer.Serialize(adults);

            StringContent content = new StringContent(adultListAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(uri + "adult", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
        
        public async Task<List<User>> GetUsers()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "user");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<User> userList = JsonSerializer.Deserialize<List<User>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Console.WriteLine(userList);
            return userList;
        }
    }
}