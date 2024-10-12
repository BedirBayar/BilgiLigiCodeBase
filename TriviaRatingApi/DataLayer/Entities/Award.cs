namespace TriviaRatingApi.DataLayer.Entities
{
    public class Award : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Badge { get; set; }
        public string UserOrTeam { get; set; } = "U";

    }
}
