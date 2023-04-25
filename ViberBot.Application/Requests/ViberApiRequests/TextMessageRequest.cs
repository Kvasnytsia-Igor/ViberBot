using ViberBot.Application.Requests.ViberApiRequests.ViberRequestModels;

namespace ViberBot.Application.Requests.ViberApiRequests;

public class TextMessageRequest
{
    public string receiver { get; set; } = "";
    public string text { get; set; } = "";
    public string type { get; set; } = "text";
    public int min_api_version { get; set; } = 7;
    public Sender sender { get; set; } = new();

}
