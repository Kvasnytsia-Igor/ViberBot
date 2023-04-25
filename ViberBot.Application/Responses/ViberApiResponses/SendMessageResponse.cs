namespace ViberBot.Application.Responses.ViberApiResponses;

public class SendMessageResponse
{
    public int status { get; set; }
    public string status_message { get; set; } = "";
    public long message_token { get; set; }
    public string chat_hostname { get; set; } = "";
    public int billing_status { get; set; }
}
