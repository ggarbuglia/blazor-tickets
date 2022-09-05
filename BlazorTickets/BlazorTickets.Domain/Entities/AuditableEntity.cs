using BlazorTickets.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public abstract class AuditableEntity<IdT> : IAuditableEntity<IdT>
    {
        [Column(Order = 1), Key]
        public IdT? Id { get; set; }

        [Column(Order = 2, TypeName = "varchar(50)"), MaxLength(50), Required]
        public string? CreatedBy { get; set; }

        [Column(Order = 3), Required]
        public DateTime? CreatedOn { get; set; }

        [Column(Order = 4, TypeName = "varchar(50)"), MaxLength(50)]
        public string? UpdatedBy { get; set; }

        [Column(Order = 5)]
        public DateTime? UpdatedOn { get; set; }
    }
}