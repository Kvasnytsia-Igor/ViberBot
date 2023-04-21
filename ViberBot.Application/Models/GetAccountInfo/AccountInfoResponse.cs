namespace ConsoleTest.Models.GetAccountInfo
{
    public class AccountInfoResponse
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Uri { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Background { get; set; } = "";
        public string Category { get; set; } = "";
        public string Subcategory { get; set; } = "";
        public Location Location { get; set; } = new Location();
        public string Country { get; set; } = "";
        public string Webhook { get; set; } = "";
        public string[] EventTypes { get; set; } = Array.Empty<string>();
        public int SubscribersCount { get; set; }
        public Member[] Members { get; set; } = Array.Empty<Member>();
    }
}
