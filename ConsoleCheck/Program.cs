using Application.Requsts.DTOs;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using ViberBot.Application;
using ViberBot.Application.Common;
using ViberBot.Application.Responses.ViberApiResponses;
using ViberBot.Application.Services;

//Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
//string[] IMEIs = new string[] { "359339077003915", "359339077004361", "359339077004344" };
//Check_TrakcService.Check_FindWalks(IMEIs[0]);

string token = "50e8c2dce827de42-81659656b7e17648-295e607cbf059ba6";
string id = "JJw8K\u002BJmJFz7sb9Omcy97Q==";


//await SetWebHook(token);
//await SendMessage(token, id);
//await GetAccountInfo(token);

DrowTable();


static async Task SetWebHook(string token)
{
    await new MessagesService(token).SendWithResponse<SetWebhookResponse>(JsonConvert.SerializeObject(new
    {
        url = $"{URLs.BASE_URL}/webhook",
    }), "https://chatapi.viber.com/pa/set_webhook");
}

static async Task SendMessage(string token, string id)
{
    //await new MessagesService(token).SendWithResponse<SendMessageResponse>(
    //        ViberRequestTemplates.GeneralInfo(new WalksDataDTO
    //        {
    //            ReceiverId = id,
    //            IMEI = "359339077003915",
    //            WalksCount = 15,
    //            TotalDistanceKM = 25,
    //            TotalMinutes = 35
    //        }), $"{URLs.BASE_VIBER}/send_message");

    await new MessagesService(token).SendWithResponse<SendMessageResponse>(
            ViberRequestTemplates.InvalidMessage(id),
            $"{URLs.BASE_VIBER}/send_message");
}


static async Task GetAccountInfo(string token)
{
    await new MessagesService(token).SendWithResponse<AccountInfoResponse>(
            ViberRequestTemplates.GeneralInfo(new WalksDataDTO
            {

            }), $"{URLs.BASE_VIBER}/get_account_info");
}

static void DrowTable()
{
    // Create a Bitmap object with the desired dimensions and green background
    Bitmap bitmap = new Bitmap(902, 1110, PixelFormat.Format24bppRgb);
    bitmap.SetResolution(200, 200);
    using (var gr = Graphics.FromImage(bitmap))
    {
        gr.Clear(Color.Green);
    }

    Graphics graphics = Graphics.FromImage(bitmap);

    string[,] tableData = {
    {"#", "Кілометри", "Хвилини"},
    {"1", "1000", "1000"},
    {"2", "1000", "1000"},
    {"3", "1000", "1000"},
    {"4", "1000", "1000"},
    {"5", "1000", "1000"},
    {"6", "1000", "1000"},
    {"7", "1000", "1000"},
    {"8", "1000", "1000"},
    {"9", "1000", "1000"},
    {"10", "1000", "1000"}
};

    Font font = new Font("Arial", 12);

    int x = 0;
    int y = 0;

    int cellWidth = 300;
    int cellHeight = 100;
    int cellSpace = 1;

    for (int i = 0; i < tableData.GetLength(0); i++)
    {
        for (int j = 0; j < tableData.GetLength(1); j++)
        {
            Rectangle cellBounds = new Rectangle(x, y, cellWidth, cellHeight);
            cellBounds.Inflate(-cellSpace, -cellSpace);
            graphics.FillRectangle(Brushes.LightGreen, cellBounds);
            graphics.DrawString(tableData[i, j], font, Brushes.Black, cellBounds);

            x += cellWidth + cellSpace * 2;
        }

        x = 0;
        y += cellHeight + cellSpace * 2;
    }

    bitmap.Save("table.jpg", ImageFormat.Jpeg);
}




