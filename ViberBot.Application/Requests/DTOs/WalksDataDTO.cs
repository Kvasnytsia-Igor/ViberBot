namespace Application.Requsts.DTOs
{
    public class WalksDataDTO
    {
        public string ReceiverId { get; set; } = "";
        public string IMEI { get; set; } = "";
        public int WalksCount { get; set; }
        public decimal TotalDistanceKM { get; set; }
        public int TotalMinutes { get; set; }
    }
}
