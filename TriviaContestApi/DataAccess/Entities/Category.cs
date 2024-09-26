using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }

    }
}
