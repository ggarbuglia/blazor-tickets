using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50), Required]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}