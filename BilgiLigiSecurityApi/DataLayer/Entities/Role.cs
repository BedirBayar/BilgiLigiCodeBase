using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiSecurityApi.DataLayer.Entities
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
