using ConsoleTest.Models.GetAccountInfo;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;

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
        public async Task Send(object messageJson, string url)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", _token);
            HttpResponseMessage response = await client.PostAsJsonAsync(
                    url, messageJson);
            response.EnsureSuccessStatusCode();
        }
        public async Task SendWithResponse(object messageJson, string url)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", _token);
                HttpResponseMessage response = await client.PostAsJsonAsync(
                        url, messageJson);
                response.EnsureSuccessStatusCode();
                AccountInfoResponse? accountInfoResponse = await response.Content.ReadFromJsonAsync<AccountInfoResponse>();
                var options = new JsonSerializerOptions { WriteIndented = true };
                var jsonString = JsonSerializer.Serialize(accountInfoResponse, options);
                Console.WriteLine(jsonString);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
