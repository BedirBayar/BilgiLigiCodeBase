namespace BilgiLigiRatingApi.DataLayer.Entities
{
    public class Team :BaseEntity
    {
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string Image { get; set; }
        public int LeaderId { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BannedUntil { get; set; }
        public string BanReason { get; set; }
    }
}
