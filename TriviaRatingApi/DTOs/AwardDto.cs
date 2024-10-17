namespace TriviaRatingApi.DTOs
{
    public class AwardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Badge { get; set; }
        public string UserOrTeam { get; set; } = "U";
        public bool IsActive { get; set; }
    }
}
