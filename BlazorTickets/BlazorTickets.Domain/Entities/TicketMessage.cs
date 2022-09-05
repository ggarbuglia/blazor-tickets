using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class TicketMessage : AuditableEntity<long>
    {
        [Column(Order = 6)]
        public Ticket? Ticket { get; set; }

        [Column(Order = 7)]
        public string? Body { get; set; }

        [Column(Order = 8)]
        public string? Fm { get; set; }

        [Column(Order = 9)]
        public string? To { get; set; }

        [Column(Order = 10)]
        public string? Status { get; set; }
    }
}
