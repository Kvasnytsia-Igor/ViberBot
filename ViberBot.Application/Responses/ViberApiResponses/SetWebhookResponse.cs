namespace ViberBot.Application.Responses.ViberApiResponses;

public class SetWebhookResponse
{
    public int status { get; set; }
    public string status_message { get; set; } = "";
    public List<string> event_types { get; set; } = new();
}
