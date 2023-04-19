namespace Application.Models
{
    public class TrackLocation
    {
        public int Id { get; set; }
        public string IMEI { get; set; } = "";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateTrack { get; set; }
    }
}
