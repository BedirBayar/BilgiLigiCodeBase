using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class ContestRule:BaseEntity
    {
        [Column("ContestTypeId")]
        public int ContestTypeId { get; set; }
        [Column("Order")]
        public int Order {  get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}
