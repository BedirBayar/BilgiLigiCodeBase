namespace TriviaRatingApi.Models
{
    public class BanRequest
    {
        public int BannedId { get; set; }
        public bool UnbanRequest { get; set; }
        public int BanDays { get; set; }
        public string BanReason { get; set; }
    }
}
