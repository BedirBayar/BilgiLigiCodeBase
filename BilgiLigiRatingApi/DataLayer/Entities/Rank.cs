namespace BilgiLigiRatingApi.DataLayer.Entities
{
    public class Rank :BaseEntity
    {
        public string Name { get; set; }
        public int Degree { get; set; }
        public string Description { get; set; }
        public string Insignia { get; set; }
        public string UserOrTeam { get; set; } = "U";

    }
}
