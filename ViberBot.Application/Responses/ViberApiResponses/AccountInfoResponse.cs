namespace ViberBot.Application.Responses.ViberApiResponses;

public class AccountInfoResponse
{
    public int status { get; set; }
    public string status_message { get; set; } = "";
    public string id { get; set; } = "";
    public string name { get; set; } = "";
    public string uri { get; set; } = "";
    public string icon { get; set; } = "";
    public string background { get; set; } = "";
    public string category { get; set; } = "";
    public string subcategory { get; set; } = "";
    public Location location { get; set; } = new();
    public string country { get; set; } = "";
    public string webhook { get; set; } = "";
    public List<string> event_types { get; set; } = new();
    public int subscribers_count { get; set; }
    public List<Member> members { get; set; } = new();
}
