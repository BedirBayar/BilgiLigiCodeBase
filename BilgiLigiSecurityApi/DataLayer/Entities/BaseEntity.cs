using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiSecurityApi.DataLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("IsArchived")]
        public bool IsArchived { get; set; }
        [Column("CreatedBy")]
        public int CreatedBy { get; set; }
        [Column("UpdatedBy")]
        public int UpdatedBy { get; set; }
        [Column("ArchivedBy")]
        public int ArchivedBy { get; set; }
        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [Column("UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }
        [Column("ArchivedOn")]
        public DateTime? ArchivedOn { get; set; }

    }
}
