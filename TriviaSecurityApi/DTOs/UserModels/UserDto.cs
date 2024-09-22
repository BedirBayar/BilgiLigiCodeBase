namespace TriviaSecurityApi.DTOs.UserModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public decimal Rating {  get; set; }
        public decimal ContributionRating { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
