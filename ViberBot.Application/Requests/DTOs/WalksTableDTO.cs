using Application.DataModels;

namespace ViberBot.Application.Requests.DTOs;

public class WalksTableDTO
{
    public string IMEI { get; set; } = "";
    public string ReceiverId { get; set; } = "";
    public List<Walk> Walks { get; set; } = new();
}
