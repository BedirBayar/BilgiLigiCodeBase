using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DTOs
{
    public class ContestTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
