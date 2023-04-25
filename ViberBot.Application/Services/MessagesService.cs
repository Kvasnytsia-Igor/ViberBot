using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ViberBot.Application.Responses.ViberApiResponses;

namespace ViberBot.Application.Services
{
    public class MessagesService
    {
        private readonly string _token;
        public MessagesService(IConfiguration configuration)
        {
            _token = configuration["ViberToken"];
        }
        public MessagesService(string token)
        {
            _token = token;
        }
        public async Task Send(string json, string url)
        {
            HttpClient client = new();
            StringContent content = new(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("X-Viber-Auth-Token", _token);
            HttpResponseMessage response = await client.PostAsync(
                    url, content);
            response.EnsureSuccessStatusCode();
        }
        public async Task SendWithResponse<T>(string json, string url)
        {
            try
            {
                await Console.Out.WriteLineAsync(json);
                HttpClient client = new();
                StringContent content = new(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("X-Viber-Auth-Token", _token);
                HttpResponseMessage response = await client.PostAsync(
                        url, content);
                response.EnsureSuccessStatusCode();
                T? responseInfo = await response.Content.ReadFromJsonAsync<T>();
                var options = new JsonSerializerOptions { WriteIndented = true };
                var jsonString = JsonSerializer.Serialize(responseInfo, options);
                Console.WriteLine(jsonString);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
