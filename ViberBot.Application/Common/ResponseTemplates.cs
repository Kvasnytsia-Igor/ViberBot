using Application.Requsts.DTOs;

namespace ViberBot.Application.Common;

public class ResponseTemplates
{
    public static object GeneralInfo(WalksDataDTO walksDataDTO)
    {
        return new
        {
            receiver = walksDataDTO.ReceiverId,
            sender = new
            {
                name = "KvasBot"
            },
            type = "text",
            text =
                $"IMEI: {walksDataDTO.IMEI}\n" +
                $"Всього прогулянок: {walksDataDTO.WalksCount}\n" +
                $"Всього пройдено кілометрів: {walksDataDTO.TotalDistanceKM}\n" +
                $"Всього витрачено хвилин: {walksDataDTO.TotalMinutes}\n",
            min_api_version = 7
        };
    }
    public static object WelcomeMessage()
    {
        return new
        {
            type = "text",
            text = "Введіть IMEI"
        };
    }
    public static object AbsentMessage(string receiverId)
    {
        return new
        {
            Receiver = receiverId,
            sender = new
            {
                name = "KvasBot"
            },
            type = "text",
            text = "IMEI відсутній в базі данних, введіть інший"
        };
    }
    public static object InvalidIMEIMessage(string receiverId)
    {
        return new
        {
            Receiver = receiverId,
            sender = new
            {
                name = "KvasBot"
            },
            type = "text",
            text = "IMEI некоректний"
        };
    }
    public static object GeneralInfo2(WalksDataDTO walksDataDTO)
    {
        return new
        {
            receiver = walksDataDTO.ReceiverId,
            sender = new
            {
                name = "KvasBot"
            },
            min_api_version = 7,
            type = "text",
            text = "Hello world",
            keyboard = new
            {
                Type = "keyboard",
                Buttons = new List<object>()
                {
                    new
                    {
                        ActionType = "open-url",
                        ActionBody = "https://www.google.com/",
                        Text = "Key text",
                        TextSize = "regular"
                    }
                }
            }
        };
    }
}

