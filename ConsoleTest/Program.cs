using System.Net.Http.Json;
using System.Text.Json;
using ConsoleCkeck.Models.GetAccountInfo;

await SetWebHook();
//await SendMessage();
//await GetAccountInfo();
//Debug.WriteLine("hello");

static async Task SendMessage()
{
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", "50e526ec4be7dcb9-64d0bc28836f2a6c-c5db42f558d31e4f");
    HttpResponseMessage response = await client.PostAsJsonAsync(
        "https://chatapi.viber.com/pa/send_message", new
        {
            type = "text",
            text = $"Hello",
            sender = new
            {
                name = "Bot"
            }
        });
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    await Console.Out.WriteLineAsync(responseBody);
}
static async Task GetAccountInfo()
{
    HttpClient client = new HttpClient();
    try
    {
        client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", "50e526ec4be7dcb9-64d0bc28836f2a6c-c5db42f558d31e4f");
        var content = new
        {
        };
        using HttpResponseMessage response = await client.PostAsJsonAsync(
            "https://chatapi.viber.com/pa/get_account_info", content
            );
        response.EnsureSuccessStatusCode();
        string accountInfoResponse = await response.Content.ReadAsStringAsync();
        //var options = new JsonSerializerOptions { WriteIndented = true };
        //var jsonString = JsonSerializer.Serialize(accountInfoResponse, options);
        Console.WriteLine(accountInfoResponse);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
    }
}

static async Task SetWebHook()
{
    HttpClient client = new HttpClient();
    try
    {
        client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", "50e526ec4be7dcb9-64d0bc28836f2a6c-c5db42f558d31e4f");
        var content = new
        {
            url = "https://d813-94-230-200-99.ngrok-free.app/api/viber/webhook/",
            event_types = new[]
            {
                "delivered",
                "seen",
                "failed",
                "subscribed",
                "unsubscribed",
                "conversation_started"
            }
        };
        using HttpResponseMessage response = await client.PostAsJsonAsync(
            "https://chatapi.viber.com/pa/set_webhook", content
            );
        response.EnsureSuccessStatusCode();
        AccountInfoResponse? accountInfoResponse = await response.Content.ReadFromJsonAsync<AccountInfoResponse>();
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(accountInfoResponse, options);
        Console.WriteLine(jsonString);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
    }
}



//WKrsS+xsuXC86K6bcAiDRg==