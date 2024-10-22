namespace TriviaSecurityApi.DTOs.UserModels
{
    public class BanUserRequest
    {
        public int UserId { get; set; }
        public bool IsUnbanRequest { get; set; }
        public string BanReason { get; set; }
        public int BanDays { get; set; }
    }
}
