using Application.Requsts.DTOs;
using Newtonsoft.Json;
using ViberBot.Application;
using ViberBot.Application.Common;
using ViberBot.Application.Services;

//Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
//string[] IMEIs = new string[] { "359339077003915", "359339077004361", "359339077004344" };
//Check_TrakcService.Check_FindWalks(IMEIs[0]);

string token = "";


//await SetWebHook(token);
await SendMessage(token);
//await GetAccountInfo(token);

static async Task SetWebHook(string token)
{
    await new MessagesService(token).SendWithResponse(JsonConvert.SerializeObject(new
    {
        url = $"{URLs.BASE_VIBER}/set_webhook",
        event_types = new[]
            {
                "delivered",
                "seen",
                "failed",
                "subscribed",
                "unsubscribed",
                "conversation_started"
            }
    }), "https://chatapi.viber.com/pa/set_webhook");
}

static async Task SendMessage(string token)
{
    await new MessagesService(token).SendWithResponse(
            ResponseTemplates.GeneralInfo2(new WalksDataDTO
            {
                ReceiverId = "JJw8K\u002BJmJFz7sb9Omcy97Q==",
                IMEI = "359339077003915",
                WalksCount = 15,
                TotalDistanceKM = 25,
                TotalMinutes = 35
            }), $"{URLs.BASE_VIBER}/send_message");
}


static async Task GetAccountInfo(string token)
{
    await new MessagesService(token).SendWithResponse(
            ResponseTemplates.GeneralInfo2(new WalksDataDTO
            {

            }), $"{URLs.BASE_VIBER}/get_account_info");
}

//  JJw8K\u002BJmJFz7sb9Omcy97Q==





