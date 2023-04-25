using ViberBot.Application.Requests.ViberApiRequests.ViberRequestModels;

namespace ViberBot.Application.Requests.ViberApiRequests;

public class KeyboardMessageRequest
{
    public string receiver { get; set; } = "";
    public string text { get; set; } = "";
    public string type { get; set; } = "text";
    public int min_api_version { get; set; } = 7;
    public Sender sender { get; set; } = new();
    public Keyboard keyboard { get; set; } = new();
}
public class Keyboard
{
    public string Type { get; set; } = "keyboard";
    public bool DefaultHeight { get; set; } = false;
    public List<KeyboardButton> Buttons { get; set; } = new List<KeyboardButton>
    {
        new KeyboardButton()
    };
}
public class KeyboardButton
{
    public string ActionType { get; set; } = "reply";
    public string ActionBody { get; set; } = "";
    public string Text { get; set; } = "ТОП 10 Самих дальніх прогулянок";
    public string TextSize { get; set; } = "regular";
}
