namespace TriviaRatingApi.DTOs
{
    public class RankDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public string Description { get; set; }
        public string Insignia { get; set; }
        public string UserOrTeam { get; set; } = "U";
        public bool IsActive { get; set; }
    }
}
