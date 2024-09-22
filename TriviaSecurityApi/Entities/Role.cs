using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaSecurityApi.Entities
{
    [Table("Role")]
    public class Role:BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}
