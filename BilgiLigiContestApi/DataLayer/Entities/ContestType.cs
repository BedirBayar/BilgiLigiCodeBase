using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataAccess.Entities
{
    public class ContestType :BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }

    }
}
