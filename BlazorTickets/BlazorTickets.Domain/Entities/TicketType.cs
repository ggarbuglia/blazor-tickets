using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class TicketType : AuditableEntity<int>
    {
        [Column(Order = 6)]
        public string? Name { get; set; }
    }
}