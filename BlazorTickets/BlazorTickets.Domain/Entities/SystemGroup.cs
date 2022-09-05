using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class SystemGroup : AuditableEntity<int>
    {
        [Column(Order = 6)]
        public string? Account { get; set; }

        [Column(Order = 7)]
        public string? DisplayName { get; set; }

        [Column(Order = 8)]
        public string? Mail { get; set; }
    }
}