using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class Question : BaseEntity
    {
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("Difficulty")]
        public int Difficulty { get; set; }
        [Column("Text")]
        public string Text { get; set; }
        [Column("Image")]
        public string Image { get; set; }
        [Column("Answer")]
        public string Answer { get; set; }
        [Column("Choice1")]
        public string Choice1 { get; set; }
        [Column("Choice2")]
        public string Choice2 { get; set; }
        [Column("Choice3")]
        public string Choice3 { get; set; }
        [Column("Choice4")]
        public string Choice4 { get; set; }

    }
}
