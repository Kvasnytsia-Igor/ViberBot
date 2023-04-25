using Application.Requsts.DTOs;
using System.Text;
using System.Text.Json;
using ViberBot.Application.Requests.DTOs;
using ViberBot.Application.Requests.ViberApiRequests;

namespace ViberBot.Application.Common;

public class ViberRequestTemplates
{
    public static string InvalidMessage(string receiverId)
    {
        return JsonSerializer.Serialize(new TextMessageRequest
        {
            receiver = receiverId,
            text = "Некоректний запит"
        });
    }
    public static string AbsentMessage(string receiverId)
    {
        return JsonSerializer.Serialize(new TextMessageRequest
        {
            receiver = receiverId,
            text = "IMEI відсутній в базі данних, введіть інший"
        });
    }
    public static string GeneralInfo(WalksDataDTO walksDataDTO)
    {
        return JsonSerializer.Serialize(new TextMessageRequest
        {
            receiver = walksDataDTO.ReceiverId,
            text =
                $"IMEI: {walksDataDTO.IMEI}\n" +
                $"Всього прогулянок: {walksDataDTO.WalksCount}\n" +
                $"Всього пройдено кілометрів: {walksDataDTO.TotalDistanceKM}\n" +
                $"Всього витрачено хвилин: {walksDataDTO.TotalMinutes}\n"
        });
    }
    public static string GeneralInfoWithKeyboard(WalksDataDTO walksDataDTO)
    {
        return JsonSerializer.Serialize(new KeyboardMessageRequest
        {
            receiver = walksDataDTO.ReceiverId,
            text =
                $"IMEI: {walksDataDTO.IMEI}\n" +
                $"Всього прогулянок: {walksDataDTO.WalksCount}\n" +
                $"Всього пройдено кілометрів: {walksDataDTO.TotalDistanceKM}\n" +
                $"Всього витрачено хвилин: {walksDataDTO.TotalMinutes}\n",
            keyboard = new Keyboard
            {
                Buttons = new List<KeyboardButton>
                {
                    new KeyboardButton
                    {
                        ActionBody = $"walks_list/{walksDataDTO.IMEI}/10"
                    }
                }
            }
        });
    }
    public static string WalksTableList(WalksTableDTO walksTableDTO)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(string.Format("|{0,-15}|{1,-15}|{2,-15}|", "#", "Кілометри", "Хвилини"));
        for (int i = 0; i < walksTableDTO.Walks.Count; i++)
        {
            stringBuilder.AppendLine(string.Format("|{0,-15}|{1,-15}|{2,-15}|", 
                (i + 1).ToString(),
                walksTableDTO.Walks[i].DistanceKilometers, 
                walksTableDTO.Walks[i].DurationMinutes));
        }
        return JsonSerializer.Serialize(new TextMessageRequest
        {
            receiver = walksTableDTO.ReceiverId,
            text = stringBuilder.ToString(),

        }, new JsonSerializerOptions { WriteIndented = true });
    }
}

