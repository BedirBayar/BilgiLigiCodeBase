namespace TriviaSecurityApi.DTOs.UserModels
{
    public class BanUserRequest
    {
        public int Id { get; set; }
        public string BanReason { get; set; }
        public int BanDays { get; set; }
    }
}
